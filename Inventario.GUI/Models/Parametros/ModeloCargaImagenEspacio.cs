using Inventario.GUI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventario.GUI.Models.Parametros
{
    public class ModeloCargaImagenEspacio
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

        private IEnumerable<ModeloFotosEspacioGUI> listadoImagenesEspacio;

        public IEnumerable<ModeloFotosEspacioGUI> ListadoImagenesEspacio
        {
            get { return listadoImagenesEspacio; }
            set { listadoImagenesEspacio = value; }
        }

        private String rutaImagenEspacio = DatosGenerales.RutaMostrarArchivosEspacio;

        public String RutaImagenEspacio
        {
            get { return rutaImagenEspacio; }
        }
    }
}