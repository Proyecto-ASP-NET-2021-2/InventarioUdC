using System.Net;
using System.Web.Mvc;
using System;
using Inventario.GUI.Models.Parametros;
using System.Collections.Generic;

using System.IO;
using PagedList;
using LogicaNegocio.Implementacion.Parametros.Espacio;
using Inventario.GUI.Mapeadores.Parametros.Espacio;
using LogicaNegocio.DTO.Parametros;
using LogicaNegocio.Implementacion.Parametros;
using Inventario.GUI.Helpers;
using Inventario.GUI.Models.Piso;
using LogicaNegocio.Implementacion.Piso;
using Inventario.GUI.Mapeadores.Piso;
using LogicaNegocio.DTO.Piso;

namespace Inventario.GUI.Controllers.Parametros
{
    public class EspacioController : Controller
    {
        private ImplEspacioLogica acceso = new ImplEspacioLogica();

        // GET: Espacio
        public ActionResult Index(int? page, String filtro = " ")
        {
            int numPagina = page ?? 1;
            int totalRegistros;
            int registrosPorPagina = DatosGenerales.RegistrosPorPagina;
            IEnumerable<EspacioDTO> listaDatos = acceso.ListarRegistros(filtro, numPagina, registrosPorPagina, out totalRegistros);
            MapeadorEspacioGUI mapper = new MapeadorEspacioGUI();
            IEnumerable<ModeloEspacioGUI> listaGUI = mapper.MapearTipo1Tipo2(listaDatos);
            //var registrosPagina = listaGUI.ToPagedList(numPagina, registrosPorPagina);
            var listaPagina = new StaticPagedList<ModeloEspacioGUI>(listaGUI, numPagina, registrosPorPagina, totalRegistros);
            return View(listaPagina);
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
            //hay que cambira por piso ****************************************************************
           // IEnumerable<ModeloPisoGUI> listado = obtenerListadoPisos();
            ModeloEspacioGUI modelo = new ModeloEspacioGUI();
            ObtenerListadoPiso(modelo);
            //modelo.ListaPisos = listado;
            return View(modelo);
        }

        /*
        private IEnumerable<ModeloPisoGUI> obtenerListadoPisos()
        {
            ImplPisoLogica pisos = new ImplPisoLogica();
            var listaPisos = pisos.ListarRegistros();
            MapeadorPisoGUI mapeador = new MapeadorPisoGUI();
            var listado = mapeador.MapearTipo1Tipo2(listaPisos);
            return listado;
        }*/

        private void ObtenerListadoPiso(ModeloEspacioGUI modelo)
        {
            ImplPisoLogica logicaPiso = new ImplPisoLogica();
            IEnumerable<PisoDTO> listaDTO = logicaPiso.ListarRegistros();
            MapeadorPisoGUI mapeador = new MapeadorPisoGUI();
            modelo.ListaPisos = mapeador.MapearTipo1Tipo2(listaDTO);
        }

        // POST: Espacio/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ModeloEspacioGUI modelo)
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
            ObtenerListadoPiso(modelo);
            return View(modelo);
        }

        // POST: Espacio/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ModeloEspacioGUI modelo)
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
                ViewBag.mensaje = Mensajes.mensajeErrorEliminar;
                ModeloEspacioGUI modelo = mapper.MapearTipo1Tipo2(EspacioDTO);
                return View(modelo);
            }


        } 

    }
}
