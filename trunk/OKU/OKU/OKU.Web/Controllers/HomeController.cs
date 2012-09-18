using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace OKU.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Index", "PageSetViewer");
        }
  

        //[HttpPost]
        //public ActionResult AddGridPoint(string viewItemId, int x, int y)
        //{
        //    // ViewItmeId je prefiksiran s _ (zato sto ga koristim kao id html kontrole, a ne smije pocinjat sa znamenkom)
        //    // x i y su kooridnate u promilima. X odgovara apscisi u koor sustavu, Y ordinati

        //    Thread.Sleep(1500);

        //    // Point id mora pocinjat sa slovom ili _ znakom
        //    dynamic result = new { pointId = Guid.NewGuid() };

        //    return new JsonResult()
        //    {
        //        Data = result,
        //        ContentEncoding = Encoding.UTF8,
        //        JsonRequestBehavior = JsonRequestBehavior.AllowGet
        //    };
        //}

        //[HttpPost]
        //public ActionResult RemoveGridPoint(string viewItemId, string pointId)
        //{
        //    // ViewItmeId je prefiksiran s _ (zato sto ga koristim kao id html kontrole, a ne smije pocinjat sa znamenkom)
        //    // Point id mora pocinjat sa slovom ili _ znakom

        //    Thread.Sleep(1000);

        //    // Vraca prazan rezultat
        //    return new EmptyResult();
        //}

        //[HttpPost]
        //public ActionResult OpenGridPoint(string viewItemId, string pointId)
        //{
        //    // ViewItmeId je prefiksiran s _ (zato sto ga koristim kao id html kontrole, a ne smije pocinjat sa znamenkom)
        //    // Point id mora pocinjat sa slovom ili _ znakom

        //    // Ovdje se vraca parcijalni view koji sadrzi view iteme za odabranu tocku grida
        //    Thread.Sleep(1000);

        //    return View("OpenGridPointViewPartial");
        //}

        //[HttpPost]
        //public ActionResult SaveGridPoint(string viewItemId, string pointId, FormCollection collection)
        //{
        //    // ViewItmeId je prefiksiran s _ (zato sto ga koristim kao id html kontrole, a ne smije pocinjat sa znamenkom)
        //    // Point id mora pocinjat sa slovom ili _ znakom

        //    // Tu spremas vrijednosti s otvorenog dijaloga. 

        //    /*
        //     Ovo je slicno implementaciji
        //     * 
        //     *  [HttpPost]
        //        public ActionResult Page(int pageSetId, int? pageNumber, FormCollection collection)
        //        {
        //            //get all viewItems of type codePlan and update 
        //     * ...
        //     */

        //    // Vraca prazan rezultat
        //    return new EmptyResult();
        //}
    }
}
