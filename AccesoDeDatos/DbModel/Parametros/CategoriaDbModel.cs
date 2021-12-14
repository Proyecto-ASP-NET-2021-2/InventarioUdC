using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDeDatos.DbModel.Parametros
{
    public class CategoriaDbModel
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private String nombre;

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
       
    }
}
