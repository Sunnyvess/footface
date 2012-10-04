using System.Web.Mvc;

namespace SimpleCMS.Web.Infrastructure.HtmlHelpers
{
    public static class CommonHelpers
    {
        public static string PageTitle(this HtmlHelper helper, string pageTitle)
        {
            if(string.IsNullOrWhiteSpace(pageTitle))
            {
                return "SimpleCMS";
            }
            
            return string.Format("SimpleCMS - {0}", pageTitle);
        }
    }
}