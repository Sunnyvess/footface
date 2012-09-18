using System;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;
using MvcContrib.Pagination;
using MvcContrib.Sorting;
using MvcContrib.UI.Grid;
using OKU.Core.Repositories;
using OKU.Web.Models.PageSetViewer;
using OKU.Core.Entities.PageStructure;
using OKU.Core.Entities.CodeBookStructure;
using OKU.Core.Entities;
using OKU.Web.Infrastructure;
using System.Text;
using System.Threading;

namespace OKU.Web.Controllers
{
    [Authorize]
    public class PageSetViewerController : Controller
    {
        private readonly IPageSetRepository _pageSetRepository;
        private readonly IExecutionDefinitionRepository _executionDefinitionRepository;
        private readonly IUserRepository _userRepository;

        private List<int> NotFilterdPageOrdinalNumbers(PageSet PageSet)
        {
            List<int> posiblePages = new List<int>();

            foreach (var page in PageSet.Pages)
            {
                posiblePages.Add(page.OrdinalPosition);
            }

            foreach (var page in PageSet.Pages)
            {
                foreach (var viewItemSet in page.ViewItemSets)
                {
                    foreach (var item in viewItemSet.ViewItems)
                    {
                        if (item.ViewItemPageFilters.Count() > 0)
                        {
                            foreach (var viewItemPageFilter in item.ViewItemPageFilters)
                            {
                                if (item.Value == viewItemPageFilter.Value)
                                {
                                    int pageToFilterOrdinal = PageSet.Pages.Where(x => x.Id == viewItemPageFilter.PageId).FirstOrDefault().OrdinalPosition;
                                    posiblePages.Remove(pageToFilterOrdinal);
                                }
                            }
                        }
                    }
                }
            }

            return posiblePages;
        }

        // Dont try to refactor, better to code from start - spaghetti alert
        private int GetNextPage(PageSet CurrentPageSet, int? CurrentPage, WebEnums.PageNavigation Direction)
        {
            int nextPage = 1;
            List<int> posiblePages = new List<int>();

            posiblePages = NotFilterdPageOrdinalNumbers(CurrentPageSet);
           
            int index = posiblePages.IndexOf(CurrentPage.Value);
            //current Page is posible
            if (index >= 0)
            {
                if (Direction == WebEnums.PageNavigation.Next)
                {
                    if ((index + 1) <= posiblePages.Count() - 1)
                    {
                        nextPage = posiblePages[index + 1];
                    }
                    else
                    {
                        // return max + 1, it will render finishPage
                        nextPage = CurrentPageSet.Pages.Count() + 1;
                    }
                }
                else
                {
                    if (((index - 1) <= posiblePages.Count() - 1) && (index - 1) >= 0)
                    {
                        nextPage = posiblePages[index - 1];
                    }
                    else
                    {
                        if (posiblePages.Count() > 0)
                        {
                            nextPage = posiblePages.FirstOrDefault();
                        }
                        else
                        {
                            nextPage = CurrentPage.Value;
                        }
                    }

                }
            }
            //current page is not possible, it was finnish page
            else
            {
                nextPage = posiblePages.LastOrDefault();    
            }

            return nextPage;
        }

        private bool PageIsValid(Page page, out string ValidationSummary)
        {
            bool isValid = true;
            ValidationSummary = "";

            foreach (var viewItemSet in page.ViewItemSets)
            {
                foreach (var item in viewItemSet.ViewItems)
                {
                    if (item.ViewItemDescriminator == Enums.ViewItemDescriminator.CodePlan)
                    {
                        if (string.IsNullOrEmpty(item.Value))
                        {
                            isValid = false;
                            ValidationSummary += "Nije unesena vrijednost za kodni plan " + item.Code + "<br/><br/>"; 
                        }
                    }
                }
            }

            if (!isValid) ValidationSummary += "<br/>Kako bi nastavili ocjenjivanje, unesite potrebne vrijednosti."; 

            return isValid;
        }

