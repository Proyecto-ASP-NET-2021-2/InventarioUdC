using AccesoDeDatos.DbModel.Parametros;
using AccesoDeDatos.ModeloDeDatos;
using System.Collections.Generic;

namespace AccesoDeDatos.Mapeadores.Parametros
{
    public class MapeadorFotoEspacioDatos : MapeadorBaseDatos<tb_espacio, fotoEspacioDbModel>
    {
        public override fotoEspacioDbModel MapearTipo1Tipo2(tb_espacio entrada)
        {
            return new fotoEspacioDbModel()
            {
                Id = entrada.id,
                IdPiso = entrada.id_piso,
                NombreFoto = entrada.nombre
          
            };
        }

        public override IEnumerable<fotoEspacioDbModel> MapearTipo1Tipo2(IEnumerable<tb_espacio> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override tb_espacio MapearTipo2Tipo1(fotoEspacioDbModel entrada)
        {
            return new tb_espacio()
            {
                id = entrada.Id,
                id_piso = entrada.IdPiso,
                nombre = entrada.NombreFoto
            };
        }

        public override IEnumerable<tb_espacio> MapearTipo2Tipo1(IEnumerable<fotoEspacioDbModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}
