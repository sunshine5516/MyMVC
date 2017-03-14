using Common;
using Domain;
using Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;

namespace WebPage.Areas.SysManage.Controllers
{
    public class CodeAreaController : Controller
    {
        #region 声明容器
        ///// <summary>
        ///// 省市区管理
        ///// </summary>
        ICodeAreaManage CodeAreaManage { get; set; }
        #endregion
        // GET: SysManage/CodeArea
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Prov()
        {
            JsonHelper jsonHelper = new JsonHelper
            {
                Status = "y",
                Msg = "Success"
            };
           
            jsonHelper.Data = HttpRuntime.Cache["AreaCode"]; //首先从缓存中取值！返回的是一个object类型的值
            if (jsonHelper.Data == null)
            {
                SqlCacheDependency dep = new SqlCacheDependency( "SqlConnectionString", "SYS_CODE_AREA");  //Test对应配置项的缓存配置key ，后面是数据库表名
                jsonHelper.Data = JsonConverter.Serialize(this.CodeAreaManage.LoadListAll((SYS_CODE_AREA p) => (int)p.LEVELS == 0), false);
                //HttpRuntime.Cache.Insert("AreaCode", jsonHelper.Data, dep, DateTime.Now.AddMinutes(1), TimeSpan.Zero);//将查询到的值在存入缓存中
                CacheHelper.SetCache("AreaCode", jsonHelper.Data, dep, DateTime.Now.AddMinutes(1), TimeSpan.Zero);//将查询到的值在存入缓存中
            }
            
            return base.Json(jsonHelper);
        }
        public ActionResult City(int id)
        {
            JsonHelper jsonHelper = new JsonHelper
            {
                Status = "y",
                Msg = "Success"
            };
            if (string.IsNullOrEmpty(id.ToString()))
            {
                jsonHelper.Msg = "Error";
                jsonHelper.Status = "n";
            }
            else
            {
                //int temp= 凑
                jsonHelper.Data = JsonConverter.Serialize(this.CodeAreaManage.LoadListAll((SYS_CODE_AREA p) => (int)p.LEVELS == 1 && p.PID == id), false);
            }
            return base.Json(jsonHelper);
        }
        public ActionResult Country(int id)
        {
            JsonHelper jsonHelper = new JsonHelper
            {
                Status = "y",
                Msg = "Success"
            };
            if (string.IsNullOrEmpty(id.ToString()))
            {
                jsonHelper.Msg = "Error";
                jsonHelper.Status = "n";
            }
            else
            {
                jsonHelper.Data = JsonConverter.Serialize(this.CodeAreaManage.LoadListAll((SYS_CODE_AREA p) => (int)p.LEVELS == 2 && p.PID == id), false);
            }
            return base.Json(jsonHelper);
        }
    }
}