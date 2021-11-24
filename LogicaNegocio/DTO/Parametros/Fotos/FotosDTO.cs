using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.DTO.Parametros
{
    public class FotosDTO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string ruta;

        public string Ruta
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
