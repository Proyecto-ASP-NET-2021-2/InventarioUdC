using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Inventario.GUI.Helpers
{
    public static class DatosGenerales
    {

        public static int RegistrosPorPagina = Int32.Parse(ConfigurationManager.AppSettings["registrosPorPagina"].ToString());
        public static String RutaArchivosProducto = ConfigurationManager.AppSettings["rutaArchivosProducto"].ToString();
        public static String RutaArchivosEspacio = ConfigurationManager.AppSettings["rutaArchivosEspacio"].ToString();
        public static String CarpetaFotosProductoEliminadas = ConfigurationManager.AppSettings["carpetaFotosProductoEliminadas"].ToString();
        public static String RutaMostrarArchivosProducto = ConfigurationManager.AppSettings["rutaMostrarArchivosProducto"].ToString();
        public static String RutaMostrarArchivosEspacio = ConfigurationManager.AppSettings["rutaMostrarArchivosEspacio"].ToString();
    }
}