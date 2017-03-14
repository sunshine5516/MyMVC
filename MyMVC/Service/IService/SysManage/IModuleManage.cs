using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    /// <summary>
    /// 
    /// </summary>
    public interface IModuleManage : IRepository<SYS_MODULE>
    {
        /// <summary>
        /// 根据系统获取模块集合
        /// </summary>
        /// <param name="sysId"></param>
        /// <returns></returns>
        List<SYS_MODULE> GetModuleBySysId(string sysId);
        /// <summary>
        /// 获取用户权限模块集合
        /// add yuangang by 2015-05-30
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="permission">用户授权集合</param>
        /// <param name="siteId">站点ID</param>
        /// <returns></returns>
        List<SYS_MODULE> GetModule(int userId, List<SYS_PERMISSION> permission, List<string> siteId);
        /// <summary>
        /// 递归模块列表，返回按级别排序
        /// add yuangang by 2015-06-03
        /// </summary>
        List<SYS_MODULE> RecursiveModule(List<SYS_MODULE> list);

        /// <summary>
        /// 批量变更当前模块下其他模块的级别
        /// </summary>
        bool MoreModifyModule(int moduleId, int levels);
    }
}
