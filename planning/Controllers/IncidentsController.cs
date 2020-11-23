using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using planning.Models;
using System.Globalization;
using planning.Utils;

namespace planning.Controllers
{
    [Authorize]
    public class IncidentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Incidents
        public async Task<ActionResult> Index()
        
        {

            if (User.IsInRole("CanManage"))
            {
                return View(await db.Incidents.ToListAsync());
            }
           else
           {
               return View("ReadOnlyList", await db.Incidents.ToListAsync());
           }
        }

        // GET: Incidents/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Incident incident = await db.Incidents.FindAsync(id);
            if (incident == null)
            {
                return HttpNotFound();
            }
            return View(incident);
        }

        // GET: Incidents/Create
        public ActionResult Create()
        {
            if (User.IsInRole("CanManage"))
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Incidents");
            }
        }

        // POST: Incidents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IncidentId,PlannedFor,Client,Description,Priority,User,UserId,OpenedDate,Done,Note,Status,IncidentNumber")] Incident incident)
        {
            if (ModelState.IsValid)
            {
              //   DateTime parsedDate;
            //    var test = incident.PlannedFor.ToString();
             //   if (DateTime.TryParseExact(incident.PlannedFor.ToString(), "yyyy-MM-dd", null, DateTimeStyles.None, out parsedDate))

                    incident.PlannedFor.ToString();
                db.Incidents.Add(incident);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }


            return View(incident);
        }

        // GET: Incidents/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Incident incident = await db.Incidents.FindAsync(id);
            if (incident == null)
            {
                return HttpNotFound();
            }
            if (User.IsInRole("CanManage"))
            {
                return View(incident);
            }
            else
            {
                return View("EditOnlyList", incident);
            }


        }

        // POST: Incidents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IncidentId,IncidentNumber,PlannedFor,Client,Description,Priority,User,Date,OpenedDate,Done,Note,Status")] Incident incident)
        {
            if (ModelState.IsValid)
            {
                db.Entry(incident).State = EntityState.Modified;
                incident.Date = DateTime.Now;
                if(incident.Status.Equals("Blocked"))

                {

                    MailSenderUti.SendMail(incident.IncidentNumber,User.Identity.Name);
                }
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(incident);
        }

        // GET: Incidents/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Incident incident = await db.Incidents.FindAsync(id);
            if (incident == null)
            {
                return HttpNotFound();
            }
            return View(incident);
        }

        // POST: Incidents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Incident incident = await db.Incidents.FindAsync(id);
            db.Incidents.Remove(incident);
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
