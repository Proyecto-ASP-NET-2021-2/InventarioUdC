using Inventario.GUI.Helpers;
using Inventario.GUI.Mapeadores.Parametros;
using Inventario.GUI.Mapeadores.Parametros.Categoria;
using Inventario.GUI.Mapeadores.Parametros.Espacio;
using Inventario.GUI.Mapeadores.Producto;
using Inventario.GUI.Models.Parametros;
using Inventario.GUI.Models.Producto;
using LogicaNegocio.DTO.Parametros;
using LogicaNegocio.DTO.Producto;
using LogicaNegocio.Implementacion.Parametros;
using LogicaNegocio.Implementacion.Producto;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Inventario.GUI.Controllers.Producto
{
    public class ProductoController : Controller
    {
        private ImplProductoLogica logica = new ImplProductoLogica();

        // GET: Producto
        public ActionResult Index(int? page, String filtro = "")
        {
            int numPagina = page ?? 1;
            int totalRegistros;
            int registrosPorPagina = DatosGenerales.RegistrosPorPagina;
            IEnumerable<ProductoDTO> listaDatos = logica.ListarRegistros(filtro, numPagina, registrosPorPagina, out totalRegistros);
            MapeadorProductoGUI mapper = new MapeadorProductoGUI();
            IEnumerable<ModeloProductoGUI> listaGUI = mapper.MapearTipo1Tipo2(listaDatos);
            //var registrosPagina = listaGUI.ToPagedList(numPagina, registrosPorPagina);
            var listaPagina = new StaticPagedList<ModeloProductoGUI>(listaGUI, numPagina, registrosPorPagina, totalRegistros);
            return View(listaPagina);
        }

        // GET: Producto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductoDTO ProductoDTO = logica.BuscarRegistro(id.Value);
            if (ProductoDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorProductoGUI mapper = new MapeadorProductoGUI();
            ModeloProductoGUI modelo = mapper.MapearTipo1Tipo2(ProductoDTO);
            return View(modelo);
        }

        // GET: Vehiculo/Create
        public ActionResult Create()
        {
            IEnumerable<ModeloMarcaGUI> listadoMarcas = obtenerListadoMarcas();
            IEnumerable<ModeloTipoProductoGUI> listadoTipoProductos = obtenerListadoTipoProductos();
            IEnumerable<ModeloCategoriaGUI> listadoCategorias = obtenerListadoCategorias();
            IEnumerable<ModeloEspacioGUI> listadoEspacios = obtenerListadoEspacios();
            IEnumerable<ModeloPersonaGUI> listadoPersonas = obtenerListadoPersonas();

            ModeloProductoGUI modelo = new ModeloProductoGUI();
            modelo.ListaMarca = listadoMarcas;
            modelo.ListaTipoProducto = listadoTipoProductos;
            modelo.ListaCategoria = listadoCategorias;
            modelo.ListaEspacio = listadoEspacios;
            modelo.ListaPersona = listadoPersonas;

            return View(modelo);

        }

        private IEnumerable<ModeloCategoriaGUI> obtenerListadoCategorias()
        {
            ImplCategoriaLogica categoria = new ImplCategoriaLogica();
            var listaCategorias = categoria.ListarRegistros();
            MapeadorCategoriaGUI mapeador = new MapeadorCategoriaGUI();
            var listado = mapeador.MapearTipo1Tipo2(listaCategorias);
            return listado;
        }

        private IEnumerable<ModeloEspacioGUI> obtenerListadoEspacios()
        {
            ImplEspacioLogica espacio = new ImplEspacioLogica();
            var listaEspacios = espacio.ListarRegistros();
            MapeadorEspacioGUI mapeador = new MapeadorEspacioGUI();
            var listado = mapeador.MapearTipo1Tipo2(listaEspacios);
            return listado;
        }

        private IEnumerable<ModeloMarcaGUI> obtenerListadoMarcas()
        {
            ImplMarcaLogica marca = new ImplMarcaLogica();
            var listaMarcas = marca.ListarRegistros();
            MapeadorMarcaGUI mapeador = new MapeadorMarcaGUI();

            var listado = mapeador.MapearTipo1Tipo2(listaMarcas);
            return listado;
        }

        private IEnumerable<ModeloTipoProductoGUI> obtenerListadoTipoProductos()
        {
            ImplTipoProductoLogica categoria = new ImplTipoProductoLogica();
            var listaTipoProductos = categoria.ListarRegistros();
            MapeadorTipoProductoGUI mapeador = new MapeadorTipoProductoGUI();

            var listado = mapeador.MapearTipo1Tipo2(listaTipoProductos);
            return listado;
        }

        private IEnumerable<ModeloPersonaGUI> obtenerListadoPersonas()
        {
            ImplPersonaLogica persona = new ImplPersonaLogica();
            var listaPersonas = persona.ListarRegistros();
            MapeadorPersonaGUI mapeador = new MapeadorPersonaGUI();

            var listado = mapeador.MapearTipo1Tipo2(listaPersonas);
            return listado;
        }


        // POST: Producto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ModeloProductoGUI modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorProductoGUI mapper = new MapeadorProductoGUI();
                ProductoDTO ProductoDTO = mapper.MapearTipo2Tipo1(modelo);
                logica.GuardarRegistro(ProductoDTO);
                return RedirectToAction("Index");
            }

            return View(modelo);
        }

        // GET: Producto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductoDTO ProductoDTO = logica.BuscarRegistro(id.Value);
            if (ProductoDTO == null)
            {
                return HttpNotFound();
            }

            IEnumerable<ModeloMarcaGUI> listadoMarcas = obtenerListadoMarcas();
            IEnumerable<ModeloTipoProductoGUI> listadoTipoProductos = obtenerListadoTipoProductos();
            IEnumerable<ModeloCategoriaGUI> listadoCategorias = obtenerListadoCategorias();
            IEnumerable<ModeloEspacioGUI> listadoEspacios = obtenerListadoEspacios();
            IEnumerable<ModeloPersonaGUI> listadoPersonas = obtenerListadoPersonas();

            


            MapeadorProductoGUI mapper = new MapeadorProductoGUI();
            ModeloProductoGUI modelo = mapper.MapearTipo1Tipo2(ProductoDTO);
            modelo.ListaMarca = listadoMarcas;
            modelo.ListaTipoProducto = listadoTipoProductos;
            modelo.ListaCategoria = listadoCategorias;
            modelo.ListaEspacio = listadoEspacios;
            modelo.ListaPersona = listadoPersonas;
            return View(modelo);
        }

        // POST: Producto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ModeloProductoGUI modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorProductoGUI mapper = new MapeadorProductoGUI();
                ProductoDTO ProductoDTO = mapper.MapearTipo2Tipo1(modelo);
                logica.EditarRegistro(ProductoDTO);
                return RedirectToAction("Index");
            }
            return View(modelo);
        }

        // GET: Producto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductoDTO ProductoDTO = logica.BuscarRegistro(id.Value);
            if (ProductoDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorProductoGUI mapper = new MapeadorProductoGUI();
            ModeloProductoGUI modelo = mapper.MapearTipo1Tipo2(ProductoDTO);
            return View(modelo);
        }

        // POST: Producto/Delete/5
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
                ProductoDTO ProductoDTO = logica.BuscarRegistro(id);
                if (ProductoDTO == null)
                {
                    return HttpNotFound();
                }
                MapeadorProductoGUI mapper = new MapeadorProductoGUI();
                ViewBag.mensaje = Mensajes.mensajeErrorEliminar;
                ModeloProductoGUI modelo = mapper.MapearTipo1Tipo2(ProductoDTO);
                return View(modelo);
            }
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
            IEnumerable<fotosProductoDTO> listaDto = logica.ListarFotosProductoPorId(id.Value);
            MapeadorFotosProductoGUI mapeador = new MapeadorFotosProductoGUI();
            IEnumerable<ModeloFotoProductoGUI> listaProducto = mapeador.MapearTipo1Tipo2(listaDto);
            if (listaProducto == null)
            {
                listaProducto = new List<ModeloFotoProductoGUI>();
            }
            ModeloCargaImagenProducto modelo = new ModeloCargaImagenProducto()
            {
                Id = id.Value,
                ListadoImagenesProducto = listaProducto
            };
            return modelo;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadFile(ModeloCargaImagenProducto modelo)
        {
            try
            {
                if (modelo.Archivo.ContentLength > 0)
                {
                    try
                    {
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
                        logica.guardarNombreFoto(dto);
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
            bool respuesta = logica.EliminarRegistroFoto(idFotoProducto);
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

        public FileStreamResult Print()
        {
            DateTime hoy = DateTime.Now;
            string fecha_creacion = String.Format("{0}_{1}_{2}_{3}", hoy.Day, hoy.Hour, hoy.Minute, hoy.Millisecond);
            string nombre_archivo = String.Concat("Productos_", fecha_creacion, ".pdf");
            string ruta = Server.MapPath("~/pdfReports/Productos/" + nombre_archivo);
            MapeadorProductoGUI mapeador = new MapeadorProductoGUI();
            IEnumerable<ModeloProductoGUI> listaDatos = mapeador.MapearTipo1Tipo2(logica.ListarRegistros());
            FabricaArchivosPDF fabrica = new FabricaArchivosPDF();
            bool archivoCreado = fabrica.CrearListadoDeProductosEnPDF(ruta, "Listado de Productos", listaDatos);

            if (archivoCreado)
            {
                var fileStream = new FileStream(ruta,
                                    FileMode.Open,
                                    FileAccess.Read
                                  );
                var fsResult = new FileStreamResult(fileStream, "application/pdf");
                return fsResult;
            }
            else
            {
                throw new Exception("Error leyendo el archivo");
            }
        }
    }
}
