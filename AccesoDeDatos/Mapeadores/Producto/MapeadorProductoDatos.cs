using AccesoDeDatos.DbModel.Parametros;
using AccesoDeDatos.DbModel.Producto;
using AccesoDeDatos.ModeloDeDatos;
using System.Collections.Generic;

namespace AccesoDeDatos.Mapeadores.Producto
{
    public class MapeadorProductoDatos : MapeadorBaseDatos<tb_producto, ProductoDbModel>
    {
        public override ProductoDbModel MapearTipo1Tipo2(tb_producto entrada)
        {
            return new ProductoDbModel()
            {
                Id = entrada.id,
                Nombre = entrada.nombre,
                FechaRegistro = entrada.fechaRegistro,
                Serial = entrada.serial,
                IdMarca = entrada.id_marca,
                NombreMarca = entrada.tb_marca.nombre,
                IdCategoria = entrada.id_categoria,
                NombreCategoria = entrada.tb_categoria.nombre,
                IdTipoProducto = entrada.id_tipoProducto,
                NombreTipoProducto = entrada.tb_tipoProducto.nombre,
                IdEspacio = entrada.id_espacio,
                NombreEspacio = entrada.tb_espacio.nombre,
                IdPersona = entrada.id_persona,
                NombrePersona = entrada.tb_persona.nombres
            };
        }

        public override IEnumerable<ProductoDbModel> MapearTipo1Tipo2(IEnumerable<tb_producto> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override tb_producto MapearTipo2Tipo1(ProductoDbModel entrada)
        {
            return new tb_producto()
            {
                id = entrada.Id,
                nombre = entrada.Nombre,
                fechaRegistro = entrada.FechaRegistro,
                serial = entrada.Serial,
                id_marca = entrada.IdMarca,
                id_categoria = entrada.IdCategoria,
                id_tipoProducto = entrada.IdTipoProducto,
                id_espacio = entrada.IdEspacio,
                id_persona = entrada.IdPersona
            };
        }

        public override IEnumerable<tb_producto> MapearTipo2Tipo1(IEnumerable<ProductoDbModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}