using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    /// <summary>
    /// Service 授权验证模块对应接口
    /// </summary>
    public interface ISystemManage : IRepository<SYS_SYSTEM>
    {
        /// <summary>
        /// 获取系统ID、NAME
        /// </summary>
        /// <param name="systems">用户拥有操作权限的系统</param>
        /// <returns></returns>
        dynamic LoadSystemInfo(List<string> systems);
    }
}
