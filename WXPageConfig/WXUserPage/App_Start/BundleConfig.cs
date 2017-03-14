using System.Web;
using System.Web.Optimization;

namespace WXUserPage
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));
            ////底部导航
            //bundles.Add(new ScriptBundle("~/bundles/menuButton").Include(
            //    "~/Scripts/Pages/manhuatoTop.1.0.js",
            //            "~/Scripts/Pages/common.js",
            //            "~/Scripts/Pages/idangerous.swiper-1.9.1.min.js",
            //            "~/Scripts/Pages/idangerous.swiper.scrollbar-1.2.js",
                        
            //            "~/Scripts/Pages/swiper"));
            //bundles.Add(new ScriptBundle(""))
            // 使用要用于开发和学习的 Modernizr 的开发版本。然后，当你做好
            // 生产准备时，请使用 http://modernizr.com 上的生成工具来仅选择所需的测试。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/Pages/idangerous.swiper.css",
                      "~/Content/Pages/style.css",
                      "~/Content/Pages/menuButton.css"));

        }
    }
}
