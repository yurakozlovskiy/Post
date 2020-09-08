using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DB;

namespace PostWeb.Controllers
{
    public class DeliveryStatusController : Controller
    {
        private PostEntities db = new PostEntities();

        // GET: DeliveryStatus
        public ActionResult Index()
        {
            return View(db.DeliveryStatus.ToList());
        }

        // GET: DeliveryStatus/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryStatus deliveryStatus = db.DeliveryStatus.Find(id);
            if (deliveryStatus == null)
            {
                return HttpNotFound();
            }
            return View(deliveryStatus);
        }

        // GET: DeliveryStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DeliveryStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Status")] DeliveryStatus deliveryStatus)
        {
            if (ModelState.IsValid)
            {
                db.DeliveryStatus.Add(deliveryStatus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(deliveryStatus);
        }

        // GET: DeliveryStatus/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryStatus deliveryStatus = db.DeliveryStatus.Find(id);
            if (deliveryStatus == null)
            {
                return HttpNotFound();
            }
            return View(deliveryStatus);
        }

        // POST: DeliveryStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Status")] DeliveryStatus deliveryStatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deliveryStatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(deliveryStatus);
        }

        // GET: DeliveryStatus/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryStatus deliveryStatus = db.DeliveryStatus.Find(id);
            if (deliveryStatus == null)
            {
                return HttpNotFound();
            }
            return View(deliveryStatus);
        }

        // POST: DeliveryStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            DeliveryStatus deliveryStatus = db.DeliveryStatus.Find(id);
            db.DeliveryStatus.Remove(deliveryStatus);
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
