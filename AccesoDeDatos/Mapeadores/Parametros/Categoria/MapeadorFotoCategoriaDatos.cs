using AccesoDeDatos.DbModel.Parametros;
using AccesoDeDatos.ModeloDeDatos;
using System.Collections.Generic;

namespace AccesoDeDatos.Mapeadores.Parametros
{
    public class MapeadorFotoCategoriaDatos : MapeadorBaseDatos<tb_foto, fotoCategoriaDbModel>
    {
        public override fotoCategoriaDbModel MapearTipo1Tipo2(tb_foto entrada)
        {
            return new fotoCategoriaDbModel()
            {
                Id = entrada.id,
                IdProducto = entrada.id_producto,
                NombreFoto = entrada.ruta
            };
        }

        public override IEnumerable<fotoCategoriaDbModel> MapearTipo1Tipo2(IEnumerable<tb_foto> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override tb_foto MapearTipo2Tipo1(fotoCategoriaDbModel entrada)
        {
            return new tb_foto()
            {
                id = entrada.Id,
                id_producto = entrada.IdProducto,
                ruta = entrada.NombreFoto
            };
        }

        public override IEnumerable<tb_foto> MapearTipo2Tipo1(IEnumerable<fotoCategoriaDbModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}
