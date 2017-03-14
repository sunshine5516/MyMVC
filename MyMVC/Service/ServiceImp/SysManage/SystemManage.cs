﻿using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceImp
{
    public class SystemManage : RepositoryBase<SYS_SYSTEM>, IService.ISystemManage
    {
        /// <summary>
        ///// 获取系统ID、NAME
        /// </summary>
        /// <param name="systems">用户拥有操作权限的系统</param>
        /// <returns></returns>
        public dynamic LoadSystemInfo(List<string> systems)
        {
            return Common.JsonConverter.JsonClass(this.LoadAll(p => systems.Any(e => e == p.ID)).Select(p => new { p.ID, p.NAME }).ToList());
        }
    }
}
