using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WXPageService.Entity;
using static WXPageService.Enums.PlatformEnums;

namespace WXPageService
{
    /// <summary>
    /// 按钮工厂类
    /// </summary>
    public class ButtonFactory
    {
        public static BaseButton CreateButtons(ButtonType buttonType)
        {
            //BaseButton baseButton = null;
            try
            {
                switch (buttonType)
                {
                    //
                    case ButtonType.click:
                        //responseMsg = new ResponseMessageText();
                        //return CreateClickButton();
                        return new SingleClickButton();
                        break;
                    case ButtonType.location_select:
                        return new SingleLocationSelect();
                        break;
                    case ButtonType.media_id:
                        return new SingleMediaId();
                        break;
                    case ButtonType.pic_photo_or_album:
                        return new SinglePicPhotoOrAlbum();
                        break;
                    case ButtonType.pic_sysphoto:
                        return new SinglePicSysPhoto();
                        break;
                    case ButtonType.scancode_push:
                        return new SingleScanCodePush();
                        break;
                    case ButtonType.scancode_waitmsg:
                        return new SingleScanCodeWaitmsg();
                        break;
                    case ButtonType.view:
                        return new SingleViewButton();
                        break;
                    case ButtonType.view_limited:
                        return new SingleViewLlimited();
                        break;
                    default:
                        return new SingleClickButton();
                        break;
                }
            }
            catch (Exception ex)
            {
                return new BaseButton();
            }
            //return baseButton;
        }
        ///// <summary>
        ///// 创建单击按钮
        ///// </summary>
        ///// <returns></returns>
        //private static  SingleClickButton CreateClickButton()
        //{
        //    return new SingleClickButton();
        //}
        //private static SingleLocationSelect SingleLocationSelect()
        //{
        //    return new SingleLocationSelect();
        //}
        //private static SingleMediaId CreateSingleMedia()
        //{
        //    return new SingleMediaId();
        //}
        //private static 
        
    }

}
