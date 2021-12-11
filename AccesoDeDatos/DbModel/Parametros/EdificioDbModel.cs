using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDeDatos.DbModel.Edificio
{
    public class EdificioDbModel
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

       


        private int idSede;

        public int IdSede
        {
            get { return idSede; }
            set { idSede = value; }
        }


        private string nombreSede;

        public string NombreSede
        {
            get { return nombreSede; }
            set { nombreSede = value; }
        }



    }
}
