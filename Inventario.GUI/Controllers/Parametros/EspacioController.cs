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
using LogicaNegocio.Implementacion.Parametros.Espacio;
using Inventario.GUI.Helpers;

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
            IEnumerable<ModeloEspacioGUI> listado = obtenerListadoPisos();
            ModeloEspacioGUI modelo = new ModeloEspacioGUI();
            modelo.ListaPisos = listado;
            return View(modelo);
        }
        private IEnumerable<ModeloEspacioGUI> obtenerListadoPisos()
        {
            ImplEspacioLogica producto = new ImplEspacioLogica();
            var listaProductos = producto.ListarRegistros();
            MapeadorEspacioGUI mapeador = new MapeadorEspacioGUI();
            var listado = mapeador.MapearTipo1Tipo2(listaProductos);
            return listado;
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
                ViewBag.mensaje = Mensajes.mensajeErrorEliminar;
                ModeloEspacioGUI modelo = mapper.MapearTipo1Tipo2(EspacioDTO);
                return View(modelo);
            }


        }
        //hay que cambiar por ModeloPisoGUI ***********************************************************
        

        [HttpGet]
        public ActionResult UploadFile(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModeloCargaImagenEspacio modelo = CrearModeloCargarImagenEspacio(id);
            return View(modelo);
        }

        private ModeloCargaImagenEspacio CrearModeloCargarImagenEspacio(int? id)
        {
            IEnumerable<fotoEspacioDTO> listaDto = acceso.ListarFotosPisosPorId(id.Value);
            MapeadorFotoEspacioGUI mapeador = new MapeadorFotoEspacioGUI();
            IEnumerable<ModeloFotosEspacioGUI> listaEspacio = mapeador.MapearTipo1Tipo2(listaDto);
            if (listaEspacio == null)
            {
                listaEspacio = new List<ModeloFotosEspacioGUI>();
            }
            ModeloCargaImagenEspacio modelo = new ModeloCargaImagenEspacio()
            {
                Id = id.Value,
                ListadoImagenesEspacio = listaEspacio
            };
            return modelo;
        }

        [HttpPost]
        public ActionResult UploadFile(ModeloCargaImagenEspacio modelo)
        {
            try
            {
                if (modelo.Archivo.ContentLength > 0)
                {
                      DateTime ahora = DateTime.Now;
                        string fechaNombre = String.Format("{0}_{1}_{2}_{3}_{4}_{5}", ahora.Day, ahora.Month, ahora.Year, ahora.Hour, ahora.Minute, ahora.Millisecond);
                        string nombreArchivo = String.Concat(fechaNombre, "_", Path.GetFileName(modelo.Archivo.FileName));
                        string rutaCarpeta = DatosGenerales.RutaArchivosEspacio;
                        string rutaCompletaArchivo = Path.Combine(Server.MapPath(rutaCarpeta), nombreArchivo);
                        modelo.Archivo.SaveAs(rutaCompletaArchivo);
                        fotoEspacioDTO dto = new fotoEspacioDTO()
                        {
                            IdPiso = modelo.Id,
                            NombreFoto = nombreArchivo
                        };

                        //guardar nombre de archivo base de datos
                        acceso.guardarNombreFoto(dto);
                        ViewBag.UploadFileMessage = "Archivo cargado correctamente";
                        ModeloCargaImagenEspacio modeloview = CrearModeloCargarImagenEspacio(modelo.Id);
                        return View(modeloview);
                    

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
