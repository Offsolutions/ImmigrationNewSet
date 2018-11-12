using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ImmigrationNewSetup.Models;

namespace ImmigrationNewSetup.Controllers
{
    public class AssignedFilesController : Controller
    {
        private dbcontext db = new dbcontext();

        // GET: AssignedFiles
        public ActionResult Index()
        {
            return View(db.AssignedFiles.ToList().OrderBy(x=>x.date));
        }

        // GET: AssignedFiles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignedFiles assignedFiles = db.AssignedFiles.Find(id);
            if (assignedFiles == null)
            {
                return HttpNotFound();
            }
            return View(assignedFiles);
        }

        // GET: AssignedFiles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AssignedFiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserID,StudentId,uid,date")] AssignedFiles assignedFiles, FormCollection coll, int[] StudentId,int username)
        {
            if (ModelState.IsValid)
            {
                foreach (var a in StudentId)
                {
                    assignedFiles.StudentId = a;
                    assignedFiles.UserID = username;
                    assignedFiles.uid = Convert.ToInt32(Session["User"].ToString());
                    assignedFiles.date = System.DateTime.Now;
                    db.AssignedFiles.Add(assignedFiles);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }

            return View(assignedFiles);
        }

        // GET: AssignedFiles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignedFiles assignedFiles = db.AssignedFiles.Find(id);
            if (assignedFiles == null)
            {
                return HttpNotFound();
            }
            return View(assignedFiles);
        }

        // POST: AssignedFiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserID,StudentId,uid,date")] AssignedFiles assignedFiles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assignedFiles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(assignedFiles);
        }

        // GET: AssignedFiles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignedFiles assignedFiles = db.AssignedFiles.Find(id);
            if (assignedFiles == null)
            {
                return HttpNotFound();
            }
            return View(assignedFiles);
        }

        // POST: AssignedFiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AssignedFiles assignedFiles = db.AssignedFiles.Find(id);
            db.AssignedFiles.Remove(assignedFiles);
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
