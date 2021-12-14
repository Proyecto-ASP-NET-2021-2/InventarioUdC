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
                NombreMarca=entrada.NombreMarca,
                NombreCategoria = entrada.NombreCategoria,
                IdFoto = entrada.IdFoto,
                NombreTipoProducto = entrada.NombreTipoProducto,
                NombreEspacio = entrada.NombreEspacio,
                NombrePersona = entrada.NombrePersona,
                IdMarca = entrada.IdMarca,
                IdCategoria = entrada.IdCategoria,
                IdTipoProducto = entrada.IdTipoProducto,
                IdEspacio = entrada.IdEspacio,
                IdPersona = entrada.IdPersona
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
                NombreMarca = entrada.NombreMarca,
                NombreCategoria = entrada.NombreCategoria,
                IdFoto = entrada.IdFoto,
                NombreTipoProducto = entrada.NombreTipoProducto,
                NombreEspacio = entrada.NombreEspacio,
                NombrePersona = entrada.NombrePersona,
                IdMarca = entrada.IdMarca,
                IdCategoria = entrada.IdCategoria,
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