using OKU.Core.Entities.PageStructure;

namespace OKU.Web.Models.PageSetViewer
{
    public class ViewItemModel
    {
        public ViewItemModel()
        {
        }

        public ViewItemModel(bool debugMode, ViewItem viewItem)
        {
            this.DebugMode = debugMode;
            this.ViewItem = viewItem;
        }

        public bool DebugMode { get; set; }

        public ViewItem ViewItem { get; set; }
    }
}