using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Inventario.GUI.Models.Parametros
{
    public class ModeloFotosGUI
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
        //aqui hay que reemplazar ModeloCategoriaGUI por ModeloProductoGUI
        private IEnumerable<ModeloCategoriaGUI> listaProducto;

        public IEnumerable<ModeloCategoriaGUI> ListaProducto
        {
            get { return listaProducto; }
            set { listaProducto = value; }
        }

    }
}