using Domain;
using Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceImp
{
    public class UserRoleManage : RepositoryBase<SYS_USER_ROLE>, IUserRoleManage
    {
        /// <summary>
        /// 设置用户角色
        /// </summary>
        /// <param name="UserId">用户ID</param>
        /// <param name="RoleId">角色ID</param>
        /// <returns></returns>
        public bool SetUserRole(int UserId, string RoleId)
        {
            try
            {
                ///删除用户角色
                this.Delete(p => p.FK_USERID == UserId);
                if (string.IsNullOrEmpty(RoleId))
                {
                    return true;
                }
                foreach (var entity in RoleId.Split(',').Select(t => new SYS_USER_ROLE()
                {
                    FK_USERID = UserId,
                    FK_ROLEID = int.Parse(t)
                }
                ))
                {
                    this.dbSet.Add(entity);
                }
                return this.Context.SaveChanges() > 0;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
