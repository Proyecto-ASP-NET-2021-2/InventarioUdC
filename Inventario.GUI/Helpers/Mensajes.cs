using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Inventario.GUI.Helpers
{
    public static class Mensajes
    {
        public static String mensajeErrorEliminar = ConfigurationManager.AppSettings["MensajeErrorAlEliminar"];
        public static String mensajeEdicionCorrecta = ConfigurationManager.AppSettings["MensajeEdicionCorrecta"];
    }
}