        private bool PageSetIsValid(PageSet pageSet, out string ValidationSummary)
        {
            bool isValid = true;
            ValidationSummary = "";

            List<int> notFilterdPages = NotFilterdPageOrdinalNumbers(pageSet);

            foreach (var page in pageSet.Pages)
            {
                if( notFilterdPages.Contains(page.OrdinalPosition))
                {
                    foreach (var viewItemSet in page.ViewItemSets)
                    {
                        foreach (var item in viewItemSet.ViewItems)
                        {
                            if (item.ViewItemDescriminator == Enums.ViewItemDescriminator.CodePlan)
                            {
                                if (string.IsNullOrEmpty(item.Value))
                                {
                                    isValid = false;
                                    ValidationSummary += "Nije unesena vrijednost elementa " + item.Code + " <br/><br/>";
                                }
                            }
                        }
                    }
                }
            }
            return isValid;
        }

        public PageSetViewerController(IPageSetRepository pageSetRepository, IExecutionDefinitionRepository executionDefinitionRepository, IUserRepository userRepository)
        {
            if (pageSetRepository == null)
            {
                throw new ArgumentNullException("pageSetRepository");
            }
            if (executionDefinitionRepository == null)
            {
                throw new ArgumentNullException("executionDefinitionRepository");
            }
            if (userRepository == null)
            {
                throw new ArgumentNullException("userRepository");
            }

            this._pageSetRepository = pageSetRepository;
            this._executionDefinitionRepository = executionDefinitionRepository;
            this._userRepository = userRepository;
        }


