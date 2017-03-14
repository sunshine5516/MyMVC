﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Service.IService;
using Domain;

namespace Service.ServiceImp
{
    /// <summary>
    /// Service层角色授权关系接口
    /// </summary>
    public class RolePermissionManage : RepositoryBase<SYS_ROLE_PERMISSION>, IRolePermissionManage
    {
        IPermissionManage PermissionManage { get; set; }
        /// <summary>
        /// 保存角色权限
        /// </summary>
        public bool SetRolePermission(int roleId, string newper, string sysId)
        {
            try
            {
                //1、获取当前系统的模块ID集合
                var permissionId = this.PermissionManage.GetPermissionIdBySysId(sysId).Cast<int>().ToList();
                //2、获取角色权限，是否存在，存在即删除，只删除当前选择的系统
                if (this.IsExist(p => p.ROLEID == roleId && permissionId.Any(e => e == p.PERMISSIONID)))
                {
                    //3、删除角色权限
                    this.Delete(p => p.ROLEID == roleId && permissionId.Any(e => e == p.PERMISSIONID));
                }
                //4、添加角色权限
                if (string.IsNullOrEmpty(newper)) return true;
                //Trim 保证数据安全
                var str = newper.Trim(',').Split(',');
                foreach (var per in str.Select(t => new Domain.SYS_ROLE_PERMISSION()
                {
                    PERMISSIONID = int.Parse(t),
                    ROLEID = roleId
                }))
                {
                    this.dbSet.Add(per);
                }
                //5、Save
                return this.Context.SaveChanges() > 0;
            }
            catch (Exception e) { throw e.InnerException; }
        }
        public bool SetRolePermission(int roleId, string newper)
        {
            try
            {
                //4、添加角色权限
                if (string.IsNullOrEmpty(newper)) return true;
                //Trim 保证数据安全
                var str = newper.Trim(',').Split(',');
                foreach (var per in str.Select(t => new Domain.SYS_ROLE_PERMISSION()
                {
                    PERMISSIONID = int.Parse(t),
                    ROLEID = roleId
                }))
                {
                    this.dbSet.Add(per);
                }
                //5、Save
                return this.Context.SaveChanges() > 0;
            }
            catch (Exception e) { throw e.InnerException; }
        }
    }
}