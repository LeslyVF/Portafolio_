using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Portafolio_.Models;

namespace Portafolio_.Controllers
{
    public class TestimonioController : Controller
    {
        private portafolioEntities db = new portafolioEntities();

        // GET: Testimonio
        public ActionResult Index()
        {
            var testimonio = db.Testimonio.Include(t => t.AspNetUsers);
            return View(testimonio.ToList());
        }

        // GET: Testimonio/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Testimonio testimonio = db.Testimonio.Find(id);
            if (testimonio == null)
            {
                return HttpNotFound();
            }
            return View(testimonio);
        }

        // GET: Testimonio/Create
        public ActionResult Create()
        {
            ViewBag.UsuarioId = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: Testimonio/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,UsuarioId,IP,Nombre,Comentario,Fecha")] Testimonio testimonio)
        {
            if (ModelState.IsValid)
            {
                db.Testimonio.Add(testimonio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UsuarioId = new SelectList(db.AspNetUsers, "Id", "Email", testimonio.UsuarioId);
            return View(testimonio);
        }

        // GET: Testimonio/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Testimonio testimonio = db.Testimonio.Find(id);
            if (testimonio == null)
            {
                return HttpNotFound();
            }
            ViewBag.UsuarioId = new SelectList(db.AspNetUsers, "Id", "Email", testimonio.UsuarioId);
            return View(testimonio);
        }

        // POST: Testimonio/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,UsuarioId,IP,Nombre,Comentario,Fecha")] Testimonio testimonio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(testimonio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UsuarioId = new SelectList(db.AspNetUsers, "Id", "Email", testimonio.UsuarioId);
            return View(testimonio);
        }

        // GET: Testimonio/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Testimonio testimonio = db.Testimonio.Find(id);
            if (testimonio == null)
            {
                return HttpNotFound();
            }
            return View(testimonio);
        }

        // POST: Testimonio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Testimonio testimonio = db.Testimonio.Find(id);
            db.Testimonio.Remove(testimonio);
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