        public ViewResult Index(int? page, GridSortOptions sort)
        {
            List<PageSet> pageSetList = new List<PageSet>();
            List<int> pageSetIds = _executionDefinitionRepository.AvailablePageSets(1);
            foreach (int id in pageSetIds)
            {

                pageSetList.Add(_pageSetRepository.Find(id));
            }

            IEnumerable<PageSet> pageSets =  pageSetList;
            if (sort != null && !string.IsNullOrWhiteSpace(sort.Column))
            {
                pageSets = pageSets.OrderBy(sort.Column, sort.Direction);
                this.ViewData["sort"] = sort;
            }
            else
            {
                pageSets = pageSets.OrderBy(x => x.Code);
                this.ViewData["sort"] = new GridSortOptions { Column = "Code", Direction = SortDirection.Ascending };
            }

            return this.View(pageSets.AsPagination(page ?? 1, 20));
        }

        
        [Authorize(Roles = "Coder, Admin")]
        public ActionResult Page(int pageSetId, int? pageNumber)
        {
            var pageSet = this._pageSetRepository.Find(pageSetId);

            if(pageSet == null)
            {
                throw new ApplicationException(string.Format("Page set with id '{0}' cannot be found.", pageSetId));
            }

            var executionDefinition = _executionDefinitionRepository.Query.Where(x => x.PageSetId == pageSet.Id).FirstOrDefault();
            if (executionDefinition.IsFinished)
            {
                return this.RedirectToAction("Index");
            }

            int notNullablePageNumber = pageNumber.GetValueOrDefault(1);
            var page = pageSet.Pages.OrderBy(x => x.OrdinalPosition).ElementAtOrDefault(notNullablePageNumber - 1);

            if(page == null)
            {
                return this.RedirectToAction("Page", new { pageSetId, pageNumber = 1 });
            }
            var model = new PageModel
                            {
                                DebugMode = false,
                                Page = page,
                                PageSet = pageSet,
                                CurrentPage = notNullablePageNumber,
                                TotalPages = pageSet.Pages.Count,
                                ValidationSummary= string.Empty
                            };
            return this.View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Coder, Admin")]
        public ActionResult Page(int pageSetId, int? pageNumber, FormCollection collection)
        {
            var pageSet = this._pageSetRepository.Find(pageSetId);
            if (pageSet == null)
            {
                throw new ApplicationException(string.Format("Page set with id '{0}' cannot be found.", pageSetId));
            }

            //get all viewItems of type codePlan and update 
            for (int i = 0; i < collection.Count; i++)
			{
			    string key = collection.GetKey(i);
                if ((key.Split('_').Count()>2) && (string.Equals(key.Split('_').FirstOrDefault(), "ViewItem-CodePlan")))
                {
                    int viewItemId = Int32.Parse(key.Split('_')[1]);
                    int codePlanId = Int32.Parse(key.Split('_')[2]);
                    ViewItem viewItem = _pageSetRepository.FindViewItem(viewItemId);
                    string value = collection[i].ToString();
                    if (viewItem.Value != value)
                    {
                        viewItem.Value = value;
                        _pageSetRepository.AttachViewItemAsModified(viewItem);
                    }                 
                }
			}        

            // set current page number notNullablePageNumber notNullablePageNumber
            int notNullablePageNumber = pageNumber.GetValueOrDefault(1);

            if (!String.IsNullOrEmpty(collection["current-page"]))
            {
                if (!String.IsNullOrEmpty( collection.GetValue("current-page").ToString()))
                      notNullablePageNumber = Int32.Parse(collection["current-page"].ToString());
            }

            var currentPage = pageSet.Pages.OrderBy(x => x.OrdinalPosition).ElementAtOrDefault(notNullablePageNumber - 1);
         
            //if not valid and user is not Admin,return same page with validation summary
            if (!User.IsInRole("Admin"))
            {
                string validationSummary;
                if (!PageIsValid(currentPage,out validationSummary))
                {
                     var model = new PageModel
                            {
                                DebugMode = false,
                                Page = currentPage,
                                PageSet = pageSet,
                                CurrentPage = notNullablePageNumber,
                                TotalPages = pageSet.Pages.Count,
                                ValidationSummary= validationSummary
                            };
                     return this.View(model);
                }
            }
            // set next page
           
            if (!String.IsNullOrEmpty(collection["next-page"]))
            {
                notNullablePageNumber = GetNextPage(pageSet, pageNumber, WebEnums.PageNavigation.Next);
                if (notNullablePageNumber > pageSet.Pages.Count())
                {
                    //check is it all finnished
                    return this.RedirectToAction("FinishPage", new { pageSetId });
                }
            }
            else if (!String.IsNullOrEmpty(collection["previous-page"]))
            {
                notNullablePageNumber = GetNextPage(pageSet, pageNumber, WebEnums.PageNavigation.Previous);
            }

            var page = pageSet.Pages.OrderBy(x => x.OrdinalPosition).ElementAtOrDefault(notNullablePageNumber - 1);

            //check is filtered
            //foreach(ViewItem item in )

            if (page == null)
            {
                return this.RedirectToAction("Page", new { pageSetId, pageNumber });
            }
            return this.RedirectToAction("Page", new { pageSetId = pageSetId, pageNumber = notNullablePageNumber });
        }

         [Authorize(Roles = "Coder, Admin")]
        public ActionResult FinishPage(int pageSetId)
        {
            var pageSet = this._pageSetRepository.Find(pageSetId);

            if (pageSet == null)
            {
                throw new ApplicationException(string.Format("Page set with id '{0}' cannot be found.", pageSetId));
            }

            string validationSummary;
            PageSetIsValid(pageSet, out validationSummary);

            var model = new FinishPageModel
            {
                DebugMode = false,
                PageSet = pageSet,
                TotalPages = pageSet.Pages.Count,
                ValidationSummary = validationSummary                          
            };
            return this.View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Coder, Admin")]
        public ActionResult FinishPage(int pageSetId, FormCollection collection)
        {
            var pageSet = this._pageSetRepository.Find(pageSetId);

            if (pageSet == null)
            {
                throw new ApplicationException(string.Format("Page set with id '{0}' cannot be found.", pageSetId));
            }

            int pageNumber = pageSet.Pages.Count() + 1;
            if (!String.IsNullOrEmpty(collection["end-page"]))
            {
                string validationSummary;
                if (PageSetIsValid(pageSet, out validationSummary))
                {
                    //save definition
                    //ExecutionDefinition executionDefinition = _executionDefinitionRepository.Query.Where(x => x.PageSetId == pageSetId).FirstOrDefault();
                    //executionDefinition.IsFinished = true;
                    //executionDefinition.ExecutionFinished = DateTime.Now;
                    //executionDefinition.ExecutedByUserId = _userRepository.FindByUserName(User.Identity.Name).Id;
                    _executionDefinitionRepository.SetExecutionDefinitionFinished(pageSetId, _userRepository.FindByUserName(User.Identity.Name).Id);

                    return this.RedirectToAction("Index");
                }
                else
                {
                    var model = new FinishPageModel
                    {
                        DebugMode = false,
                        PageSet = pageSet,
                        TotalPages = pageSet.Pages.Count,
                        ValidationSummary = validationSummary
                    };
                    return this.View(model);  
                }
            }
            else 
            { 
                return this.RedirectToAction("Page", new { pageSetId = pageSetId, pageNumber = GetNextPage(pageSet, pageNumber, WebEnums.PageNavigation.Previous) });
            }
        }

        [HttpPost]
        public ActionResult AddGridPoint(string viewItemId, int x, int y)
        {
            if (String.IsNullOrEmpty(viewItemId))
            {
                throw new ApplicationException(string.Format("ViewItemId string is empty"));
            }

            //ako viewItemId nece imat prefiks, onda ovdje treba zamjenit
            int digitalMaterialViewItemId = Int32.Parse(viewItemId.Split('_').LastOrDefault());
            ViewItem DigitalMaterialViewItem = _pageSetRepository.FindViewItem(digitalMaterialViewItemId);

            if (DigitalMaterialViewItem.ViewItemDescriminatorValue != (int)Enums.ViewItemDescriminator.Material)
            {
                throw new ApplicationException(string.Format("ViewItem typeof DigitalMaterial expected"));
            }
      
            // prondaji parrent code plan i u pripadajucem viewItemu povecaj vrijednost
            ViewItem parrentCodePlanViewItem = DigitalMaterialViewItem.ViewItemSet.ViewItems
                .Where(d => d.ViewItemDescriminatorValue == (int)Enums.ViewItemDescriminator.CodePlan)
                .Where(a => a.CodePlan.CodePlanActionOnSelectionValue == (int)Enums.ActionOnSelection.CrudAndActivateChildren)
                .FirstOrDefault();

            parrentCodePlanViewItem.Value = (Int32.Parse(parrentCodePlanViewItem.Value ?? "0") + 1).ToString();
            _pageSetRepository.AttachViewItemAsModified(parrentCodePlanViewItem);
          
            //stvori nove viewIteme
            string createdPointId = "pointId_";
            foreach (CodePlan childCodePlan in parrentCodePlanViewItem.CodePlan.ChildCodePlans)
            {
                ViewItem viewItem = new ViewItem();
                viewItem.CodePlanId = childCodePlan.Id;
                viewItem.ViewItemDescriminatorValue = (int)Enums.ViewItemDescriminator.CodePlan;
                viewItem.ViewItemSetId = parrentCodePlanViewItem.ViewItemSetId;
                viewItem.IsGridEntry = true;
                viewItem.DigitalMaterialId = DigitalMaterialViewItem.DigitalMaterialId;
                viewItem.ShowViewItem = true;
                viewItem.IterationId = DigitalMaterialViewItem.IterationId;
                viewItem.Code = createdPointId;
                viewItem.PartPerThousandFromTop = y;
                viewItem.PartPerThousandFromLeft = x;
                // za sad dodaj na zadnje mjesto
                viewItem.OrdinalPosition = parrentCodePlanViewItem.ViewItemSet.ViewItems.LastOrDefault().OrdinalPosition + 1;

                if (createdPointId != "pointId_")
                {
                    createdPointId += "-";
                }
                createdPointId += _pageSetRepository.AddViewItem(parrentCodePlanViewItem.ViewItemSetId, viewItem).Id.ToString();
            }

            createdPointId += "_" + x.ToString() + "-" + y.ToString();

            // TODO: Ovdje saljes viewItemIdToRefresh kao broj, a input na webu ima id u formatu 'ViewItem-CodePlan_25_2'.
            // Id treba biti identican onom u html-u
            string viewItemIdToRefresh = "ViewItem-CodePlan_" + parrentCodePlanViewItem.Id.ToString() + "-" + parrentCodePlanViewItem.CodePlanId.ToString();

            dynamic result = new { pointId = createdPointId, viewItemIdToRefresh = viewItemIdToRefresh, viewItemValueToRefresh = parrentCodePlanViewItem.Value };
            
            return new JsonResult()
                       {
                           Data = result,
                           ContentEncoding = Encoding.UTF8,
                           JsonRequestBehavior = JsonRequestBehavior.AllowGet
                       };
        }

        [HttpPost]
        public ActionResult RemoveGridPoint(string viewItemId, string pointId)
        {
            if (String.IsNullOrEmpty(viewItemId))
            {
                throw new ApplicationException(string.Format("ViewItemId string is empty"));
            }

            int digitalMaterialViewItemId = Int32.Parse(viewItemId.Split('_').LastOrDefault());
            ViewItem DigitalMaterialViewItem = _pageSetRepository.FindViewItem(digitalMaterialViewItemId);

            if (DigitalMaterialViewItem.ViewItemDescriminatorValue != (int)Enums.ViewItemDescriminator.Material)
            {
                throw new ApplicationException(string.Format("ViewItem typeof DigitalMaterial expected"));
            }

            List<string> viewItemsToDeleteId = pointId.Split('_')[1].Split('-').ToList();

            ViewItem viewItemToDelete  = _pageSetRepository.FindViewItem( Int32.Parse(viewItemsToDeleteId.FirstOrDefault()));
            ViewItem parrentCodePlanViewItem = viewItemToDelete.ViewItemSet.ViewItems.Where(x => x.CodePlanId == viewItemToDelete.CodePlan.CodePlanParentId).FirstOrDefault();
            parrentCodePlanViewItem.Value = (Int32.Parse(parrentCodePlanViewItem.Value) - 1).ToString();
            _pageSetRepository.AttachViewItemAsModified(parrentCodePlanViewItem);
            
            foreach (string viewItemToDeleteId in viewItemsToDeleteId)
            {
                ViewItem viewItem = _pageSetRepository.FindViewItem( Int32.Parse(viewItemToDeleteId));
                _pageSetRepository.RemoveViewItem(viewItem);
                //TODO podesit ordinalPositione
            }
            return new EmptyResult();
        }

        public ActionResult OpenGridPoint(string viewItemId, string pointId)
        {         
            if (String.IsNullOrEmpty(viewItemId))
            {
                throw new ApplicationException(string.Format("ViewItemId string is empty"));
            }
            
            int digitalMaterialViewItemId = Int32.Parse(viewItemId.Split('_').LastOrDefault());
            ViewItem DigitalMaterialViewItem = _pageSetRepository.FindViewItem(digitalMaterialViewItemId);

            if (DigitalMaterialViewItem.ViewItemDescriminatorValue != (int)Enums.ViewItemDescriminator.Material)
            {
                throw new ApplicationException(string.Format("ViewItem typeof DigitalMaterial expected"));
            }

            List<string> viewItemIds = pointId.Split('_')[1].Split('-').ToList();

            List<ViewItem> codePlanViewItems = new List<ViewItem>();
            foreach (string id in viewItemIds)
            {
                codePlanViewItems.Add(_pageSetRepository.FindViewItem(Int32.Parse(id)));
            }

            var model = new GridPointModel
            {
                DebugMode = false,
                PointId = pointId,
                CodePlanViewItems = codePlanViewItems               
            };
            return View("GridPointViewPartial", model);        
        }

        [HttpPost]
        public ActionResult SaveGridPoint(string viewItemId, string pointId, FormCollection collection)
        {
            int digitalMaterialViewItemId = Int32.Parse(viewItemId.Split('_').LastOrDefault());
            ViewItem DigitalMaterialViewItem = _pageSetRepository.FindViewItem(digitalMaterialViewItemId);

            if (DigitalMaterialViewItem.ViewItemDescriminatorValue != (int)Enums.ViewItemDescriminator.Material)
            {
                throw new ApplicationException(string.Format("ViewItem typeof DigitalMaterial expected"));
            }

            bool isValid = true;
            string validationSummary = "";
            foreach (var key in collection.Keys)
            {
                if (key.ToString().Contains("_"))
                {
                    if (key.ToString().Split('_').FirstOrDefault() == "ViewItem-CodePlan")
                    {
                        var codePlanViewItemId= key.ToString().Split('_')[1];
                        var entryValue = collection[key.ToString()].ToString();

                        ViewItem viewItemToUpdate = _pageSetRepository.FindViewItem(Int32.Parse(codePlanViewItemId));
                        viewItemToUpdate.Value = entryValue;
                        if (string.IsNullOrEmpty(entryValue))
                        {
                            isValid = false;
                            validationSummary = "Potrebno je unesti sve vrijednosti";
                        }
                        _pageSetRepository.AttachViewItemAsModified(viewItemToUpdate);
                    }
                }
            }

            // U slucaju errora vrati false i poruku s greskom
            dynamic result = new { completedSuccessfully = isValid, errorMessage = validationSummary };
            
            return new JsonResult()
                       {
                           Data = result,
                           ContentEncoding = Encoding.UTF8,
                           JsonRequestBehavior = JsonRequestBehavior.AllowGet
                       };
        }
    }
}
