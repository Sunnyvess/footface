using System.Collections.Generic;
using System.Web.Mvc;
using MvcContrib.UI.Grid;
using MvcContrib.UI.Grid.Syntax;

namespace SimpleCMS.Web.Infrastructure.HtmlHelpers
{
    public static class GridHelpers
    {
        public static IGridWithOptions<T> LocalizedGrid<T>(this HtmlHelper helper, IEnumerable<T> dataSource)
            where T : class
        {
            return helper.Grid(dataSource).Empty("Nema dostupnih podataka.");
        }
    }
}