using System;
using System.Collections.Generic;
using WXPageModel;

namespace WXPageBLL.Abatract
{
    /// <summary>
    /// 菜单业务处理
    /// </summary>
    public interface IWXMenuBLL:IBLL<SubMenu>
    {
        void SaveSubMenu(List<SubMenu> subButtons);

        List<SubMenu> WXSubMenu { get; }
        void DeleteSubMenu(string wxAccountId);
    }
}
