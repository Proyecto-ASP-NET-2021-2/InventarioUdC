using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using Inventario.GUI.Helpers;
using Inventario.GUI.Mapeadores.Parametros;
using Inventario.GUI.Models.Parametros;
using LogicaNegocio.DTO.Parametros;
using LogicaNegocio.Implementacion.Parametros;
using PagedList;

namespace Inventario.GUI.Controllers.Parameters
{
    public class SedeController : Controller
    {
        private ImplSedeLogica logica = new ImplSedeLogica();

        // GET: Sede
        public ActionResult Index(int? page, String filtro = "")
        {
            int numPagina = page ?? 1;
            int totalRegistros;
            
            int registrosPorPagina = DatosGenerales.RegistrosPorPagina;
            IEnumerable<SedeDTO> listaDatos = logica.ListarRegistros(filtro, numPagina, registrosPorPagina, out totalRegistros);
            MapeadorSedeGUI mapper = new MapeadorSedeGUI();
            IEnumerable<ModeloSedeGUI> listaGUI = mapper.MapearTipo1Tipo2(listaDatos);
            var registrosPagina = listaGUI.ToPagedList(numPagina, registrosPorPagina);
            var listaPagina = new StaticPagedList<ModeloSedeGUI>(listaGUI, numPagina, registrosPorPagina, totalRegistros);
            return View(listaPagina);
        }

        // GET: Sede/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SedeDTO SedeDTO = logica.BuscarRegistro(id.Value);
            if (SedeDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorSedeGUI mapper = new MapeadorSedeGUI();
            ModeloSedeGUI modelo = mapper.MapearTipo1Tipo2(SedeDTO);
            return View(modelo);
        }

        // GET: Sede/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sede/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Direccion")] ModeloSedeGUI modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorSedeGUI mapper = new MapeadorSedeGUI();
                SedeDTO SedeDTO = mapper.MapearTipo2Tipo1(modelo);
                logica.GuardarRegistro(SedeDTO);
                return RedirectToAction("Index");
            }

            return View(modelo);
        }

        // GET: Sede/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SedeDTO SedeDTO = logica.BuscarRegistro(id.Value);
            if (SedeDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorSedeGUI mapper = new MapeadorSedeGUI();
            ModeloSedeGUI modelo = mapper.MapearTipo1Tipo2(SedeDTO);
            return View(modelo);
        }

        // POST: Sede/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Direccion")] ModeloSedeGUI modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorSedeGUI mapper = new MapeadorSedeGUI();
                SedeDTO SedeDTO = mapper.MapearTipo2Tipo1(modelo);
                logica.EditarRegistro(SedeDTO);
                return RedirectToAction("Index");
            }
            return View(modelo);
        }

        // GET: Sede/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SedeDTO SedeDTO = logica.BuscarRegistro(id.Value);
            if (SedeDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorSedeGUI mapper = new MapeadorSedeGUI();
            ModeloSedeGUI modelo = mapper.MapearTipo1Tipo2(SedeDTO);
            return View(modelo);
        }

        // POST: Sede/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            bool respuesta = logica.EliminarRegistro(id);
            if (respuesta)
            {
                return RedirectToAction("Index");
            }
            else
            {
                SedeDTO SedeDTO = logica.BuscarRegistro(id);
                if (SedeDTO == null)
                {
                    return HttpNotFound();
                }
                MapeadorSedeGUI mapper = new MapeadorSedeGUI();
                ViewBag.mensaje = Mensajes.mensajeErrorEliminar;
                ModeloSedeGUI modelo = mapper.MapearTipo1Tipo2(SedeDTO);
                return View(modelo);
            }
        }
    }

}
