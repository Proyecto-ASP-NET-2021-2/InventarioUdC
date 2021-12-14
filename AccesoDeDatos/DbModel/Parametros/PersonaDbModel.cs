using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDeDatos.DbModel.Parametros
{ 
    public class PersonaDbModel
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string nombre;

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