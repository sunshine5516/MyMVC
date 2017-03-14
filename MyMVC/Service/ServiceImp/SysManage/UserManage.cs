using Common;
using Common.Enums;
using Domain;
using Service;
using Service.IService;
using Spring.Context;
using Spring.Context.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
namespace Service.ServiceImp
{
    public class UserManage : RepositoryBase<SYS_USER>, IUserManage
    {
        
        public IDepartmentManage DepartmentManage { get; set; }
        public IUserDepartmentManage UserDepartmentManage { get; set; }
        public IUserInfoManage UserInfoManage { get; set; }
        public IUserRoleManage UserRoleManage { get; set; }
        public IUserPermissionManage UserPermissionManage { get; set; }
        public IPostUserManage PostUserManage { get; set; }
        public IPermissionManage PermissionManage { get; set; }
        /// <summary>
        /// 从Cookie中获取用户信息
        /// </summary>
        public Account GetAccountByCookie()
        {
            
            var cookie = CookieHelper.GetCookie("cookie_rememberme");
            if (cookie != null)
            {
                //验证json的有效性
                if (!string.IsNullOrEmpty(cookie.Value))
                {
                    //解密
                    var cookievalue = new Common.CryptHelper.AESCrypt().Decrypt(cookie.Value);
                    //是否为json
                    if (!JsonSplit.IsJson(cookievalue)) return null;
                    try
                    {
                        var jsonFormat = Common.JsonConverter.ConvertJson(cookievalue);
                        if (jsonFormat != null)
                        {
                            var users = UserLogin(jsonFormat.username, new Common.CryptHelper.AESCrypt().Decrypt(jsonFormat.password));
                            if (users != null)
                                return GetAccountByUser(users);
                        }
                    }
                    catch { return null; }
                }
            }
            return null;
        }
        /// <summary>
        /// 根据用户构造用户基本信息
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public Account GetAccountByUser(SYS_USER users)
        {
            //IApplicationContext ctx = ContextRegistry.GetContext();

            //IDepartmentManage dal = ctx.GetObject("Service.User") as IDepartmentManage;



            if (users == null) return null;
            //用户授权--->注意用户的授权是包括角色权限与自身权限的
            var permission = GetPermissionByUser(users);
            //用户角色
            var role = users.SYS_USER_ROLE.Select(p => p.SYS_ROLE).ToList();
            //用户部门
            var dpt = users.SYS_USER_DEPARTMENT.Select(p => p.SYS_DEPARTMENT).ToList();
            //用户岗位
            var post = users.SYS_POST_USER.ToList();
            //用户主部门
            var dptInfo = DepartmentManage.Get(p => p.ID == users.DPTID);
            //用户模块
            var module = permission.Select(p => p.SYS_MODULE).ToList().Distinct(new ModuleDistinct()).ToList();
            var systemid = new List<string> { "fddeab19-3588-4fe1-83b6-c15d4abb942d", "001", "001" };
            Account account = new Account()
            {
                Id = users.ID,
                Name = users.NAME,
                LogName = users.ACCOUNT,
                PassWord = users.PASSWORD,
                IsAdmin = IsAdmin(users.ID),
                DptInfo = dptInfo,
                Dpt = dpt,
                Face_Img = users.FACE_IMG,
                Permissions = permission,
                Roles = role,
                PostUser = post,
                Modules = module,
                System_Id = systemid
            };
            return account;
        }
        /// <summary>
        /// 根据用户信息获取用户所有的权限
        /// </summary>
        private List<Domain.SYS_PERMISSION> GetPermissionByUser(Domain.SYS_USER users)
        {
            //1、超级管理员拥有所有权限
            if (IsAdmin(users.ID))
                return PermissionManage.LoadListAll(null);
            //2、普通用户，合并当前用户权限与角色权限
            var perlist = new List<Domain.SYS_PERMISSION>();
            //2.1合并用户权限
            perlist.AddRange(users.SYS_USER_PERMISSION.Select(p => p.SYS_PERMISSION).ToList());
            //2.2合同角色权限
            ////todo:经典多对多的数据查询Linq方法
            perlist.AddRange(users.SYS_USER_ROLE.Select(p => p.SYS_ROLE.SYS_ROLE_PERMISSION.Select(c => c.SYS_PERMISSION)).SelectMany(c => c.Select(e => e)).Cast<Domain.SYS_PERMISSION>().ToList());
            //3、去重
            ////todo:通过重写IEqualityComparer<T>实现对象去重
            perlist = perlist.Distinct(new PermissionDistinct()).ToList();
            return perlist;
        }
        public string GetUserDptName(int userId)
        {
            if (userId <= 0)
                return "";
            var dptid = this.Get(p => p.ID == userId).DPTID;
            return DepartmentManage.Get(p => p.ID == dptid).NAME;
            //throw new NotImplementedException();
        }

