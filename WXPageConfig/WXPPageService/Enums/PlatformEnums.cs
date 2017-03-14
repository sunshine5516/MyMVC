using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WXPageService.Enums
{
    public class PlatformEnums
    {
        /// <summary>
        /// 错误返回码
        /// </summary>
        public enum ResponseCode
        {

            系统繁忙此时请开发者稍候再试 = -1,
            请求成功 = 0,
            获取access_token时AppSecret错误或者access_token无效 = 40001,
            不合法的凭证类型 = 40002,
            不合法的OpenID = 40003,
            不合法的媒体文件类型 = 40004,
            不合法的文件类型 = 40005,
            不合法的文件大小 = 40006,
            不合法的媒体文件id = 40007,
            不合法的消息类型 = 40008,
            不合法的图片文件大小 = 40009,
            不合法的语音文件大小 = 40010,
            不合法的视频文件大小 = 40011,
            不合法的缩略图文件大小 = 40012,
            不合法的APPID = 40013,
            不合法的access_token = 40014,
            不合法的菜单类型 = 40015,
            不合法的按钮个数1 = 40016,
            不合法的按钮个数2 = 40017,
            不合法的按钮名字长度 = 40018,
            不合法的按钮KEY长度 = 40019,
            不合法的按钮URL长度 = 40020,
            不合法的菜单版本号 = 40021,
            不合法的子菜单级数 = 40022,
            不合法的子菜单按钮个数 = 40023,
            不合法的子菜单按钮类型 = 40024,
            不合法的子菜单按钮名字长度 = 40025,
            不合法的子菜单按钮KEY长度 = 40026,
            不合法的子菜单按钮URL长度 = 40027,
            不合法的自定义菜单使用用户 = 40028,
            不合法的oauth_code = 40029,
            不合法的refresh_token = 40030,
            不合法的openid列表 = 40031,
            不合法的openid列表长度 = 40032,
            不合法的请求字符不能包含uxxxx格式的字符 = 40033,
            不合法的参数 = 40035,
            不合法的请求格式 = 40038,
            不合法的URL长度 = 40039,
            不合法的分组id = 40050,
            分组名字不合法 = 40051,
            缺少access_token参数 = 41001,
            缺少appid参数 = 41002,
            缺少refresh_token参数 = 41003,
            缺少secret参数 = 41004,
            缺少多媒体文件数据 = 41005,
            缺少media_id参数 = 41006,
            缺少子菜单数据 = 41007,
            缺少oauth_code = 41008,
            缺少openid = 41009,
            access_token超时 = 42001,
            refresh_token超时 = 42002,
            oauth_code超时 = 42003,
            需要GET请求 = 43001,
            需要POST请求 = 43002,
            需要HTTPS请求 = 43003,
            需要接收者关注 = 43004,
            需要好友关系 = 43005,
            多媒体文件为空 = 44001,
            POST的数据包为空 = 44002,
            图文消息内容为空 = 44003,
            文本消息内容为空 = 44004,
            多媒体文件大小超过限制 = 45001,
            消息内容超过限制 = 45002,
            标题字段超过限制 = 45003,
            描述字段超过限制 = 45004,
            链接字段超过限制 = 45005,
            图片链接字段超过限制 = 45006,
            语音播放时间超过限制 = 45007,
            图文消息超过限制 = 45008,
            接口调用超过限制 = 45009,
            创建菜单个数超过限制 = 45010,
            回复时间超过限制 = 45015,
            系统分组不允许修改 = 45016,
            分组名字过长 = 45017,
            分组数量超过上限 = 45018,
            不存在媒体数据 = 46001,
            不存在的菜单版本 = 46002,
            不存在的菜单数据 = 46003,
            解析JSON_XML内容错误 = 47001,
            api功能未授权 = 48001,
            用户未授权该api = 50001,
            参数错误invalid_parameter = 61451,
            无效客服账号invalid_kf_account = 61452,
            客服帐号已存在kf_account_exsited = 61453,
            /// <summary>
            /// 客服帐号名长度超过限制(仅允许10个英文字符，不包括@及@后的公众号的微信号)(invalid kf_acount length)
            /// </summary>
            客服帐号名长度超过限制 = 61454,
            /// <summary>
            /// 客服帐号名包含非法字符(仅允许英文+数字)(illegal character in kf_account)
            /// </summary>
            客服帐号名包含非法字符 = 61455,
            /// <summary>
            ///  	客服帐号个数超过限制(10个客服账号)(kf_account count exceeded)
            /// </summary>
            客服帐号个数超过限制 = 61456,
            无效头像文件类型invalid_file_type = 61457,
            系统错误system_error = 61450,
            日期格式错误 = 61500,
            日期范围错误 = 61501,

            //新加入的一些类型，以下文字根据P2P项目格式组织，非官方文字
            //发送消息失败_48小时内用户未互动 = 10706,
            //发送消息失败_该用户已被加入黑名单_无法向此发送消息 = 62751,
            //发送消息失败_对方关闭了接收消息 = 10703,
            //对方不是粉丝 = 10700
        }
        /// <summary>
        /// 按钮类型
        /// </summary>
        public enum ButtonType
        {
            /// <summary>
            /// 点击事件
            /// </summary>
            click,
            /// <summary>
            /// 跳转URL
            /// </summary>
            view,
            /// <summary>
            /// 扫码事件
            /// </summary>
            scancode_push,
            /// <summary>
            /// 扫码推事件且弹出“消息接收中”提示框
            /// </summary>
            scancode_waitmsg,
            /// <summary>
            /// 弹出系统拍照发图
            /// </summary>
            pic_sysphoto,
            /// <summary>
            /// 弹出拍照或者相册发图
            /// </summary>
            pic_photo_or_album,
            /// <summary>
            /// 弹出地理位置选择器
            /// </summary>
            location_select,
            /// <summary>
            /// 下发消息（除文本消息）
            /// </summary>
            media_id,
            /// <summary>
            /// 跳转图文消息URL
            /// </summary>
            view_limited
        }
        /// <summary>
        /// 文本请求类型
        /// </summary>
        public enum RequestMsgType
        {
            /// <summary>
            /// 文本消息
            /// </summary>
            Text,
            /// <summary>
            /// 图片消息
            /// </summary>
            Image,
            /// <summary>
            /// 语音消息
            /// </summary>
            Voice,
            /// <summary>
            /// 视频消息
            /// </summary>
            Video,
            /// <summary>
            /// 小视频消息
            /// </summary>
            Shortvideo,
            /// <summary>
            /// 地理位置
            /// </summary>
            Location,
            /// <summary>
            ///链接消息
            /// </summary>
            Link,
            /// <summary>
            /// 事件
            /// </summary>
            Event,
        }
        /// <summary>
        /// 响应文本类型
        /// </summary>
        public enum ResponseMsgType
        {
            [Description("文本")]
            Text = 0,
            [Description("图片")]
            Image = 1,
            [Description("语音")]
            Voice = 2,
            [Description("视频")]
            Video = 3,
            [Description("音乐")]
            Music = 4,
            [Description("图文")]
            News = 5,
        }
        /// <summary>
        /// 当RequestMsgType类型为Event时，Event属性的类型
        /// </summary>
        public enum Event
        {
            /// <summary>
            /// 订阅事件
            /// </summary>
            subscribe,
            /// <summary>
            /// 取消订阅事件
            /// </summary>
            unsubscribe,
            /// <summary>
            /// 扫描带参数二维码事件
            /// 用户已关注时的事件推送
            /// 用户扫描带场景值二维码时，可能推送以下两种事件：
            /// 如果用户还未关注公众号，则用户可以关注公众号，关注后微信会将带场景值关注事件推送给开发者。
            /// 如果用户已经关注公众号，则微信会将带场景值扫描事件推送给开发者。
            /// </summary>
            SCAN,
            /// <summary>
            /// 上报地理位置事件
            /// 用户同意上报地理位置后，每次进入公众号会话时，都会在进入时上报地理位置，
            /// 或在进入会话后每5秒上报一次地理位置，公众号可以在公众平台网站中修改以上设置。
            /// 上报地理位置时，微信会将上报地理位置事件推送到开发者填写的URL。
            /// </summary>
            LOCATION,
            /// <summary>
            /// 用户点击自定义菜单后，微信会把点击事件推送给开发者，请注意，点击菜单弹出子菜单，不会产生上报。
            /// 点击菜单拉取消息时的事件推送
            /// </summary>
            CLICK,
            /// <summary>
            /// 点击菜单跳转链接时的事件推送
            /// </summary>
            VIEW,
        }
        /// <summary>
        /// 请求的URL路径
        /// </summary>
        public enum Url
        {
           //e= "https://open.weixin.qq.com/connect/oauth2/authorize?"
                
        }
        /// <summary>
        /// 身份认证类型
        /// </summary>
        public enum scope
        {

        }
    }
}
