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
    public class Tipo_BitacoraController : Controller
    {
        private ServiciosWebEntities db = new ServiciosWebEntities();

        // GET: Tipo_Bitacora
        public ActionResult Index()
        {
            return View(db.Tipo_Bitacora.ToList());
        }

        // GET: Tipo_Bitacora/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Bitacora tipo_Bitacora = db.Tipo_Bitacora.Find(id);
            if (tipo_Bitacora == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Bitacora);
        }

        // GET: Tipo_Bitacora/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tipo_Bitacora/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Cod_Tipo_Bitacora,Tipo_Bitacora1")] Tipo_Bitacora tipo_Bitacora)
        {
            if (ModelState.IsValid)
            {
                db.Tipo_Bitacora.Add(tipo_Bitacora);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipo_Bitacora);
        }

        // GET: Tipo_Bitacora/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Bitacora tipo_Bitacora = db.Tipo_Bitacora.Find(id);
            if (tipo_Bitacora == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Bitacora);
        }

        // POST: Tipo_Bitacora/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Cod_Tipo_Bitacora,Tipo_Bitacora1")] Tipo_Bitacora tipo_Bitacora)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_Bitacora).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipo_Bitacora);
        }

        // GET: Tipo_Bitacora/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Bitacora tipo_Bitacora = db.Tipo_Bitacora.Find(id);
            if (tipo_Bitacora == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Bitacora);
        }

        // POST: Tipo_Bitacora/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tipo_Bitacora tipo_Bitacora = db.Tipo_Bitacora.Find(id);
            db.Tipo_Bitacora.Remove(tipo_Bitacora);
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
