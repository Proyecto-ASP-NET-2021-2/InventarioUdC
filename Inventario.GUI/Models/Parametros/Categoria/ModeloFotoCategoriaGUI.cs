﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventario.GUI.Models.Parametros
{
    public class ModeloFotoCategoriaGUI
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int idProducto;

        public int IdProducto
        {
            get { return idProducto; }
            set { idProducto = value; }
        }

        private String nombreFoto;

        public String NombreFoto 
        {
            get { return nombreFoto; }
            set { nombreFoto = value; }
        }


    }
}