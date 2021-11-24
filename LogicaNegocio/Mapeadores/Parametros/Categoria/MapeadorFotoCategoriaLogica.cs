using AccesoDeDatos.DbModel.Parametros;
using LogicaNegocio.DTO.Parametros;
using System.Collections.Generic;

namespace LogicaNegocio.Mapeadores.Parametros
{
    public class MapeadorFotoCategoriaLogica : MapeadorBaseLogica<fotoCategoriaDbModel, fotoCategoriaDTO>
    {
        public override fotoCategoriaDTO MapearTipo1Tipo2(fotoCategoriaDbModel entrada)
        {
            return new fotoCategoriaDTO()
            {
                Id = entrada.Id,
                IdProducto = entrada.IdProducto,
                NombreFoto = entrada.NombreFoto
            };
        }

        public override IEnumerable<fotoCategoriaDTO> MapearTipo1Tipo2(IEnumerable<fotoCategoriaDbModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override fotoCategoriaDbModel MapearTipo2Tipo1(fotoCategoriaDTO entrada)
        {
            return new fotoCategoriaDbModel()
            {
                Id = entrada.Id,
                IdProducto = entrada.IdProducto,
                NombreFoto = entrada.NombreFoto
            };
        }

        public override IEnumerable<fotoCategoriaDbModel> MapearTipo2Tipo1(IEnumerable<fotoCategoriaDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}
