using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Lab4_MVC.Helpers
{
    public static class Extentions
    {
        public static string ToHamada(this string caller)
        {
            return "Welcome" + caller;
        }

        public static MvcHtmlString UlFor(this HtmlHelper caller, IEnumerable<object> arr)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<ul>");
            foreach (object item in arr)
            {
                sb.Append("<li>");
                sb.Append(item.ToString());
                sb.Append("</li>");
            }
            sb.Append("</ul>");
            return new MvcHtmlString(sb.ToString());
        }
    }
}