using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using LogicaNegocio.Implementacion.Parametros;
using LogicaNegocio.DTO.Parametros;
using Inventario.GUI.Mapeadores.Parametros;
using Inventario.GUI.Models.Parametros;
using Concesionario.GUI.Helpers;
using System.Web;
using System.IO;
using PagedList;
using Inventario.GUI.Helpers;
using LogicaNegocio.Implementacion.Parametros.Categoria;
using Inventario.GUI.Mapeadores.Parametros.Categoria;

namespace Inventario.GUI.Controllers.Parametros
{
    public class FotoController : Controller
    {
        private ImplFotosLogica acceso = new ImplFotosLogica();

        // GET: Fotos
        public ActionResult Index(int? page, String filtro = " ")
        {
            int numPagina = page ?? 1;
            int totalRegistros;
            int registrosPorPagina = DatosGenerales.RegistrosPorPagina;
            IEnumerable<FotosDTO> listaDatos = acceso.ListarRegistros(filtro, numPagina, registrosPorPagina, out totalRegistros);
            MapeadorFotosGUI mapper = new MapeadorFotosGUI();
            IEnumerable<ModeloFotosGUI> listaGUI = mapper.MapearTipo1Tipo2(listaDatos);
            //var registrosPagina = listaGUI.ToPagedList(numPagina, registrosPorPagina);
            var listaPagina = new StaticPagedList<ModeloFotosGUI>(listaGUI, numPagina, registrosPorPagina, totalRegistros);
            return View(listaPagina);
        }

        // GET: Fotos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FotosDTO FotosDTO = acceso.BuscarRegistro(id.Value);
            if (FotosDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorFotosGUI mapper = new MapeadorFotosGUI();
            ModeloFotosGUI modelo = mapper.MapearTipo1Tipo2(FotosDTO);
            return View(modelo);
        }

        // GET: Fotos/Create
        public ActionResult Create()
        {
            //hay que cambira por producto ****************************************************************
            IEnumerable<ModeloCategoriaGUI> listado = obtenerListadoProductos();
            ModeloFotosGUI modelo = new ModeloFotosGUI();
            modelo.ListaProducto = listado;
            return View(modelo);
        }
        private IEnumerable<ModeloCategoriaGUI> obtenerListadoProducto()
        {
            ImplCategoriaLogica producto = new ImplCategoriaLogica();
            var listaProductos = producto.ListarRegistros();
            MapeadorCategoriaGUI mapeador = new MapeadorCategoriaGUI();
            var listado = mapeador.MapearTipo1Tipo2(listaProductos);
            return listado;
        }

        // POST: Fotos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre")] ModeloFotosGUI modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorFotosGUI mapper = new MapeadorFotosGUI();
                FotosDTO FotosDTO = mapper.MapearTipo2Tipo1(modelo);
                acceso.GuardarRegistro(FotosDTO);
                return RedirectToAction("Index");
            }

