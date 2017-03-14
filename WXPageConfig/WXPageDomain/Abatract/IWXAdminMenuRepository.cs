using System;
using System.Collections.Generic;
using WXPageModel;

namespace WXPageDomain.Abatract
{
    public interface IWXAdminMenuRepository : IRepository<AdminMenu>
    {
        List<AdminMenu> FindWXMenuInfo();
    }
}
