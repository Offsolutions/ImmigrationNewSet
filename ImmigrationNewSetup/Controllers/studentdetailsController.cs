using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<ActionResult> Index()
        {
            var studentdetails = db.studentdetails.Include(s => s.Agents).Include(s => s.Countries);
            return View(await studentdetails.ToListAsync());
        }

        // GET: studentdetails/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            studentdetail studentdetail = await db.studentdetails.FindAsync(id);
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
            ViewBag.AgentId = new SelectList(db.Agents, "AgentId", "AgentName");
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "Name");
            return View(student);
        }

        // POST: studentdetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "StudentId,name,dob,gender,fathername,mothername,address,phone,phone2,email,married,board,qualification,marks,gap,gapdetail,refusal,refusaldetail,filetype,CountryId,intake,year,note,itr,uid,TrackingID,date,Editingdate,Status,AgentId")] studentdetail studentdetail)
        {
            if (ModelState.IsValid)
            {
                if (Session["User"] != null)
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
                        studentdetail.TrackingID = "TRK_" + (Convert.ToInt32(ab) + 1).ToString();
                    }
                    studentdetail.Status = true;
                    studentdetail.Editingdate = System.DateTime.Now;
                    studentdetail.uid = Convert.ToInt32(Session["User"].ToString());
                    db.studentdetails.Add(studentdetail);
                    db.SaveChanges();
                    TempData["Success"] = "Saved Successfully";

                    ViewBag.AgentId = new SelectList(db.Agents, "AgentId", "AgentName", studentdetail.AgentId);
                    ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "Name", studentdetail.CountryId);

                }
                else
                {
                    return RedirectToAction("Login", "Accounts");
                }
               
            }
            return RedirectToAction("Index");
        }

        // GET: studentdetails/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            studentdetail studentdetail = await db.studentdetails.FindAsync(id);
            if (studentdetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.AgentId = new SelectList(db.Agents, "AgentId", "AgentName", studentdetail.AgentId);
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "Name", studentdetail.CountryId);
           
            return View(studentdetail);
            
        }

        // POST: studentdetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "StudentId,name,dob,gender,fathername,mothername,address,phone,phone2,email,married,board,qualification,marks,gap,gapdetail,refusal,refusaldetail,filetype,CountryId,intake,year,note,itr,uid,TrackingID,date,Editingdate,Status,AgentId")] studentdetail studentdetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentdetail).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.AgentId = new SelectList(db.Agents, "AgentId", "AgentName", studentdetail.AgentId);
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "Name", studentdetail.CountryId);
            return View(studentdetail);
        }

        // GET: studentdetails/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            studentdetail studentdetail = await db.studentdetails.FindAsync(id);
            if (studentdetail == null)
            {
                return HttpNotFound();
            }
            return View(studentdetail);
            
        }

        // POST: studentdetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            studentdetail studentdetail = await db.studentdetails.FindAsync(id);
            db.studentdetails.Remove(studentdetail);
            await db.SaveChangesAsync();
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
