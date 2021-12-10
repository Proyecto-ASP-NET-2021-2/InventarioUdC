using System;
using System.Configuration;

namespace Inventario.GUI.Helpers
{
    public static class DatosGenerales
    {
        public static int RegistrosPorPagina = Int32.Parse(ConfigurationManager.AppSettings["registrosPorPagina"].ToString());
        public static String RutaArchivosProducto = ConfigurationManager.AppSettings["rutaArchivosProducto"].ToString();
        public static String RutaArchivosPisos = ConfigurationManager.AppSettings["rutaArchivosPisos"].ToString();
        public static String CarpetaFotosProductoEliminadas = ConfigurationManager.AppSettings["carpetaFotosProductoEliminadas"].ToString();
        public static String RutaMostrarArchivosProducto = ConfigurationManager.AppSettings["rutaMostrarArchivosProducto"].ToString();
        public static String RutaMostrarArchivosEspacio = ConfigurationManager.AppSettings["rutaMostrarArchivosEspacio"].ToString();
    }
}