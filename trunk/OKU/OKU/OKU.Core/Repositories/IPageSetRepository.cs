using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using OKU.Core.Entities.PageStructure;

namespace OKU.Core.Repositories
{
    public interface IPageSetRepository : IRepository<PageSet>
    {
        
        Page FindPage(int pageId);

        //ViewItem
        ViewItem FindViewItem(int viewItemId);
        ViewItem AddViewItem(int ViewItemSetId, ViewItem entity);
        ViewItem AttachViewItemAsModified(ViewItem entity);
        void RemoveViewItem(ViewItem entity);       
    }
}
