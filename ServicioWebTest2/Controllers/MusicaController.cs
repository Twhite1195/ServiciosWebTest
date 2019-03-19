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
    public class MusicaController : Controller
    {
        private ServiciosWebEntities db = new ServiciosWebEntities();

        // GET: Musica
        public ActionResult Index()
        {
            var musicas = db.Musicas.Include(m => m.Disco).Include(m => m.Disquera).Include(m => m.Genero).Include(m => m.Idioma).Include(m => m.Pai);
            return View(musicas.ToList());
        }

        // GET: Musica/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musica musica = db.Musicas.Find(id);
            if (musica == null)
            {
                return HttpNotFound();
            }
            return View(musica);
        }

        // GET: Musica/Create
        public ActionResult Create()
        {
            ViewBag.Disco_Musica = new SelectList(db.Discoes, "ID_Disco", "Nombre_Disco");
            ViewBag.Disquera_Musica = new SelectList(db.Disqueras, "ID_Disquera", "Nombre_Disquera");
            ViewBag.Genero_Musica = new SelectList(db.Generoes, "ID_Genero", "Nombre_Genero");
            ViewBag.Idioma_Musica = new SelectList(db.Idiomas, "ID_Idioma", "Nombre_Idioma");
            ViewBag.Pais_Musica = new SelectList(db.Pais, "ID_Pais", "Nombre_Pais");
            return View();
        }

        // POST: Musica/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Musica,Genero_Musica,Nombre_Musica,Tipo_Inerpretacion_Musica,Idioma_Musica,Pais_Musica,Disquera_Musica,Disco_Musica,Ano_Musica")] Musica musica)
        {
            if (ModelState.IsValid)
            {
                db.Musicas.Add(musica);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Disco_Musica = new SelectList(db.Discoes, "ID_Disco", "Nombre_Disco", musica.Disco_Musica);
            ViewBag.Disquera_Musica = new SelectList(db.Disqueras, "ID_Disquera", "Nombre_Disquera", musica.Disquera_Musica);
            ViewBag.Genero_Musica = new SelectList(db.Generoes, "ID_Genero", "Nombre_Genero", musica.Genero_Musica);
            ViewBag.Idioma_Musica = new SelectList(db.Idiomas, "ID_Idioma", "Nombre_Idioma", musica.Idioma_Musica);
            ViewBag.Pais_Musica = new SelectList(db.Pais, "ID_Pais", "Nombre_Pais", musica.Pais_Musica);
            return View(musica);
        }

        // GET: Musica/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musica musica = db.Musicas.Find(id);
            if (musica == null)
            {
                return HttpNotFound();
            }
            ViewBag.Disco_Musica = new SelectList(db.Discoes, "ID_Disco", "Nombre_Disco", musica.Disco_Musica);
            ViewBag.Disquera_Musica = new SelectList(db.Disqueras, "ID_Disquera", "Nombre_Disquera", musica.Disquera_Musica);
            ViewBag.Genero_Musica = new SelectList(db.Generoes, "ID_Genero", "Nombre_Genero", musica.Genero_Musica);
            ViewBag.Idioma_Musica = new SelectList(db.Idiomas, "ID_Idioma", "Nombre_Idioma", musica.Idioma_Musica);
            ViewBag.Pais_Musica = new SelectList(db.Pais, "ID_Pais", "Nombre_Pais", musica.Pais_Musica);
            return View(musica);
        }

        // POST: Musica/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Musica,Genero_Musica,Nombre_Musica,Tipo_Inerpretacion_Musica,Idioma_Musica,Pais_Musica,Disquera_Musica,Disco_Musica,Ano_Musica")] Musica musica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(musica).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Disco_Musica = new SelectList(db.Discoes, "ID_Disco", "Nombre_Disco", musica.Disco_Musica);
            ViewBag.Disquera_Musica = new SelectList(db.Disqueras, "ID_Disquera", "Nombre_Disquera", musica.Disquera_Musica);
            ViewBag.Genero_Musica = new SelectList(db.Generoes, "ID_Genero", "Nombre_Genero", musica.Genero_Musica);
            ViewBag.Idioma_Musica = new SelectList(db.Idiomas, "ID_Idioma", "Nombre_Idioma", musica.Idioma_Musica);
            ViewBag.Pais_Musica = new SelectList(db.Pais, "ID_Pais", "Nombre_Pais", musica.Pais_Musica);
            return View(musica);
        }

        // GET: Musica/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musica musica = db.Musicas.Find(id);
            if (musica == null)
            {
                return HttpNotFound();
            }
            return View(musica);
        }

        // POST: Musica/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Musica musica = db.Musicas.Find(id);
            db.Musicas.Remove(musica);
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
