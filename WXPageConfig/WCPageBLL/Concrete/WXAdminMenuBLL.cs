using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WXPageBLL.Abatract;
using WXPageDomain.Abatract;
using WXPageDomain.Concrete;
using WXPageDomain.Models;
using WXPageModel;

namespace WXPageBLL.Concrete
{
    public class WXAdminMenuBLL : IAdminMenuBLL
    {

        private IWXAdminMenuRepository _repository;
        public WXAdminMenuBLL() : this(new EFWXAdminMenuRepository()) 
        {
        }
        public WXAdminMenuBLL(IWXAdminMenuRepository repository)
        {
            _repository = repository;
        }

        public IQueryable<AdminMenu> FindAll
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public List<AdminMenu> FindAllInfo
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        /// <summary>
        /// 拼接菜单
        /// </summary>
        /// <param name="adminMenuList"></param>
        public AdminMenuConfig ConfigMenu()
        {
            AdminMenuConfig adminMenuConfig = new AdminMenuConfig();
            List<AdminMenu> adminMenuList = _repository.FindWXMenuInfo();
            var tempAdminMenuGroups = adminMenuList.Where(p => p.ParentId == "0").ToList();
            ///一级菜单
            List<AdminMenuGroup> AdminMenuGroups = new List<AdminMenuGroup>();
            ///二级菜单
            List<AdminMenu> AdminMenuArray=new List<AdminMenu>();
            //AdminMenuGroup[] groups = new AdminMenuGroup[tempAdminMenuGroups.Count];
            foreach (AdminMenu menu in adminMenuList)
            {
                if (menu.ParentId != "0")
                {
                    AdminMenuArray.Add(menu);
                }
                else
                {
                    AdminMenuGroup group = new AdminMenuGroup {
                        Id = menu.Id,
                        Info=menu.Info,
                        Name=menu.Name,
                        Url=menu.Url,
                        Permission=menu.Permission,
                        Icon=menu.Icon
                    };
                    AdminMenuGroups.Add(group);
                }
            }
            foreach (AdminMenuGroup group in AdminMenuGroups)
            {
                List<AdminMenu> tempAdminMenuArray = new List<AdminMenu>();
                foreach (AdminMenu menu in AdminMenuArray)
                {
                    if (menu.ParentId == group.Id)
                    {
                        tempAdminMenuArray.Add(menu);
                    }
                }
                group.AdminMenuArray = tempAdminMenuArray;
            }
            adminMenuConfig.AdminMenuGroups = AdminMenuGroups;
            //throw new NotImplementedException();
            return adminMenuConfig;
        }

        public void ConfigMenu(List<AdminMenu> adminMenuList)
        {
            throw new NotImplementedException();
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

        public AdminMenu GetByKey(object key)
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
    }
}
