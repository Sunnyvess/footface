using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using OKU.Core.Entities.PageStructure;
using OKU.Core.Entities.MaterialStructure;

namespace OKU.Core.Repositories.Implementation
{
    public class PageSetRepository : RepositoryBase<OkuDbContext, PageSet>, IPageSetRepository
    {
        public PageSetRepository()
        {
            this.Initialize(x => x.PageSets);
        }

        #region Implementation of IPageSetRepository

        public Page FindPage(int pageId)
        {
            return this.DbContext.Pages
                .Include(x => x.ViewItemSets.Select(y => y.ViewItems))
                .Where(x => x.Id == pageId).SingleOrDefault();
        }

        
        #endregion

        #region ViewItemRepository

        public ViewItem FindViewItem(int viewItemId)
        {
            return this.DbContext.ViewItems
               .Where(x => x.Id == viewItemId).SingleOrDefault();
        }

        public ViewItem AddViewItem(int viewItemSetId, ViewItem entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }       
            ViewItemSet viewItemSet = this.DbContext.ViewItemSets.Where(x => x.Id == viewItemSetId).FirstOrDefault();             
            viewItemSet.ViewItems.Add(entity);
            this.DbContext.SaveChanges();
            return entity;
        }

        public ViewItem AttachViewItemAsModified(ViewItem entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }  
            ViewItemSet viewItemSet = this.DbContext.ViewItemSets.Where(x => x.Id == entity.ViewItemSetId).FirstOrDefault();
            ViewItem viewItemToModify = viewItemSet.ViewItems.Where(x => x.Id == entity.Id).FirstOrDefault();
            viewItemToModify = entity;

            this.DbContext.SaveChanges();
            return entity;
        }

        public void RemoveViewItem(ViewItem entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }  
            ViewItemSet viewItemSet = this.DbContext.ViewItemSets.Where(x => x.Id == entity.ViewItemSetId).FirstOrDefault();
            DbContext.Entry(entity).State = EntityState.Deleted;
            viewItemSet.ViewItems.Remove(entity);
            this.DbContext.SaveChanges();
        }

        #endregion

    }
}
