using OKU.Core.Entities.PageStructure;

namespace OKU.Web.Models.PageSetViewer
{
    public class PageModel
    {
        public bool DebugMode { get; set; }

        public Page Page { get; set; }

        public PageSet PageSet { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public string ValidationSummary { get; set; }
    }
}