using System.Linq;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Xml.Linq;

namespace RectangleProblem.Extensions
{
    public static class HtmlExtensions
    {
        // The reason for this method is that when we're excluding property errors and they exist, the alert danger div 
        // still displays but with no summary text.
        public static MvcHtmlString ValidationSummaryImproved(this HtmlHelper htmlHelper, bool excludePropertyErrors)
        {
            var htmlString = htmlHelper.ValidationSummary(excludePropertyErrors);

            if (htmlString == null)
            {
                return null;
            }

            var xEl = XElement.Parse(htmlString.ToHtmlString());
            var xElement = xEl.Element("ul");
            if (xElement == null)
            {
                return htmlString;
            }

            var lis = xElement.Elements("li").ToList();
            if (lis.Count == 1 && lis.First().Value == "")
            {
                return null;
            }

            return htmlString;
        }
    }
}