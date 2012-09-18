using System.Web.Mvc;

namespace OKU.Web.Infrastructure.HtmlHelpers
{
    public static class CommonHelpers
    {
        public static string PageTitle(this HtmlHelper helper, string pageTitle)
        {
            if(string.IsNullOrWhiteSpace(pageTitle))
            {
                return "OKU";
            }
            
            return string.Format("OKU - {0}", pageTitle);
        }
    }
}