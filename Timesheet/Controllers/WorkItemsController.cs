namespace Timesheet.Controllers
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;
    using Timesheet.Models;

    [Authorize]
    public class WorkItemsController : Controller
    {
        private TimesheetContext db;
        private UserManager<ApplicationUser> userManager;

        public WorkItemsController()
        {
            this.db = new TimesheetContext();
            this.userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
        }

        // GET: /WorkItems/
        //public ActionResult Index()
        //{
        //    return View(db.Tasks.ToList());
        //}

        // GET: /WorkItems/Details/5
        //public ActionResult Details(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }

        //    WorkItem workitem = db.Tasks.Find(id);

        //    if (workitem == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    return View(workitem);
        //}

        // GET: /WorkItems/Create
        public ActionResult Create(Guid projectId)
        {
            var currentUser = this.userManager.FindById(User.Identity.GetUserId());
            var project = db.Projects.SingleOrDefault(p => p.Id == projectId && p.User.Id == currentUser.Id);

            if(project == null)
            {
                return HttpNotFound();
            }

            return View(new WorkItem { From = DateTime.Now, IncomePerHour = project.IncomePerHour, ProjectId = projectId });
        }

        // POST: /WorkItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="From,To,Summary,IncomePerHour,ProjectId")] WorkItem workitem)
        {
            if (ModelState.IsValid)
            {
                workitem.Id = Guid.NewGuid();
                db.Tasks.Add(workitem);
                db.SaveChanges();
                return RedirectToAction("Details", "Projects", new { Id = workitem.ProjectId });
            }

            return View(workitem);
        }

        // GET: /WorkItems/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            WorkItem workitem = db.Tasks.Find(id);

            if (workitem == null)
            {
                return HttpNotFound();
            }

            return View(workitem);
        }

        // POST: /WorkItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,From,To,Summary,IncomePerHour")] WorkItem workitem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workitem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(workitem);
        }

        // GET: /WorkItems/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            WorkItem workitem = db.Tasks.Find(id);

            if (workitem == null)
            {
                return HttpNotFound();
            }

            return View(workitem);
        }

        // POST: /WorkItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            WorkItem workitem = db.Tasks.Find(id);
            db.Tasks.Remove(workitem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
