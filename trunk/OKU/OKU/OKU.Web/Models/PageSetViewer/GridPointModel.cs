using System.Collections.Generic;
using OKU.Core.Entities.PageStructure;

namespace OKU.Web.Models.PageSetViewer
{
    public class GridPointModel
    {
        public GridPointModel()
        {
        }

        public GridPointModel(bool debugMode, List<ViewItem> viewItems, string pointId)
        {
            this.DebugMode = debugMode;
            this.CodePlanViewItems = viewItems;
            PointId = pointId;
        }

        public bool DebugMode { get; set; }

        public List<ViewItem> CodePlanViewItems { get; set; }

        public string PointId { get; set; }
    }
}