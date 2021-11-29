using AccesoDeDatos.DbModel.Producto;
using AccesoDeDatos.ModeloDeDatos;
using LogicaNegocio.DTO.Producto;
using System.Collections.Generic;

namespace LogicaNegocio.Mapeadores.Producto
{ 
    public class MapeadorProductoLogica : MapeadorBaseLogica<ProductoDbModel, ProductoDTO>
    {
        public override ProductoDTO MapearTipo1Tipo2(ProductoDbModel entrada)
        {
            return new ProductoDTO()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre,
                FechaRegistro = entrada.FechaRegistro,
                Serial=entrada.Serial,
                IdMarca=entrada.IdMarca,
                IdCategoria=entrada.IdCategoria,
                IdFoto=entrada.IdFoto,
                IdTipoProducto=entrada.IdTipoProducto,
                IdEspacio=entrada.IdEspacio,
                IdPersona=entrada.IdPersona
            };
        }

        public override IEnumerable<ProductoDTO> MapearTipo1Tipo2(IEnumerable<ProductoDbModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override ProductoDbModel MapearTipo2Tipo1(ProductoDTO entrada)
        {
            return new ProductoDbModel()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre,
                FechaRegistro = entrada.FechaRegistro,
                Serial = entrada.Serial,
                IdMarca = entrada.IdMarca,
                IdCategoria = entrada.IdCategoria,
                IdFoto = entrada.IdFoto,
                IdTipoProducto = entrada.IdTipoProducto,
                IdEspacio = entrada.IdEspacio,
                IdPersona = entrada.IdPersona
            };
        }

        public override IEnumerable<ProductoDbModel> MapearTipo2Tipo1(IEnumerable<ProductoDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}