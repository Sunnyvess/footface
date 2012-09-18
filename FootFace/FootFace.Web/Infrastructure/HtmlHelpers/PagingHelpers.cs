using System.Web.Mvc;
using MvcContrib.Pagination;
using MvcContrib.UI.Pager;

namespace OKU.Web.Infrastructure.HtmlHelpers
{
    public static class PagingHelpers
    {
        public static Pager LocalizedPager(this HtmlHelper helper, IPagination pagination)
        {
            return helper.Pager(pagination)
                .First("Prva").Last("Zadnja").Previous("Prethodna").Next("Sljedeća")
                .SingleFormat("Prikazano {0} - {1} ").Format("Prikazano {0} - {1} od {2} ");
        }
    }
}