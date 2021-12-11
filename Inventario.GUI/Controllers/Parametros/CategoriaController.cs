
using Inventario.GUI.Helpers;
using Inventario.GUI.Mapeadores.Parametros.Categoria;
using Inventario.GUI.Models.Parametros;
using LogicaNegocio.DTO.Parametros;
using LogicaNegocio.Implementacion.Parametros.Categoria;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web.Mvc;

namespace Inventario.GUI.Controllers.Parametros
{
    public class CategoriaController : Controller
    {
        private ImplCategoriaLogica acceso = new ImplCategoriaLogica();

        // GET: Categoria
        public ActionResult Index(int? page,String filtro = " ")
        {
            int numPagina = page ?? 1;
            int totalRegistros;
            int registrosPorPagina = DatosGenerales.RegistrosPorPagina;
            IEnumerable<CategoriaDTO> listaDatos = acceso.ListarRegistros(filtro, numPagina, registrosPorPagina, out totalRegistros);
            MapeadorCategoriaGUI mapper = new MapeadorCategoriaGUI();
            IEnumerable<ModeloCategoriaGUI> listaGUI = mapper.MapearTipo1Tipo2(listaDatos);
            //var registrosPagina = listaGUI.ToPagedList(numPagina, registrosPorPagina);
            var listaPagina = new StaticPagedList<ModeloCategoriaGUI>(listaGUI, numPagina, registrosPorPagina, totalRegistros);
            return View(listaPagina);
        }

        // GET: Categoria/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaDTO CategoriaDTO = acceso.BuscarRegistro(id.Value);
            if (CategoriaDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorCategoriaGUI mapper = new MapeadorCategoriaGUI();
            ModeloCategoriaGUI modelo = mapper.MapearTipo1Tipo2(CategoriaDTO);
            return View(modelo);
        }

        // GET: Categoria/Create
        public ActionResult Create()
        {
            //hay que cambira por producto ****************************************************************
            IEnumerable<ModeloCategoriaGUI> listado = obtenerListadoProductos();
            ModeloFotosGUI modelo = new ModeloFotosGUI();
            modelo.ListaProducto = listado;
            return View(modelo);
        }

        private IEnumerable<ModeloCategoriaGUI> obtenerListadoProductos()
        {
            ImplCategoriaLogica producto = new ImplCategoriaLogica();
            var listaProductos = producto.ListarRegistros();
            MapeadorCategoriaGUI mapeador = new MapeadorCategoriaGUI();
            var listado = mapeador.MapearTipo1Tipo2(listaProductos);
            return listado;
        }
        // POST: Categoria/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre")] ModeloCategoriaGUI modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorCategoriaGUI mapper = new MapeadorCategoriaGUI();
                CategoriaDTO CategoriaDTO = mapper.MapearTipo2Tipo1(modelo);
                acceso.GuardarRegistro(CategoriaDTO);
                return RedirectToAction("Index");
            }

            return View(modelo);
        }

        // GET: Categoria/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaDTO CategoriaDTO = acceso.BuscarRegistro(id.Value);
            if (CategoriaDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorCategoriaGUI mapper = new MapeadorCategoriaGUI();
            ModeloCategoriaGUI modelo = mapper.MapearTipo1Tipo2(CategoriaDTO);
            return View(modelo);
        }

        // POST: Categoria/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre")] ModeloCategoriaGUI modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorCategoriaGUI mapper = new MapeadorCategoriaGUI();
                CategoriaDTO CategoriaDTO = mapper.MapearTipo2Tipo1(modelo);
                acceso.EditarRegistro(CategoriaDTO);
                return RedirectToAction("Index");
            }
            return View(modelo);
        }

        // GET: Categoria/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaDTO CategoriaDTO = acceso.BuscarRegistro(id.Value);
            if (CategoriaDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorCategoriaGUI mapper = new MapeadorCategoriaGUI();
            ModeloCategoriaGUI modelo = mapper.MapearTipo1Tipo2(CategoriaDTO);
            return View(modelo);
        }

        // POST: Categoria/Delete/5
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
                CategoriaDTO CategoriaDTO = acceso.BuscarRegistro(id);
                if (CategoriaDTO == null)
                {
                    return HttpNotFound();
                }
                MapeadorCategoriaGUI mapper = new MapeadorCategoriaGUI();
                ViewBag.mensaje = Mensajes.mensajeErrorEliminar;
                ModeloCategoriaGUI modelo = mapper.MapearTipo1Tipo2(CategoriaDTO);
                return View(modelo);
            }


        }

        [HttpGet]
        public ActionResult UploadFile(int? id)
        {
            return View();
        }

        private ModeloCargaImagenProducto CrearModeloCargarImagenProducto(int? id)
        {
            IEnumerable<fotoCategoriaDTO> listaDto = acceso.ListarFotosProductosPorId(id.Value);
            MapeadorFotoCategoriaGUI mapeador = new MapeadorFotoCategoriaGUI();
            IEnumerable<ModeloFotoCategoriaGUI> listaProducto = mapeador.MapearTipo1Tipo2(listaDto);
            if (listaProducto == null)
            {
                listaProducto = new List<ModeloFotoCategoriaGUI>();
            }
            ModeloCargaImagenProducto modelo = new ModeloCargaImagenProducto()
            {
                Id = id.Value,
                ListadoImagenesProducto = (IEnumerable<ModeloFotosProductoGUI>)listaProducto
            };
            return modelo;
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
                    string rutaCarpeta = DatosGenerales.RutaArchivosProducto;
                    string rutaCompletaArchivo = Path.Combine(Server.MapPath(rutaCarpeta), nombreArchivo);
                    modelo.Archivo.SaveAs(rutaCompletaArchivo);
                    fotoCategoriaDTO dto = new fotoCategoriaDTO()
                    {
                        IdProducto = modelo.Id,
                        NombreFoto = nombreArchivo
                    };

                //guardar nombre de archivo base de datos
                    acceso.guardarNombreFoto(dto);
                    ModeloCargaImagenProducto modeloview = CrearModeloCargarImagenProducto(modelo.Id);
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
