using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.DTO.Parametros
{
    public class fotoEspacioDTO
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
