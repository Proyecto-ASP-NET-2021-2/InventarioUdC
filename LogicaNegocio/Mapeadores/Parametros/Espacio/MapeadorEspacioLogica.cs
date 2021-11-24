using AccesoDeDatos.DbModel.Parametros;
using LogicaNegocio.DTO.Parametros;
using System.Collections.Generic;

namespace LogicaNegocio.Mapeadores.Parametros
{
    public class MapeadorEspacioLogica : MapeadorBaseLogica<EspacioDbModel, EspacioDTO>
    {
        public override EspacioDTO MapearTipo1Tipo2(EspacioDbModel entrada)
        {
            return new EspacioDTO()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre,
                NombrePiso = entrada.NombrePiso,
                IdPiso = entrada.IdPiso
            };
        }

        public override IEnumerable<EspacioDTO> MapearTipo1Tipo2(IEnumerable<EspacioDbModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override EspacioDbModel MapearTipo2Tipo1(EspacioDTO entrada)
        {
            return new EspacioDbModel()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre,
                NombrePiso = entrada.NombrePiso,
                IdPiso = entrada.IdPiso
            };
        }

        public override IEnumerable<EspacioDbModel> MapearTipo2Tipo1(IEnumerable<EspacioDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}
