using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    /// <summary>
    /// 岗位用户关系业务接口
    /// </summary>
    public interface IPostUserManage : IRepository<SYS_POST_USER>
    {
        /// <summary>
        /// 根据岗位Id获取人员集合，
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        List<SYS_USER> GetUserListByPostId(string postId);
        /// <summary>
        /// 根据人员获取岗位集合
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        List<SYS_POST> GetPostListByUserId(string userId);
        /// <summary>
        /// 添加岗位人员关系
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="postId"></param>
        /// <returns></returns>
        bool SavePostUser(int userId, string postId);
        /// <summary>
        /// 根据岗位集合获取岗位名称，部门-岗位模式
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        dynamic GetPostNameBySysPostUser(ICollection<SYS_POST_USER> collection);
    }
}
