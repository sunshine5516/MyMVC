using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    /// <summary>
    /// 用户部门关系接口
    /// </summary>
    public interface IUserDepartmentManage : IRepository<SYS_USER_DEPARTMENT>
    {
        /// <summary>
        /// 根据部门ID获取部门所有人员信息
        /// </summary>
        /// <param name="dptId"></param>
        /// <returns></returns>
        List<SYS_USER> GetUserListByDptId(List<string> dptId);
        /// <summary>
        /// 根据用户ID获取所在的部门集合
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        List<SYS_DEPARTMENT> GetDptListByUserId(int userId);
        /// <summary>
        ///  保存用户部门关系
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="dptId"></param>
        /// <returns></returns>
        bool SaveUserDpt(int userId, string dptId);
    }
}
