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
    public class AgentsController : Controller
    {
        private dbcontext db = new dbcontext();

        // GET: Agents
        public async Task<ActionResult> Index()
        {
            return View(await db.Agents.ToListAsync());
        }

        // GET: Agents/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agents agents = await db.Agents.FindAsync(id);
            if (agents == null)
            {
                return HttpNotFound();
            }
            return View(agents);
        }

        // GET: Agents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Agents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "AgentId,AgentName")] Agents agents)
        {
            if (ModelState.IsValid)
            {
                db.Agents.Add(agents);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(agents);
        }

        // GET: Agents/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agents agents = await db.Agents.FindAsync(id);
            if (agents == null)
            {
                return HttpNotFound();
            }
            return View(agents);
        }

        // POST: Agents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "AgentId,AgentName")] Agents agents)
        {
            if (ModelState.IsValid)
            {
                db.Entry(agents).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(agents);
        }

        // GET: Agents/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agents agents = await db.Agents.FindAsync(id);
            if (agents == null)
            {
                return HttpNotFound();
            }
            return View(agents);
        }

        // POST: Agents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Agents agents = await db.Agents.FindAsync(id);
            db.Agents.Remove(agents);
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
