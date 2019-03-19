﻿using System;
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
    public class DiscoController : Controller
    {
        private ServiciosWebEntities db = new ServiciosWebEntities();

        // GET: Disco
        public ActionResult Index()
        {
            return View(db.Discoes.ToList());
        }

        // GET: Disco/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Disco disco = db.Discoes.Find(id);
            if (disco == null)
            {
                return HttpNotFound();
            }
            return View(disco);
        }

        // GET: Disco/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Disco/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Disco,Nombre_Disco")] Disco disco)
        {
            if (ModelState.IsValid)
            {
                db.Discoes.Add(disco);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(disco);
        }

        // GET: Disco/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Disco disco = db.Discoes.Find(id);
            if (disco == null)
            {
                return HttpNotFound();
            }
            return View(disco);
        }

        // POST: Disco/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Disco,Nombre_Disco")] Disco disco)
        {
            if (ModelState.IsValid)
            {
                db.Entry(disco).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(disco);
        }

        // GET: Disco/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Disco disco = db.Discoes.Find(id);
            if (disco == null)
            {
                return HttpNotFound();
            }
            return View(disco);
        }

        // POST: Disco/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Disco disco = db.Discoes.Find(id);
            db.Discoes.Remove(disco);
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
