using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Newtonsoft.Json;
using WXPageBLL.Abatract;
using WXPageService.Entity;
using static WXPageService.Enums.PlatformEnums;
using WXPageService.WXHandler;
using WXPageDomain.Abatract;
using WXPageDomain.Concrete;
using WXPageModel;

namespace WXPageBLL.Concrete
{
    public class WXMenuBLL : IWXMenuBLL
    {
        private IWXMenuRepository _repository;
        public WXMenuBLL() : this(new EFWXMenuRepository()) 
        {
        }
        public WXMenuBLL(IWXMenuRepository repository)
        {
            _repository = repository;
        }


        public IQueryable<SubMenu> FindAll
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public List<SubMenu> FindAllInfo
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public List<SubMenu> WXSubMenu
        {
            get
            {
               return _repository.WXSubMenu;
            }
        }

        public void Delete(Expression<Func<SubMenu, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Delete(IEnumerable<SubMenu> entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(SubMenu entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteSubMenu(string wxAccountId)
        {
            throw new NotImplementedException();
        }

        public SubMenu GetByKey(object key)
        {
            throw new NotImplementedException();
        }

        public void Save(IEnumerable<SubMenu> entities)
        {
            throw new NotImplementedException();
        }

        public void Save(SubMenu entity)
        {
            throw new NotImplementedException();
        }
        public void SaveSubMenu(List<SubMenu> subButtons)
        {
            try
            {
                ButtonGroup bg = new ButtonGroup();
                foreach (SubMenu sub in subButtons)
                {
                    SubButton subButton = new SubButton();
                    subButton.name = sub.Name;

                    foreach (WXPageModel.SingleButton single in sub.SingleButtons)
                    {
                        ButtonType buttonType = (ButtonType)Enum.Parse(typeof(ButtonType), single.Type, true);
                        switch (buttonType)
                        {
                            ///单击按钮
                            case ButtonType.click:
                                //var te = ButtonFactory.CreateButtons(buttonType) as SingleClickButton;
                                SingleClickButton clickButton = new SingleClickButton();
                                clickButton.name = single.Name;
                                clickButton.key = single.Key;
                                subButton.sub_button.Add(clickButton);
                                break;
                            ///地理位置按钮
                            case ButtonType.location_select:
                                SingleLocationSelect locationButton = new SingleLocationSelect();
                                locationButton.name = single.Name;
                                locationButton.key = single.Key;
                                subButton.sub_button.Add(locationButton);
                                break;
                            ///弹出拍照或者相册发图
                            case ButtonType.pic_photo_or_album:
                                //ButtonFactory.CreateClickButton
                                SinglePicPhotoOrAlbum singlePicPhotoOrAlbum = new SinglePicPhotoOrAlbum();
                                singlePicPhotoOrAlbum.name = single.Name;
                                singlePicPhotoOrAlbum.key = single.Key;
                                subButton.sub_button.Add(singlePicPhotoOrAlbum);
                                break;
                            ///跳转事件
                            case ButtonType.view:
                                SingleViewButton viewButton = new SingleViewButton();
                                viewButton.name = single.Name;
                                viewButton.url = single.Key;
                                subButton.sub_button.Add(viewButton);
                                break;
                            ///扫码事件
                            case ButtonType.scancode_push:
                                //ButtonFactory.CreateClickButton
                                SingleScanCodePush scanButton = new SingleScanCodePush();
                                scanButton.name = single.Name;
                                scanButton.key = single.Key;
                                subButton.sub_button.Add(scanButton);
                                break;
                            ///相册
                            case ButtonType.pic_sysphoto:
                                SinglePicSysPhoto picButton = new SinglePicSysPhoto();
                                picButton.name = single.Name;
                                picButton.key = single.Key;
                                subButton.sub_button.Add(picButton);
                                break;
                            ///默认按钮
                            default:
                                SingleViewButton defaultButton = new SingleViewButton();
                                defaultButton.name = "有妖气漫画";
                                defaultButton.url = single.Key;
                                subButton.sub_button.Add(defaultButton);
                                break;
                        }
                    }
                    bg.button.Add(subButton);
                }
                var request = JsonConvert.SerializeObject(bg);
                var responseResult = WXMenuHandler.CreateMenu(request);
                //return Json(responseResult, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {

            }
            //try
            //{
            //    ButtonGroup bg = new ButtonGroup();
            //    SubButton subButton = new SubButton();
            //    subButton.name = "有漫画";
            //    subButton.sub_button.Add(
            //       new SingleViewButton
            //       {
            //           name = "有妖气漫画",
            //           type = PlatformEnums.ButtonType.view.ToString(),
            //           //key = "click"
            //           url = "http://www.u17.com/"
            //       }
            //       );
            //    subButton.sub_button.Add(
            //        new SingleClickButton
            //        {
            //            name = "后台设置",
            //            key = "OneClick",
            //            type = PlatformEnums.ButtonType.click.ToString()
            //        }
            //        );
            //    subButton.sub_button.Add(
            //        new SingleViewButton
            //        {
            //            name = "瞧一瞧",
            //            type = PlatformEnums.ButtonType.view.ToString(),
            //            url = "http://baidu.com"
            //        }
            //        );
            //    SubButton subButton2 = new SubButton();
            //    subButton2.name = "明日要闻";
            //    subButton2.sub_button.Add(
            //        new SingleLocationSelect
            //        {
            //            name = "地理位置",
            //            key = "OneClick",
            //            type = PlatformEnums.ButtonType.location_select.ToString()
            //        }
            //        );
            //    subButton2.sub_button.Add(
            //        new SinglePicPhotoOrAlbum
            //        {
            //            name = "拍照",
            //            type = PlatformEnums.ButtonType.pic_sysphoto.ToString(),
            //            key = "click"
            //            //url = "http://baidu.com"
            //        }
            //        );
            //    SubButton subButton3 = new SubButton();
            //    subButton3.name = "后日要闻";
            //    subButton3.sub_button.Add(
            //        new SinglePicWeixin
            //        {
            //            name = "打开相册",
            //            key = "OneClick",
            //            type = PlatformEnums.ButtonType.pic_photo_or_album.ToString()
            //        }
            //        );
            //    subButton3.sub_button.Add(
            //        new SingleClickButton
            //        {
            //            name = "啦啦啦，逗你玩",
            //            type = PlatformEnums.ButtonType.click.ToString(),
            //            key = "click"
            //            //url = "http://baidu.com"
            //        }
            //        );
            //    subButton3.sub_button.Add(
            //        new SingleClickButton
            //        {
            //            name = "贱人快开门",
            //            type = PlatformEnums.ButtonType.pic_photo_or_album.ToString(),
            //            key = "click"
            //            //url = "http://baidu.com"
            //        }
            //        );

            //    //subButton.
            //    bg.button.Add(subButton);
            //    bg.button.Add(subButton2);
            //    bg.button.Add(subButton3);
            //    var request = JsonConvert.SerializeObject(bg);
            //    var responseResult = WXMessageHandler.CreateMenu(request);
            //    return Json(responseResult, JsonRequestBehavior.AllowGet);
            //}
            //catch (Exception ex)
            //{
            //    var json = new { Success = false, Message = ex.Message };
            //    return Json(json, JsonRequestBehavior.AllowGet);
            //}
            //throw new NotImplementedException();
        }
    }
}
