using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDeDatos.DbModel.Parametros
{
    public class FotosDbModel
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private String ruta;

        public String Ruta
        {
            get { return ruta; }
            set { ruta = value; }
        }
        private int idProducto;
        public int IdProducto
        {
            get { return idProducto; }
            set { idProducto = value; }
        }
        private String nombreProducto;
        public String NombreProducto
        {
            get { return nombreProducto; }
            set { nombreProducto = value; }
        }
    }
}
