using System.Collections.Generic;
using WXPageModel;

namespace WXPageDomain.Abatract
{
    public interface IWXMenuRepository: IRepository<SubMenu>
    {

        List<SubMenu> WXSubMenu { get; }
        void SaveSubMenu(List<SubMenu> subButtons);
        void DeleteSubMenu(string wxAccountId);
    }
}
