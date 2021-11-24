using System.Net;
using System.Web.Mvc;
using System;
using Inventario.GUI.Models.Parametros;
using System.Collections.Generic;
using Concesionario.GUI.Helpers;
using System.IO;
using LogicaNegocio.Implementacion.Parametros.Espacio;
using Inventario.GUI.Mapeadores.Parametros.Espacio;
using LogicaNegocio.DTO.Parametros;

namespace Inventario.GUI.Controllers.Parametros
{
    public class EspacioController : Controller
    {
        private ImplEspacioLogica acceso = new ImplEspacioLogica();

        // GET: Espacio
        public ActionResult Index(String filtro = " ")
        {
            IEnumerable<EspacioDTO> listaDatos = acceso.ListarRegistros(String.Empty);
            MapeadorEspacioGUI mapper = new MapeadorEspacioGUI();
            IEnumerable<ModeloEspacioGUI> listaGUI = mapper.MapearTipo1Tipo2(listaDatos);

            return View(listaGUI);
        }

        // GET: Espacio/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EspacioDTO EspacioDTO = acceso.BuscarRegistro(id.Value);
            if (EspacioDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorEspacioGUI mapper = new MapeadorEspacioGUI();
            ModeloEspacioGUI modelo = mapper.MapearTipo1Tipo2(EspacioDTO);
            return View(modelo);
        }

        // GET: Espacio/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Espacio/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre")] ModeloEspacioGUI modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorEspacioGUI mapper = new MapeadorEspacioGUI();
                EspacioDTO EspacioDTO = mapper.MapearTipo2Tipo1(modelo);
                acceso.GuardarRegistro(EspacioDTO);
                return RedirectToAction("Index");
            }

            return View(modelo);
        }

        // GET: Espacio/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EspacioDTO EspacioDTO = acceso.BuscarRegistro(id.Value);
            if (EspacioDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorEspacioGUI mapper = new MapeadorEspacioGUI();
            ModeloEspacioGUI modelo = mapper.MapearTipo1Tipo2(EspacioDTO);
            return View(modelo);
        }

        // POST: Espacio/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre")] ModeloEspacioGUI modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorEspacioGUI mapper = new MapeadorEspacioGUI();
                EspacioDTO EspacioDTO = mapper.MapearTipo2Tipo1(modelo);
                acceso.EditarRegistro(EspacioDTO);
                return RedirectToAction("Index");
            }
            return View(modelo);
        }

        // GET: Espacio/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EspacioDTO EspacioDTO = acceso.BuscarRegistro(id.Value);
            if (EspacioDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorEspacioGUI mapper = new MapeadorEspacioGUI();
            ModeloEspacioGUI modelo = mapper.MapearTipo1Tipo2(EspacioDTO);
            return View(modelo);
        }

        // POST: Espacio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            bool respuesta = acceso.EliminarRegistro(id);
            if (respuesta)
            {
                return RedirectToAction("Index");
            }
            else
            {
                EspacioDTO EspacioDTO = acceso.BuscarRegistro(id);
                if (EspacioDTO == null)
                {
                    return HttpNotFound();
                }
                MapeadorEspacioGUI mapper = new MapeadorEspacioGUI();
                ModeloEspacioGUI modelo = mapper.MapearTipo1Tipo2(EspacioDTO);
                ViewBag.mensaje = Mensajes.MensajeErrorEliminar;
                return View(modelo);
            }


        }
        [HttpGet]
        public ActionResult UploadFile(int? id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadFile(ModeloCargaImagenProducto modelo)
        {
            try
            {
                if (modelo.Archivo.ContentLength > 0)
                {
                    DateTime ahora = DateTime.Now;
                    string fechaNombre = String.Format("{0}_{1}_{2}_{3}_{4}_{5}", ahora.Day, ahora.Month, ahora.Year, ahora.Hour, ahora.Minute, ahora.Millisecond);
                    string nombreArchivo = String.Concat(fechaNombre, "_", Path.GetFileName(modelo.Archivo.FileName));
                    string rutaArchivo = Path.Combine(Server.MapPath("~/UploadFiles/FotosEspacio"), nombreArchivo);
                    modelo.Archivo.SaveAs(rutaArchivo);
                    //guardar nombre de archivo base de datos

                    ViewBag.UploadFileMessage = "Archivo cargado correctamente";
                    return View();
                }
                ViewBag.UploadFileMessage = "Por favor seleccione al menos un archivo a cargar";
                return View();
            }
            catch (Exception e)
            {
                ViewBag.UploadFileMessage = "Error al cargar el archivo";
                return View();
            }

        }
    }
}
