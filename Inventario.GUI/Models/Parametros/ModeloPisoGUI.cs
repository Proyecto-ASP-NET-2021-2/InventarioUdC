using Inventario.GUI.Models.Parametros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.GUI.Models.Piso
{
    public class ModeloPisoGUI
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

        

        private int idEdificio;
        [DisplayName("Edificio")]
        public int IdEdificio
        {
            get { return idEdificio; }
            set { idEdificio = value; }
        }

        
        private string nombreEdificio;

        [DisplayName("Edificio")]
        public string NombreEdificio
        {
            get { return nombreEdificio; }
            set { nombreEdificio = value; }
        }

        private IEnumerable<ModeloEdificioGUI> modeloEdificioGUIs;

        public IEnumerable<ModeloEdificioGUI> ListadoEdificios
        {
            get { return modeloEdificioGUIs; }
            set { modeloEdificioGUIs = value; }
        }

        private IEnumerable<ModeloPisoGUI> listaPisos;

        public IEnumerable<ModeloPisoGUI> ListadoPisos
        {
            get { return listaPisos; }
            set { listaPisos = value; }
        }



    }
}
