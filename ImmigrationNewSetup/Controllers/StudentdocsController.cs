using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ImmigrationNewSetup.Models;
using onlineportal.Areas.AdminPanel.Models;

namespace ImmigrationNewSetup.Controllers
{
    public class StudentdocsController : Controller
    {
        private dbcontext db = new dbcontext();
        Helper Help = new Helper();
        public static int student;
        // GET: Studentdocs
        public ActionResult Index()
        {
            return View(db.Studentdocs.ToList());
        }

        // GET: Studentdocs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Studentdocs studentdocs = db.Studentdocs.Find(id);
            if (studentdocs == null)
            {
                return HttpNotFound();
            }
            return View(studentdocs);
        }

        // GET: Studentdocs/Create
        public ActionResult Create(int studentid)
        {
            ViewBag.studentid = studentid;
            student = studentid;
            Session["studentid"] = studentid;
            return View();
        }

        // POST: Studentdocs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StudentId,date,profile,education,family,other")] Studentdocs studentdocs, HttpPostedFileBase file, IEnumerable<HttpPostedFileBase> file1, IEnumerable<HttpPostedFileBase> file2, IEnumerable<HttpPostedFileBase> file3)
        {
            if (ModelState.IsValid)
            {
                string edu=null, fam=null, oth=null;
                
                foreach(var a in file1)
                {
                    
                        edu = Help.uploadfile(a);
                    studentdocs.education = edu;
                    studentdocs.family = "";
                    studentdocs.other = "";
                    studentdocs.StudentId = student;
                    db.Studentdocs.Add(studentdocs);
                    db.SaveChanges();

                }
                foreach (var b in file2)
                {
                    
                        fam = Help.uploadfile(b);
                    studentdocs.education = "";
                    studentdocs.family = fam;
                    studentdocs.other = "";
                    studentdocs.StudentId = student;
                    db.Studentdocs.Add(studentdocs);
                    db.SaveChanges();

                }
                foreach (var c in file3)
                {
                        oth = Help.uploadfile(c);
                    studentdocs.education = "";
                    studentdocs.family = "";
                    studentdocs.other = oth;
                    studentdocs.StudentId = student;
                    db.Studentdocs.Add(studentdocs);
                    db.SaveChanges();

                }
                studentdocs.profile = Help.uploadfile(file);
                db.Studentdocs.Add(studentdocs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(studentdocs);
        }

        // GET: Studentdocs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Studentdocs studentdocs = db.Studentdocs.Find(id);
            if (studentdocs == null)
            {
                return HttpNotFound();
            }
            return View(studentdocs);
        }

        // POST: Studentdocs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StudentId,date,profile,education,family,other")] Studentdocs studentdocs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentdocs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(studentdocs);
        }

        // GET: Studentdocs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Studentdocs studentdocs = db.Studentdocs.Find(id);
            if (studentdocs == null)
            {
                return HttpNotFound();
            }
            return View(studentdocs);
        }

        // POST: Studentdocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Studentdocs studentdocs = db.Studentdocs.Find(id);
            db.Studentdocs.Remove(studentdocs);
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
