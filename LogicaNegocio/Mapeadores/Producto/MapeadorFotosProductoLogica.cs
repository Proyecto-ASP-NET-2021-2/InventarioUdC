using AccesoDeDatos.DbModel.Parametros;
using LogicaNegocio.DTO.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Mapeadores.Parametros
{
    public class MapeadorFotosProductoLogica : MapeadorBaseLogica<fotoProductoDbModel, fotosProductoDTO>
    {
        public override fotosProductoDTO MapearTipo1Tipo2(fotoProductoDbModel entrada)
        {
            return new fotosProductoDTO()
            {
                Id = entrada.Id,
                NombreFoto = entrada.NombreFoto,
                IdProducto = entrada.IdProducto
            };
        }

        public override IEnumerable<fotosProductoDTO> MapearTipo1Tipo2(IEnumerable<fotoProductoDbModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override fotoProductoDbModel MapearTipo2Tipo1(fotosProductoDTO entrada)
        {
            return new fotoProductoDbModel()
            {
                Id = entrada.Id,
                NombreFoto = entrada.NombreFoto,
                IdProducto = entrada.IdProducto
            };
        }

        public override IEnumerable<fotoProductoDbModel> MapearTipo2Tipo1(IEnumerable<fotosProductoDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}
