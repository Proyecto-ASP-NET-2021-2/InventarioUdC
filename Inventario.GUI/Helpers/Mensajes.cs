using System;
using System.Configuration;

namespace Concesionario.GUI.Helpers
{
    public static class Mensajes
    {
        public static String MensajeErrorEliminar = ConfigurationManager.AppSettings["mensajeErrorAlEliminar"];
        public static String mensajeEdicionCorrecta = ConfigurationManager.AppSettings["MensajeEdicionCorrecta"];
    }
}