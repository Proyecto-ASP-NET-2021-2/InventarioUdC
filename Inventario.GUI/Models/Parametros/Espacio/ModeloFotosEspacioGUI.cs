using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Inventario.GUI.Models.Parametros
{
    public class ModeloFotosEspacioGUI
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int idPiso;

        public int IdPiso
        {
            get { return idPiso; }
            set { idPiso = value; }
        }

        
        private String nombreFoto;

        public String NombreFoto
        {
            get { return nombreFoto; }
            set { nombreFoto = value; }
        }
    }
}