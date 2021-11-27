﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Inventario.GUI.ModeloBD;

namespace Inventario.GUI.Controllers.Producto
{
    public class ProductoController : Controller
    {
        private InventarioBDEntities db = new InventarioBDEntities();

        // GET: Producto
        public ActionResult Index()
        {
            var tb_producto = db.tb_producto.Include(t => t.tb_categoria).Include(t => t.tb_espacio).Include(t => t.tb_marca).Include(t => t.tb_persona).Include(t => t.tb_tipoProducto);
            return View(tb_producto.ToList());
        }

        // GET: Producto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_producto tb_producto = db.tb_producto.Find(id);
            if (tb_producto == null)
            {
                return HttpNotFound();
            }
            return View(tb_producto);
        }

        // GET: Producto/Create
        public ActionResult Create()
        {
            ViewBag.id_categoria = new SelectList(db.tb_categoria, "id", "nombre");
            ViewBag.id_espacio = new SelectList(db.tb_espacio, "id", "nombre");
            ViewBag.id_marca = new SelectList(db.tb_marca, "id", "nombre");
            ViewBag.id_persona = new SelectList(db.tb_persona, "id", "nombres");
            ViewBag.id_tipoProducto = new SelectList(db.tb_tipoProducto, "id", "nombre");
            return View();
        }

        // POST: Producto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,fechaRegistro,serial,id_marca,id_categoria,id_tipoProducto,id_espacio,id_persona")] tb_producto tb_producto)
        {
            if (ModelState.IsValid)
            {
                db.tb_producto.Add(tb_producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_categoria = new SelectList(db.tb_categoria, "id", "nombre", tb_producto.id_categoria);
            ViewBag.id_espacio = new SelectList(db.tb_espacio, "id", "nombre", tb_producto.id_espacio);
            ViewBag.id_marca = new SelectList(db.tb_marca, "id", "nombre", tb_producto.id_marca);
            ViewBag.id_persona = new SelectList(db.tb_persona, "id", "nombres", tb_producto.id_persona);
            ViewBag.id_tipoProducto = new SelectList(db.tb_tipoProducto, "id", "nombre", tb_producto.id_tipoProducto);
            return View(tb_producto);
        }

        // GET: Producto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_producto tb_producto = db.tb_producto.Find(id);
            if (tb_producto == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_categoria = new SelectList(db.tb_categoria, "id", "nombre", tb_producto.id_categoria);
            ViewBag.id_espacio = new SelectList(db.tb_espacio, "id", "nombre", tb_producto.id_espacio);
            ViewBag.id_marca = new SelectList(db.tb_marca, "id", "nombre", tb_producto.id_marca);
            ViewBag.id_persona = new SelectList(db.tb_persona, "id", "nombres", tb_producto.id_persona);
            ViewBag.id_tipoProducto = new SelectList(db.tb_tipoProducto, "id", "nombre", tb_producto.id_tipoProducto);
            return View(tb_producto);
        }

        // POST: Producto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,fechaRegistro,serial,id_marca,id_categoria,id_tipoProducto,id_espacio,id_persona")] tb_producto tb_producto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_categoria = new SelectList(db.tb_categoria, "id", "nombre", tb_producto.id_categoria);
            ViewBag.id_espacio = new SelectList(db.tb_espacio, "id", "nombre", tb_producto.id_espacio);
            ViewBag.id_marca = new SelectList(db.tb_marca, "id", "nombre", tb_producto.id_marca);
            ViewBag.id_persona = new SelectList(db.tb_persona, "id", "nombres", tb_producto.id_persona);
            ViewBag.id_tipoProducto = new SelectList(db.tb_tipoProducto, "id", "nombre", tb_producto.id_tipoProducto);
            return View(tb_producto);
        }

        // GET: Producto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_producto tb_producto = db.tb_producto.Find(id);
            if (tb_producto == null)
            {
                return HttpNotFound();
            }
            return View(tb_producto);
        }

        // POST: Producto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_producto tb_producto = db.tb_producto.Find(id);
            db.tb_producto.Remove(tb_producto);
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
