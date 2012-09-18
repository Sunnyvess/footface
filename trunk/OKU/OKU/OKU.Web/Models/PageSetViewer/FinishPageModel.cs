using OKU.Core.Entities.PageStructure;

namespace OKU.Web.Models.PageSetViewer
{
    public class FinishPageModel
    {
        public bool DebugMode { get; set; }

        public PageSet PageSet { get; set; }

        public int TotalPages { get; set; }

        public string ValidationSummary { get; set; }
    }
}