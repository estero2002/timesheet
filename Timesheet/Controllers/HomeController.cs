﻿namespace Timesheet.Controllers
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
            return View(db.Projects.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}