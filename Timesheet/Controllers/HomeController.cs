namespace Timesheet.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Timesheet.Models;

    public class HomeController : Controller
    {
        private TimesheetContext db = new TimesheetContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Time tracking web application.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact information not available.";

            return View();
        }
    }
}