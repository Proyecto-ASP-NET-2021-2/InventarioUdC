using AccesoDeDatos.DbModel.Parametros;
using AccesoDeDatos.ModeloDeDatos;
using System.Collections.Generic;

namespace AccesoDeDatos.Mapeadores.Parametros
{
    public class MapeadorEspacioDatos : MapeadorBaseDatos<tb_espacio, EspacioDbModel>
    {

        public override EspacioDbModel MapearTipo1Tipo2(tb_espacio entrada)
        {
            return new EspacioDbModel()
            {
                Id = entrada.id,
                Nombre = entrada.nombre,
                NombrePiso = entrada.tb_piso.nombre,
                IdPiso = entrada.id_piso
            };
        }

        public override IEnumerable<EspacioDbModel> MapearTipo1Tipo2(IEnumerable<tb_espacio> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override tb_espacio MapearTipo2Tipo1(EspacioDbModel entrada)
        {
            return new tb_espacio()
            {
                id = entrada.Id,
                nombre = entrada.Nombre,
                id_piso = entrada.IdPiso
                
            };
        }

        public override IEnumerable<tb_espacio> MapearTipo2Tipo1(IEnumerable<EspacioDbModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}
