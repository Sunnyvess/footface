using System.Data.Entity;
using System.Linq;
using OKU.Core.Infrastructure.Database;
using OKU.Core.Repositories.Implementation;
using System;
using OKU.Core.Entities.PageStructure;

namespace OKU.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {          
            Database.SetInitializer(new DbInitializer());
            new UserRepository().Query.Count();

            //test add
            PageSetRepository pageSetRepository = new PageSetRepository();
            ViewItem newViewItem = new ViewItem();
            newViewItem.IterationId = 1;
            newViewItem.Code = "sauuuf";
            newViewItem.ShowViewItem = true;
            newViewItem.OrdinalPosition = 2;
            newViewItem.ViewItemSetId = 1;
            newViewItem.ViewItemDescriminatorValue = 1;
            newViewItem.CodePlanId = 1;

       //     pageSetRepository.AddViewItem(1, newViewItem);

            //test modify


           // ViewItemSet viewItemSet = pageSetRepository.Query.Where(x => x.Id == 1).FirstOrDefault().Pages.FirstOrDefault().ViewItemSets.FirstOrDefault();
           // ViewItem viewItemToModify = viewItemSet.ViewItems.Where(x => x.Id ==27).FirstOrDefault();

           // viewItemToModify.Code = "updated code";
           //ViewItem modified =   pageSetRepository.AttachViewItemAsModified(viewItemToModify);

            //test revmove

            ViewItemSet viewItemSet = pageSetRepository.Query.Where(x => x.Id == 1).FirstOrDefault().Pages.FirstOrDefault().ViewItemSets.FirstOrDefault();
            ViewItem viewItemToModify = viewItemSet.ViewItems.Where(x => x.Id == 26).FirstOrDefault();
            pageSetRepository.RemoveViewItem(viewItemToModify);


        }
    }
}
