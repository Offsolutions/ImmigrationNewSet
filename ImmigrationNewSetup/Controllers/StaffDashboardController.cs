using ImmigrationNewSetup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImmigrationNewSetup.Controllers
{
    public class StaffDashboardController : Controller
    {
        dbcontext db = new dbcontext();
        // GET: StaffDashboard
        public ActionResult Index()
        {
            return View();
        }

        // GET: StaffDashboard/Details/5
        public ActionResult FileDetails()
        {
            // var studentcourse = db.studentdetails.ToList();
            int a = Convert.ToInt32(Session["User"]);
            List<studentdetail> sturecord = new List<studentdetail>();
            var receiptdetail = from studentdetail in db.studentdetails.ToList()
                                join AssignedFiles in db.AssignedFiles on studentdetail.StudentId equals AssignedFiles.StudentId
                                where AssignedFiles.UserID == Convert.ToInt32(Session["User"])
                                select new
                                {
                                    ID = studentdetail.StudentId,
                                    Name = studentdetail.name,
                                    FatherName = studentdetail.fathername,
                                    Contact = studentdetail.phone,
                                    Province=studentdetail.CountryId,
                                    Address=studentdetail.address


                                };
            foreach (var item in receiptdetail)
            {
                sturecord.Add(new studentdetail()
                {
                    StudentId = item.ID,
                    name = item.Name,
                    fathername = item.FatherName,
                    phone = item.Contact,
                    CountryId=item.Province,
                    address=item.Address

                });
            }
            return View(sturecord);
        }

        // GET: StaffDashboard/Create
        public ActionResult FullDetails(int id)
        {
            return View(db.studentdetails.Find(id));
        }
        public ActionResult Logs(int id)
        {
            return View(db.Logs.Where(X=>X.uid==id));
        }
        // POST: StaffDashboard/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: StaffDashboard/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StaffDashboard/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: StaffDashboard/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StaffDashboard/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
