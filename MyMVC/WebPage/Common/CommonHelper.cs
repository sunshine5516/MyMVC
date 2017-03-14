using Domain;
using Service.IService;
using Spring.Context.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Models
{
    public class CommonHelper
    {
        public ICodeManage CodeManage = ContextRegistry.GetContext().GetObject("Service.Code") as ICodeManage;
        //public ICodeAreaManage CodeAreaManage = ContextRegistry.GetContext().GetObject("Service.CodeArea") as ICodeAreaManage;
        public MvcHtmlString GetModuleMenu(SYS_MODULE module, List<SYS_MODULE> moduleList)
        {
            StringBuilder stringBuilder = new StringBuilder(15000);
            List<SYS_MODULE> list = (
                from p in moduleList.FindAll((SYS_MODULE p) => p.PARENTID == module.ID && p.LEVELS == 1)
                orderby p.SHOWORDER
                select p).ToList<SYS_MODULE>();
            if (list != null && list.Count > 0)
            {
                foreach (SYS_MODULE current in list)
                {
                    stringBuilder.Append("<li data-id=\"" + module.ALIAS + "\" class=\"FirstModule\" >");
                    stringBuilder.Append(string.Concat(new string[]
                    {
                "<a class=\"",
                this.ChildModuleList(current, moduleList, stringBuilder, false) ? "" : "J_menuItem",
                "\" href=\"",
                string.IsNullOrEmpty(current.MODULEPATH) ? "javascript:void(0)" : current.MODULEPATH,
                "\" ><i class=\"",
                current.ICON,
                "\"></i> <span class=\"nav-label\">",
                current.NAME,
                "</span>",
                this.ChildModuleList(current, moduleList, stringBuilder, false) ? "<span class=\"fa arrow\"></span>" : "",
                "</a>"
                    }));
                    this.ChildModuleList(current, moduleList, stringBuilder, true);
                    stringBuilder.Append("</li>");
                }
            }
            return new MvcHtmlString(stringBuilder.ToString());
        }

        // Models.CommonHelper
        private bool ChildModuleList(SYS_MODULE module, List<SYS_MODULE> moduleList, StringBuilder str, bool IsAppend)
        {
            List<SYS_MODULE> list = (
                from p in moduleList.FindAll((SYS_MODULE p) => p.PARENTID == module.ID)
                orderby p.SHOWORDER
                select p).ToList<SYS_MODULE>();
            if (list != null && list.Count > 0)
            {
                if (IsAppend)
                {
                    str.Append("<ul class=\"nav nav-second-level\">");
                    foreach (SYS_MODULE current in list)
                    {
                        str.Append("<li>");
                        str.Append(string.Concat(new string[]
                        {
                    "<a class=\"",
                    this.ChildModuleList(current, moduleList, str, false) ? "" : "J_menuItem",
                    "\" href=\"",
                    string.IsNullOrEmpty(current.MODULEPATH) ? "javascript:void(0)" : current.MODULEPATH,
                    "\" ><i class=\"",
                    current.ICON,
                    "\"></i> <span class=\"nav-label\">",
                    current.NAME,
                    "</span>",
                    this.ChildModuleList(current, moduleList, str, false) ? "<span class=\"fa arrow\"></span>" : "",
                    "</a>"
                        }));
                        this.ChildModuleList(current, moduleList, str, true);
                        str.Append("</li>");
                    }
                    str.Append("</ul>");
                }
                return true;
            }
            return false;
        }
        public string GetUserZW(string levels)
        {
            return this.CodeManage.Get((SYS_CODE m) => m.CODEVALUE == levels && m.CODETYPE == "ZW").NAMETEXT;
        }
        // WebPages.CommonHtmlHelper
        // Models.CommonHelper
        //public string GetCodeAreaName(string codearealist)
        //{
        //    if (string.IsNullOrEmpty(codearealist))
        //    {
        //        return string.Empty;
        //    }
        //    List<string> list = (
        //        from p in codearealist.Trim(new char[]
        //        {
        //    ','
        //        }).Split(new string[]
        //        {
        //    ","
        //        }, StringSplitOptions.RemoveEmptyEntries)
        //        select p).ToList<string>();
        //    if (list != null && list.Count > 0)
        //    {
        //        string text = string.Empty;
        //        using (List<string>.Enumerator enumerator = list.GetEnumerator())
        //        {
        //            while (enumerator.MoveNext())
        //            {
        //                string item = enumerator.Current;
        //                text = text + this.CodeAreaManage.Get((SYS_CODE_AREA p) => p.ID == item).NAME + "&nbsp;";
        //            }
        //        }
        //        return text;
        //    }
        //    return string.Empty;
        //}


    }
}