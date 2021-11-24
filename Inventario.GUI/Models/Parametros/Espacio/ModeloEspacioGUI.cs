using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Inventario.GUI.Models.Parametros
{
    public class ModeloEspacioGUI
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

        private int idPiso;
        
        public int IdPiso
        {
            get { return idPiso; }
            set { idPiso = value; }
        }


        private string nombrePiso;
        
        public string NombrePiso
        {
            get { return nombrePiso; }
            set { nombrePiso = value; }
        }
    }
}