            return View(modelo);
        }

        // GET: Fotos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FotosDTO FotosDTO = acceso.BuscarRegistro(id.Value);
            if (FotosDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorFotosGUI mapper = new MapeadorFotosGUI();
            ModeloFotosGUI modelo = mapper.MapearTipo1Tipo2(FotosDTO);
            return View(modelo);
        }

        // POST: Fotos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre")] ModeloFotosGUI modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorFotosGUI mapper = new MapeadorFotosGUI();
                FotosDTO FotosDTO = mapper.MapearTipo2Tipo1(modelo);
                acceso.EditarRegistro(FotosDTO);
                return RedirectToAction("Index");
            }
            return View(modelo);
        }

        // GET: Fotos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FotosDTO FotosDTO = acceso.BuscarRegistro(id.Value);
            if (FotosDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorFotosGUI mapper = new MapeadorFotosGUI();
            ModeloFotosGUI modelo = mapper.MapearTipo1Tipo2(FotosDTO);
            return View(modelo);
        }

        // POST: Fotos/Delete/5
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
                FotosDTO FotosDTO = acceso.BuscarRegistro(id);
                if (FotosDTO == null)
                {
                    return HttpNotFound();
                }
                MapeadorFotosGUI mapper = new MapeadorFotosGUI();
                ViewBag.mensaje = Mensajes.MensajeErrorEliminar;
                ModeloFotosGUI modelo = mapper.MapearTipo1Tipo2(FotosDTO);
                return View(modelo);
            }


        }
        //hay que cambiar por ModeloproductoGUI ***********************************************************
        private IEnumerable<ModeloCategoriaGUI> obtenerListadoProductos()
        {
            ImplCategoriaLogica categoria = new ImplCategoriaLogica();
            var listaProductos = categoria.ListarRegistros();
            MapeadorCategoriaGUI mapeador = new MapeadorCategoriaGUI();
            var listado = mapeador.MapearTipo1Tipo2(listaProductos);
            return listado;
        }

        [HttpGet]
        public ActionResult UploadFile(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModeloCargaImagenProducto modelo = CrearModeloCargarImagenProducto(id);
            return View(modelo);
        }

        private ModeloCargaImagenProducto CrearModeloCargarImagenProducto(int? id)
        {
            IEnumerable<fotosProductoDTO> listaDto = acceso.ListarFotosProductosPorId(id.Value);
            MapeadorFotosProductoGUI mapeador = new MapeadorFotosProductoGUI();
            IEnumerable<ModeloFotosProductoGUI> listaFotos = mapeador.MapearTipo1Tipo2(listaDto);
            if (listaFotos == null)
            {
                listaFotos = new List<ModeloFotosProductoGUI>();
            }
            ModeloCargaImagenProducto modelo = new ModeloCargaImagenProducto()
            {
                Id = id.Value,
                ListadoImagenesProducto = listaFotos
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
                    try {
                        DateTime ahora = DateTime.Now;
                        string fechaNombre = String.Format("{0}_{1}_{2}_{3}_{4}_{5}", ahora.Day, ahora.Month, ahora.Year, ahora.Hour, ahora.Minute, ahora.Millisecond);
                        string nombreArchivo = String.Concat(fechaNombre, "_", Path.GetFileName(modelo.Archivo.FileName));
                        string rutaCarpeta = DatosGenerales.RutaArchivosProducto;
                        string rutaCompletaArchivo = Path.Combine(Server.MapPath(rutaCarpeta), nombreArchivo);
                        modelo.Archivo.SaveAs(rutaCompletaArchivo);
                        fotosProductoDTO dto = new fotosProductoDTO()
                        {
                          
                            IdProducto = modelo.Id,
                            NombreFoto = nombreArchivo
                        };

                        //guardar nombre de archivo base de datos
                        acceso.guardarNombreFoto(dto);
                        ViewBag.UploadFileMessage = "Archivo cargado correctamente";
                        ModeloCargaImagenProducto modeloview = CrearModeloCargarImagenProducto(modelo.Id);
                        return View(modeloview);
                    }
                    catch
                    {

                    }
                        
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

        public ActionResult EliminarFoto(int idFotoProducto, string nombreFotoProducto)
        {
            bool respuesta = acceso.EliminarRegistroFoto(idFotoProducto);
            if (respuesta)
            {
                string rutaCarpeta = DatosGenerales.RutaArchivosProducto;
                string carpetaEliminados = DatosGenerales.CarpetaFotosProductoEliminadas;
                string rutaOrigenCompletaArchivo = Path.Combine(Server.MapPath(rutaCarpeta), nombreFotoProducto);
                string rutaDestinoCompletaArchivo = Path.Combine(Server.MapPath(rutaCarpeta), carpetaEliminados, nombreFotoProducto);
                System.IO.File.Move(rutaOrigenCompletaArchivo, rutaDestinoCompletaArchivo);
            }
            return RedirectToAction("Index");
        }

    }
}
