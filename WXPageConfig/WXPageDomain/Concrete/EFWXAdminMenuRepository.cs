using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WXPageDomain.Abatract;
using WXPageModel;

namespace WXPageDomain.Concrete
{
    public class EFWXAdminMenuRepository : BaseRepository<AdminMenu>, IWXAdminMenuRepository
    {
        public static List<AdminMenu> AdminMenuList = new List<AdminMenu>()
        {
            new AdminMenu {Id="111",Name="微信功能菜单",ParentId="0",Info="添加微信功能菜单",Icon="icon-home", Type="wx",Url="",Permission="",State="Normal",InsertTime=DateTime.Now },
            new AdminMenu {Id="001",Name="基础设置",ParentId="0",Info="添加基础设置",Type="wx",Icon="icon-cog", Url="",Permission="",State="Normal",InsertTime=DateTime.Now },
            new AdminMenu {Id="002",Name="首次关注",ParentId="001",Info="添加首次关注",Type="wx",Url="/Message/FirstResponse",Permission="",State="Normal",InsertTime=DateTime.Now },
            new AdminMenu {Id="003",Name="默认回复",ParentId="001",Info="添加默认回复",Type="wx",Url="/Message/DefaultResponse",Permission="",State="Normal",InsertTime=DateTime.Now },
            new AdminMenu {Id="004",Name="关键字回复",ParentId="001",Info="添加关键字回复",Type="wx",Url="/Message/KeyWord",Permission="",State="Normal",InsertTime=DateTime.Now },
            new AdminMenu {Id="005",Name="图文回复",ParentId="001",Info="添加图文回复",Type="wx",Url="/Home/Index",Permission="",State="Normal",InsertTime=DateTime.Now },
            new AdminMenu {Id="006",Name="视频回复",ParentId="001",Info="添加视频回复",Type="wx",Url="/Home/Contact",Permission="",State="Normal",InsertTime=DateTime.Now },
            new AdminMenu {Id="007",Name="位置回复",ParentId="001",Info="添加位置回复",Type="wx",Url="/Home/Index",Permission="",State="Normal",InsertTime=DateTime.Now },


            new AdminMenu {Id="008",Name="菜单服务",ParentId="0",Info="添加菜单服务",Type="wx",Icon="icon-th-list", Url="",Permission="",State="Normal",InsertTime=DateTime.Now },
            new AdminMenu {Id="009",Name="获取菜单",ParentId="008",Info="添加菜单服务",Type="wx",Url="/Menu/GetMenu",Permission="",State="Normal",InsertTime=DateTime.Now },
            new AdminMenu {Id="010",Name="自定义菜单",ParentId="008",Info="添加自定义菜单",Type="wx",Url="/Menu/CreateMenu",Permission="",State="Normal",InsertTime=DateTime.Now },

            new AdminMenu {Id="011",Name="账号管理",ParentId="0",Info="添加账号管理",Type="wx",Icon="icon-volume-up", Url="",Permission="",State="Normal",InsertTime=DateTime.Now },
            new AdminMenu {Id="012",Name="获取菜单",ParentId="011",Info="添加菜单服务",Type="wx",Url="~/Menu/GetMenu",Permission="",State="Normal",InsertTime=DateTime.Now },
            new AdminMenu {Id="013",Name="自定义菜单",ParentId="011",Info="添加自定义菜单",Type="wx",Url="~/Menu/CreateMenu",Permission="",State="Normal",InsertTime=DateTime.Now },
        };

        /// <summary>
        /// 查询微信菜单
        /// </summary>
        /// <returns></returns>
        public List<AdminMenu> FindWXMenuInfo()
        {
            return AdminMenuList;
        }

        public IQueryable<AdminMenu> FindAll
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        /// <summary>
        /// 查询所有数据
        /// </summary>
        public List<AdminMenu> FindAllInfo
        {
            get
            {
                return AdminMenuList;
            }
        }

        public void Delete(Expression<Func<AdminMenu, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Delete(IEnumerable<AdminMenu> entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(AdminMenu entity)
        {
            throw new NotImplementedException();
        }

        public void Save(IEnumerable<AdminMenu> entities)
        {
            throw new NotImplementedException();
        }

        public void Save(AdminMenu entity)
        {
            throw new NotImplementedException();
        }

        AdminMenu IRepository<AdminMenu>.GetByKey(object key)
        {
            throw new NotImplementedException();
        }
    }
}
