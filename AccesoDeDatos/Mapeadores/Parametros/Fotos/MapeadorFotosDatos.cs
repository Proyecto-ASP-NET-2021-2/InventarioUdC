using AccesoDeDatos.DbModel.Parametros;
using AccesoDeDatos.ModeloDeDatos;
using System.Collections.Generic;

namespace AccesoDeDatos.Mapeadores.Parametros
{
    public class MapeadorFotosDatos : MapeadorBaseDatos<tb_foto, FotosDbModel>
    {
        public override FotosDbModel MapearTipo1Tipo2(tb_foto entrada)
        {
            return new FotosDbModel()
            {
                Id = entrada.id,
                Ruta = entrada.ruta,
                IdProducto = entrada.id_producto,
                NombreProducto = entrada.tb_producto.nombre
            };
        }

        public override IEnumerable<FotosDbModel> MapearTipo1Tipo2(IEnumerable<tb_foto> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override tb_foto MapearTipo2Tipo1(FotosDbModel entrada)
        {
            return new tb_foto()
            {
                id = entrada.Id,
                ruta = entrada.Ruta,
                id_producto = entrada.IdProducto
            };
        }

        public override IEnumerable<tb_foto> MapearTipo2Tipo1(IEnumerable<FotosDbModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}
