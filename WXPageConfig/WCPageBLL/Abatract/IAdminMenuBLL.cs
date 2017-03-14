using System;
using System.Collections.Generic;
using WXPageModel;

namespace WXPageBLL.Abatract
{
    public interface IAdminMenuBLL : IBLL<AdminMenu>
    {
        void ConfigMenu(List<AdminMenu> adminMenuList);
    }
}
