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
    public class IdiomaController : Controller
    {
        private ServiciosWebEntities db = new ServiciosWebEntities();

        // GET: Idioma
        public ActionResult Index()
        {
            return View(db.Idiomas.ToList());
        }

        // GET: Idioma/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Idioma idioma = db.Idiomas.Find(id);
            if (idioma == null)
            {
                return HttpNotFound();
            }
            return View(idioma);
        }

        // GET: Idioma/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Idioma/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Idioma,Nombre_Idioma")] Idioma idioma)
        {
            if (ModelState.IsValid)
            {
                db.Idiomas.Add(idioma);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(idioma);
        }

        // GET: Idioma/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Idioma idioma = db.Idiomas.Find(id);
            if (idioma == null)
            {
                return HttpNotFound();
            }
            return View(idioma);
        }

        // POST: Idioma/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Idioma,Nombre_Idioma")] Idioma idioma)
        {
            if (ModelState.IsValid)
            {
                db.Entry(idioma).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(idioma);
        }

        // GET: Idioma/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Idioma idioma = db.Idiomas.Find(id);
            if (idioma == null)
            {
                return HttpNotFound();
            }
            return View(idioma);
        }

        // POST: Idioma/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Idioma idioma = db.Idiomas.Find(id);
            db.Idiomas.Remove(idioma);
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
