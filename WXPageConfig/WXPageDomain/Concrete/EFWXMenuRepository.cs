using System;
using System.Collections.Generic;
using WXPageDomain.Abatract;
//using Newtonsoft.Json;
using WXPageModel;

namespace WXPageDomain.Concrete
{
    public class EFWXMenuRepository : BaseRepository<SubMenu>, IWXMenuRepository
    {
        public static List<SingleButton> ListSingleButton = new List<SingleButton>()
        {
            new SingleButton { Id="001",SubMenuId="001",Name="欢迎关注",Index=1,InsertTime=DateTime.Now,State="Normal",Type="click",Key="",Url=""},
            new SingleButton { Id="002",SubMenuId="001",Name="关于我们",Index=2,InsertTime=DateTime.Now,State="Normal",Type="view",Key="",Url="www.baidu.com"},
            new SingleButton { Id="003",SubMenuId="001",Name="扫一扫",Index=3,InsertTime=DateTime.Now,State="Normal",Type="scancode_push",Key="",Url=""},
            new SingleButton { Id="004",SubMenuId="001",Name="拍照",Index=4,InsertTime=DateTime.Now,State="Normal",Type="pic_sysphoto",Key="",Url=""},
            new SingleButton { Id="005",SubMenuId="001",Name="地理位置",Index=5,InsertTime=DateTime.Now,State="Normal",Type="location_select",Key="",Url=""}
        };
        public static List<SingleButton> ListSingleButton1 = new List<SingleButton>()
        {
            new SingleButton { Id="001",SubMenuId="002",Name="今日公告",Index=1,InsertTime=DateTime.Now,State="Normal",Type="click",Key="",Url=""},
            new SingleButton { Id="002",SubMenuId="002",Name="战网位置",Index=2,InsertTime=DateTime.Now,State="Normal",Type="view",Key="",Url="www.baidu.com"},
            new SingleButton { Id="003",SubMenuId="002",Name="门前雪",Index=3,InsertTime=DateTime.Now,State="Normal",Type="scancode_push",Key="",Url=""},
            new SingleButton { Id="004",SubMenuId="002",Name="风暴英雄",Index=4,InsertTime=DateTime.Now,State="Normal",Type="pic_sysphoto",Key="",Url=""},
            new SingleButton { Id="005",SubMenuId="002",Name="伊利丹",Index=5,InsertTime=DateTime.Now,State="Normal",Type="location_select",Key="",Url=""}
        };
        public static List<SingleButton> ListSingleButton2 = new List<SingleButton>()
        {
            new SingleButton { Id="001",SubMenuId="003",Name="刀锋女王",Index=1,InsertTime=DateTime.Now,State="Normal",Type="click",Key="",Url="http://www.u17.com/"},
            new SingleButton { Id="002",SubMenuId="003",Name="山丘之王",Index=2,InsertTime=DateTime.Now,State="Normal",Type="view",Key="",Url="http://www.u17.com/"},
        };
        public static List<SubMenu> ListSubMenu = new List<SubMenu>()
        {
           //new SubMenu {ID="001",WXAccountID="001",InsertTime=DateTime.Now,State="Normal",Name="关于我们",SingleButtons= ListSingleButton },
           new SubMenu {ID="002",WXAccountID="001",InsertTime=DateTime.Now,State="Normal",Name="关于他们",SingleButtons= ListSingleButton1 },
           new SubMenu {ID="003",WXAccountID="001",InsertTime=DateTime.Now,State="Normal",Name="关于风暴",SingleButtons= ListSingleButton2 }
        };
        public List<SubMenu> WXSubMenu
        {
            get
            {
                return ListSubMenu;
            }
        }

        public void DeleteSubMenu(string wxAccountId)
        {
            throw new NotImplementedException();
        }

        public void SaveSubMenu(List<SubMenu> subButtons)
        {
            throw new NotImplementedException();
        }
    }
}
