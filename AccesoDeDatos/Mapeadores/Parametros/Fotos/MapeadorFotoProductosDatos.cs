using AccesoDeDatos.DbModel.Parametros;
using AccesoDeDatos.ModeloDeDatos;
using System.Collections.Generic;

namespace AccesoDeDatos.Mapeadores.Parametros
{
    public class MapeadorFotoProductosDatos : MapeadorBaseDatos<tb_foto, fotoProductoDbModel>
    {
        public override fotoProductoDbModel MapearTipo1Tipo2(tb_foto entrada)
        {
            return new fotoProductoDbModel()
            {
                Id = entrada.id,
                IdProducto = entrada.id_producto,
                
                NombreFoto = entrada.ruta
            };
        }

        public override IEnumerable<fotoProductoDbModel> MapearTipo1Tipo2(IEnumerable<tb_foto> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override tb_foto MapearTipo2Tipo1(fotoProductoDbModel entrada)
        {
            return new tb_foto()
            {
                id = entrada.Id,
                ruta = entrada.NombreFoto,
                id_producto = entrada.IdProducto
            };
        }

        public override IEnumerable<tb_foto> MapearTipo2Tipo1(IEnumerable<fotoProductoDbModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}
