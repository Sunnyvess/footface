using OKU.Core.Entities.PageStructure;

namespace OKU.Web.Models.PageSetViewer
{
    public class ViewItemSetModel
    {
        public ViewItemSetModel()
        {
        }

        public ViewItemSetModel(bool debugMode, ViewItemSet viewItemSet)
        {
            this.DebugMode = debugMode;
            this.ViewItemSet = viewItemSet;
        }

        public bool DebugMode { get; set; }

        public ViewItemSet ViewItemSet { get; set; }
    }
}