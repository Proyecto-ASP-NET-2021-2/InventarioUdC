using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LogicaNegocio.DTO.Producto
{
    public class ProductoDTO
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

        private DateTime fechaRegistro;

        public DateTime FechaRegistro
        {
            get { return fechaRegistro; }
            set { fechaRegistro = value; }
        }

        private string serial;

        public string Serial
        {
            get { return serial; }
            set { serial = value; }
        }

        private int idMarca;

        public int IdMarca
        {
            get { return idMarca; }
            set { idMarca = value; }
        }

        private int idCategoria;

        public int IdCategoria
        {
            get { return idCategoria; }
            set { idCategoria = value; }
        }

        private int idFoto;

        public int IdFoto
        {
            get { return idFoto; }
            set { idFoto = value; }
        }

        private int idTipoProducto;

        public int IdTipoProducto
        {
            get { return idTipoProducto; }
            set { idTipoProducto = value; }
        }

        private int idEspacio;

        public int IdEspacio
        {
            get { return idEspacio; }
            set { idEspacio = value; }
        }

        private int idPersona;

        public int IdPersona
        {
            get { return idPersona; }
            set { idPersona = value; }
        }



    }
}
