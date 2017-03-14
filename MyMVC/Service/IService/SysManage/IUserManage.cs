using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface IUserManage : IRepository<SYS_USER>
    {
        /// <summary>
        /// 管理员用户登陆验证，并返回用户的信息与权限集合
        /// </summary>
        /// <param name="username">用户账号</param>
        /// <param name="password">用户密码</param>
        /// <returns></returns>
        SYS_USER UserLogin(string useraccount, string password);
        /// <summary>
        /// 是否是管理员
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        bool IsAdmin(int userId);
        /// <summary>
        /// 根据用户ID返回用户名
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        string GetUserName(int userId);
        /// <summary>
        /// 根据用户ID获取本部门名称
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        string GetUserDptName ( int userId);
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        bool Remove(int userId);
        /// <summary>
        /// 根据用户构造用户基本信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Account GetAccountByUser(SYS_USER user);
        /// <summary>
        /// 从Cookie获取用户信息
        /// </summary>
        /// <returns></returns>
        Account GetAccountByCookie();
    }
}
