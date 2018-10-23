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
    public class studentdetailsController : Controller
    {
        private dbcontext db = new dbcontext();

        // GET: studentdetails
        public ActionResult Index()
        {
            return View(db.studentdetails.ToList());
        }

        // GET: studentdetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            studentdetail studentdetail = db.studentdetails.Find(id);
            if (studentdetail == null)
            {
                return HttpNotFound();
            }
            return View(studentdetail);
        }

        // GET: studentdetails/Create
        public ActionResult Create()
        {
            studentdetail student = new studentdetail();
            student.date = System.DateTime.Now;
            student.dob = System.DateTime.Now;
            return View(student);
        }

        // POST: studentdetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentId,name,dob,gender,fathername,mothername,address,phone,phone2,email,married,board,qualification,marks,gap,gapdetail,refusal,refusaldetail,intake,note,uid,TrackingID,Editingdate,date,Status")] studentdetail studentdetail)
        {
            if (ModelState.IsValid)
            {
                studentdetail student = db.studentdetails.FirstOrDefault();
                if (student == null)
                {
                    studentdetail.TrackingID = "TRK_1001";
                }
                else
                {
                    var valc = db.studentdetails.Max(x => x.TrackingID);

                    string[] rec = valc.Split('_');
                    var ab = rec[1].ToString();
                    studentdetail.TrackingID = (Convert.ToInt32(ab) + 1).ToString();
                }
                studentdetail.Editingdate = System.DateTime.Now;
                studentdetail.uid = Session["User"].ToString();
                db.studentdetails.Add(studentdetail);
                db.SaveChanges();
                TempData["Success"] = "Saved Successfully";
                return RedirectToAction("Index");
            }

            return View(studentdetail);
        }

        // GET: studentdetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            studentdetail studentdetail = db.studentdetails.Find(id);
            if (studentdetail == null)
            {
                return HttpNotFound();
            }
            return View(studentdetail);
        }

        // POST: studentdetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentId,name,dob,gender,fathername,mothername,address,phone,phone2,email,married,board,qualification,marks,gap,gapdetail,refusal,refusaldetail,intake,note,uid,TrackingID,Editingdate,date,Status")] studentdetail studentdetail)
        {
            if (ModelState.IsValid)
            {
                studentdetail.Editingdate = System.DateTime.Now;
                studentdetail.uid = Session["User"].ToString();
                db.Entry(studentdetail).State = EntityState.Modified;
                db.SaveChanges();
                TempData["Success"] = "Updated Successfully";
                return RedirectToAction("Index");
            }
            return View(studentdetail);
        }

        // GET: studentdetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            studentdetail studentdetail = db.studentdetails.Find(id);
            if (studentdetail == null)
            {
                return HttpNotFound();
            }
            return View(studentdetail);
        }

        // POST: studentdetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            studentdetail studentdetail = db.studentdetails.Find(id);
            db.studentdetails.Remove(studentdetail);
            db.SaveChanges();
            TempData["Success"] = "Deleted Successfully";
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
