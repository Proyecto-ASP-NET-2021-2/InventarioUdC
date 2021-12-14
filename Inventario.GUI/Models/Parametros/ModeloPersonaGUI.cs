using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Inventario.GUI.Models.Parametros
{
    public class ModeloPersonaGUI
    {

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string nombre;

        [Required]
        [MinLength(2)]
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private string primerApellido;

        public string PrimerApellido
        {
            get { return primerApellido; }
            set { primerApellido = value; }
        }

        private string segundoApellido;

        public string SegundoApellido
        {
            get { return segundoApellido; }
            set { segundoApellido = value; }
        }

        private string documento;

        public string Documento
        {
            get { return documento; }
            set { documento = value; }
        }

        private string celular;

        public string Celular
        {
            get { return celular; }
            set { celular = value; }
        }

        private string correo;

        public string Correo
        {
            get { return correo; }
            set { correo = value; }
        }


    }
}