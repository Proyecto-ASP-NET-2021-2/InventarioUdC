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
    }
}