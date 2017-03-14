﻿using Domain;
using Service.IService;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceImp
{
    /// <summary>
    /// 授权模块关系处理
    /// </summary>
    public class PermissionManage : RepositoryBase<SYS_PERMISSION>, IPermissionManage
    {
        /// <summary>
        /// 根据系统ID获取所有权限ID集合
        /// </summary>
        /// <param name="sysId"></param>
        /// <returns></returns>
        public List<int> GetPermissionIdBySysId(string sysId)
        {
            try
            {
                string sql = "select p.id from sys_permission p where exists(select 1 from sys_module t where t.fk_belongsystem=@sysid and t.id=p.moduleid)";
                 DbParameter para = new SqlParameter("@sysid", sysId);
                return this.SelectBySql<int>(sql, para);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