        /// <summary>
        /// 根据用户ID获取用户名
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        public string GetUserName(int userId)
        {
            var query = this.LoadAll(c => c.ID == userId);
            if (query == null || !query.Any())
             {
                 return "";
             }
             return query.First().NAME;
        }
        /// <summary>
        /// 是否是超级管理员
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        //public bool IsAdmin(int userId)
        //{
        //    SYS_USER entity = this.Get(p => p.ID == userId);
        //    if (entity == null)
        //        return false;
        //    var roles = entity.SYS_USER_ROLE.Select(p => new SYS_ROLE
        //    {
        //        ID = 1
        //        //ID = p.FK_ROLEID
        //    });
        //    return roles.ToList().Any(item => item.ID == ClsDic.DicRole["超级管理员"]);
        //}
        public bool IsAdmin(int userId)
        {
            SYS_USER sYS_USER = this.Get((SYS_USER p) => p.ID == userId);
            if (sYS_USER == null)
            {
                return false;
            }
            IEnumerable<SYS_ROLE> source =
                from p in sYS_USER.SYS_USER_ROLE
                select new SYS_ROLE
                {
                    ID = p.SYS_ROLE.ID
                };
            return source.ToList<SYS_ROLE>().Any((SYS_ROLE item) => item.ID == ClsDic.DicRole["超级管理员"]);
        }
        /// <summary>
        /// 根据用户ID删除用户相关记录
        /// 删除原则：1、删除用户档案
        ///           2、删除用户角色关系
        ///           3、删除用户权限关系
        ///           4、删除用户岗位关系
        ///           5、删除用户部门关系
        ///           6、删除用户
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool Remove(int userId)
        {
            //return true;
            try
            {
                //档案
                if (this.UserInfoManage.IsExist(p => p.USERID == userId))
                {
                    UserInfoManage.Delete(p => p.USERID == userId);
                }
                //用户角色
                if (this.UserRoleManage.IsExist(p => p.FK_USERID == userId))
                {
                    this.UserRoleManage.Delete(p => p.FK_USERID == userId);
                }
                //用户权限
                if (this.UserPermissionManage.IsExist(p => p.FK_USERID == userId))
                {
                    this.UserPermissionManage.Delete(p => p.FK_USERID == userId);
                }
                //用户岗位
                if (this.PostUserManage.IsExist(p => p.FK_USERID == userId))
                {
                    this.PostUserManage.Delete(p => p.FK_USERID == userId);
                }
                //用户部门
                if (UserDepartmentManage.IsExist(p => p.USER_ID == userId))
                {
                    this.UserDepartmentManage.Delete(p => p.USER_ID == userId);
                }
                //用户自身
                if (this.IsExist(p => p.ID == userId))
                {
                    this.Delete(p => p.ID == userId);
                }
                return true;
            }
            catch (Exception e) { throw e.InnerException; }
        }

        public SYS_USER UserLogin(string useraccount, string password)
        {
            //var entity = this.Get(p => p.ACCOUNT == useraccount);
            //this.l
            var entity = this.Get(p => p.ACCOUNT == useraccount);
            var teet = new Common.CryptHelper.AESCrypt().Decrypt(entity.PASSWORD);
            if (entity != null && new Common.CryptHelper.AESCrypt().Decrypt(entity.PASSWORD) == password)
            //if (entity != null )
            {
                //if(entity.PASSWORD.ToString() == password.ToString())
                return entity;
            }
            return null;
        }

        /// <summary>
        /// 权限去重，非常重要
        /// </summary>
        public class PermissionDistinct : IEqualityComparer<SYS_PERMISSION>
        {
            public bool Equals(SYS_PERMISSION x, SYS_PERMISSION y)
            {
                return x.ID == y.ID;
            }

            public int GetHashCode(SYS_PERMISSION obj)
            {
                return obj.ToString().GetHashCode();
            }
        }
    }
}
