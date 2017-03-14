using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.IService
{
    /// <summary>
    /// Service层角色授权关系接口
    /// </summary>
    public interface IRolePermissionManage : IRepository<Domain.SYS_ROLE_PERMISSION>
    {
        /// <summary>
        /// 保存角色权限
        /// </summary>
        /// <param name="roleId">角色ID</param>
        /// <param name="newper">权限字符串</param>
        /// <param name="sysId">系统ID</param>
        /// <returns></returns>
        bool SetRolePermission(int roleId, string newper, string sysId);
        bool SetRolePermission(int roleId, string newper);
    }
}