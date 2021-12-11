using Inventario.GUI.Models.Parametros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.GUI.Models.Parametros
{
    public class ModeloEdificioGUI
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

        [DisplayName("Sede")]
        public int IdSede
        {
            get { return idSede; }
            set { idSede = value; }
        }

        

        private string nombreSede;

        [DisplayName("Sede")]
        public string NombreSede
        {
            get { return nombreSede; }
            set { nombreSede = value; }
        }

        private IEnumerable<ModeloSedeGUI> modeloSedeGUIs;

        public IEnumerable<ModeloSedeGUI> ListaSedes
        {
            get { return modeloSedeGUIs; }
            set { modeloSedeGUIs = value; }
        }



    }
}
