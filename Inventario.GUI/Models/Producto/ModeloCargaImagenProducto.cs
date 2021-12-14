using Inventario.GUI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventario.GUI.Models.Producto
{
    public class ModeloCargaImagenProducto
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private HttpPostedFileBase archivo;

        public HttpPostedFileBase Archivo
        {
            get { return archivo; }
            set { archivo = value; }
        }

        private IEnumerable<ModeloFotoProductoGUI> listadoImagenesProducto;

        public IEnumerable<ModeloFotoProductoGUI> ListadoImagenesProducto
        {
            get { return listadoImagenesProducto; }
            set { listadoImagenesProducto = value; }
        }

        private String rutaImagenProducto = DatosGenerales.RutaMostrarArchivosProducto;

        public String RutaImagenProducto
        {
            get { return rutaImagenProducto; }
        }
    }
}