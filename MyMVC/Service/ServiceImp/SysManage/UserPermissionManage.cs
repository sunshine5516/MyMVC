using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Service.IService;

namespace Service.ServiceImp
{
    class UserPermissionManage : RepositoryBase<SYS_USER_PERMISSION>, IUserPermissionManage
    {
        IPermissionManage PermissionManage { get; set; }
        /// <summary>
        /// 设置用户权限
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="newper">权限字符串</param>
        /// <param name="sysId">系统ID</param>
        /// <returns></returns>
        public bool SetUserPermission(int userId, string newper, string sysId)
        {
            try
            {
                ///1、获取当前系统的模块ID集合
                var permissionId = this.PermissionManage.GetPermissionIdBySysId(sysId).Cast<int>().ToList();
                ///2、获取用户权限，是否存在，存在即删除
                if (this.IsExist(p => p.FK_USERID == userId && permissionId.Any(e => e == p.FK_PERMISSIONID)))
                {
                    ///3、删除用户权限
                    this.Delete(p => p.FK_USERID == userId && permissionId.Any(e => e == p.FK_PERMISSIONID));
                }
                ///4、添加用户权限
                var str = newper.Trim(',').Split(',');
                foreach (var per in str.Select(t => new SYS_USER_PERMISSION()
                {
                    FK_USERID = userId,
                    FK_PERMISSIONID = int.Parse(t)
                }
                ))
                {
                    this.dbSet.Add(per);
                }
                ///5.save
                return this.Context.SaveChanges()>0 ;

            }
            catch (Exception e)
            {
                throw e;
            }
            throw new NotImplementedException();
        }
        public bool SetUserPermission(int userId, string newper)
        {
            try
            {
                ///4、添加用户权限
                var str = newper.Trim(',').Split(',');
                foreach (var per in str.Select(t => new SYS_USER_PERMISSION()
                {
                    FK_USERID = userId,
                    FK_PERMISSIONID = int.Parse(t)
                }
                ))
                {
                    this.dbSet.Add(per);
                }
                ///5.save
                return this.Context.SaveChanges() > 0;

            }
            catch (Exception e)
            {
                throw e;
            }
            throw new NotImplementedException();
        }
    }
}
