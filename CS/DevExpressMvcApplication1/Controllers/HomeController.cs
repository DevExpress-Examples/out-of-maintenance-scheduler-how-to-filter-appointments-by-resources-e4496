using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.XtraScheduler;

namespace DevExpressMvcApplication1.Views {
    public class HomeController : Controller {
        public ActionResult Index() {
            return View(SchedulerDataHelper.DataObject);
        }

        public ActionResult SchedulerPartial() {
            string request = (Request.Params["SelectedResources"] != null) ? (Request.Params["SelectedResources"]) : string.Empty;
            List<int> resourcesIds = (request != string.Empty) ? request.Split(';').Select(n => Convert.ToInt32(n)).ToList<int>() : new List<int>();

            return PartialView("SchedulerPartial", SchedulerDataHelper.GetDataObjectFilteredByResources(resourcesIds));
        }
    }
}
