using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ServicioWebTest2.Models;

namespace ServicioWebTest2.Controllers
{
    public class DisqueraController : Controller
    {
        private ServiciosWebEntities db = new ServiciosWebEntities();

        // GET: Disquera
        public ActionResult Index()
        {
            return View(db.Disqueras.ToList());
        }

        // GET: Disquera/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Disquera disquera = db.Disqueras.Find(id);
            if (disquera == null)
            {
                return HttpNotFound();
            }
            return View(disquera);
        }

        // GET: Disquera/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Disquera/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Disquera,Nombre_Disquera")] Disquera disquera)
        {
            if (ModelState.IsValid)
            {
                db.Disqueras.Add(disquera);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(disquera);
        }

        // GET: Disquera/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Disquera disquera = db.Disqueras.Find(id);
            if (disquera == null)
            {
                return HttpNotFound();
            }
            return View(disquera);
        }

        // POST: Disquera/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Disquera,Nombre_Disquera")] Disquera disquera)
        {
            if (ModelState.IsValid)
            {
                db.Entry(disquera).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(disquera);
        }

        // GET: Disquera/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Disquera disquera = db.Disqueras.Find(id);
            if (disquera == null)
            {
                return HttpNotFound();
            }
            return View(disquera);
        }

        // POST: Disquera/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Disquera disquera = db.Disqueras.Find(id);
            db.Disqueras.Remove(disquera);
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
