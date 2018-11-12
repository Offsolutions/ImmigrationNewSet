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
    public class PackageDetailsController : Controller
    {
        private dbcontext db = new dbcontext();

        // GET: PackageDetails
        public async Task<ActionResult> Index()
        {
            return View(await db.PackageDetails.ToListAsync());
        }

        // GET: PackageDetails/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PackageDetails packageDetails = await db.PackageDetails.FindAsync(id);
            if (packageDetails == null)
            {
                return HttpNotFound();
            }
            return View(packageDetails);
        }

        // GET: PackageDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PackageDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PackageId,PackageName,Description")] PackageDetails packageDetails)
        {
            if (ModelState.IsValid)
            {
                db.PackageDetails.Add(packageDetails);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(packageDetails);
        }

        // GET: PackageDetails/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PackageDetails packageDetails = await db.PackageDetails.FindAsync(id);
            if (packageDetails == null)
            {
                return HttpNotFound();
            }
            return View(packageDetails);
        }

        // POST: PackageDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PackageId,PackageName,Description")] PackageDetails packageDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(packageDetails).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(packageDetails);
        }

        // GET: PackageDetails/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PackageDetails packageDetails = await db.PackageDetails.FindAsync(id);
            if (packageDetails == null)
            {
                return HttpNotFound();
            }
            return View(packageDetails);
        }

        // POST: PackageDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PackageDetails packageDetails = await db.PackageDetails.FindAsync(id);
            db.PackageDetails.Remove(packageDetails);
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
