using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    /// <summary>
    /// 用户与角色关系接口
    /// </summary>
    public interface IUserRoleManage : IRepository<SYS_USER_ROLE>
    {
        bool SetUserRole(int UserId,string RoleId);
    }
}
