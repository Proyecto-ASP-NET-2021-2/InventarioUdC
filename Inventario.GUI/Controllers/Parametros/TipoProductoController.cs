using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Inventario.GUI.ModeloBD;

namespace Inventario.GUI.Controllers.Parametros
{
    public class TipoProductoController : Controller
    {
        private InventarioBDEntities db = new InventarioBDEntities();

        // GET: TipoProducto
        public ActionResult Index()
        {
            return View(db.tb_tipoProducto.ToList());
        }

        // GET: TipoProducto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_tipoProducto tb_tipoProducto = db.tb_tipoProducto.Find(id);
            if (tb_tipoProducto == null)
            {
                return HttpNotFound();
            }
            return View(tb_tipoProducto);
        }

        // GET: TipoProducto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoProducto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre")] tb_tipoProducto tb_tipoProducto)
        {
            if (ModelState.IsValid)
            {
                db.tb_tipoProducto.Add(tb_tipoProducto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_tipoProducto);
        }

        // GET: TipoProducto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_tipoProducto tb_tipoProducto = db.tb_tipoProducto.Find(id);
            if (tb_tipoProducto == null)
            {
                return HttpNotFound();
            }
            return View(tb_tipoProducto);
        }

        // POST: TipoProducto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre")] tb_tipoProducto tb_tipoProducto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_tipoProducto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_tipoProducto);
        }

        // GET: TipoProducto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_tipoProducto tb_tipoProducto = db.tb_tipoProducto.Find(id);
            if (tb_tipoProducto == null)
            {
                return HttpNotFound();
            }
            return View(tb_tipoProducto);
        }

        // POST: TipoProducto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_tipoProducto tb_tipoProducto = db.tb_tipoProducto.Find(id);
            db.tb_tipoProducto.Remove(tb_tipoProducto);
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
