using AccesoDeDatos.DbModel.Parametros;
using LogicaNegocio.DTO.Parametros;
using System.Collections.Generic;

namespace LogicaNegocio.Mapeadores.Parametros
{
    public class MapeadorFotoEspacioLogica : MapeadorBaseLogica<fotoEspacioDbModel, fotoEspacioDTO>
    {
        public override fotoEspacioDTO MapearTipo1Tipo2(fotoEspacioDbModel entrada)
        {
            return new fotoEspacioDTO()
            {
                Id = entrada.Id,
                IdPiso = entrada.IdPiso,
                NombreFoto = entrada.NombreFoto
            };
        }

        public override IEnumerable<fotoEspacioDTO> MapearTipo1Tipo2(IEnumerable<fotoEspacioDbModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override fotoEspacioDbModel MapearTipo2Tipo1(fotoEspacioDTO entrada)
        {
            return new fotoEspacioDbModel()
            {
                Id = entrada.Id,
                IdPiso = entrada.IdPiso,
                NombreFoto = entrada.NombreFoto
            };
        }

        public override IEnumerable<fotoEspacioDbModel> MapearTipo2Tipo1(IEnumerable<fotoEspacioDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}
