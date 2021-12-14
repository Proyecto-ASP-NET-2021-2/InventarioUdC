using Inventario.GUI.Models.Producto;
using LogicaNegocio.DTO.Producto;
using System.Collections.Generic;

namespace Inventario.GUI.Mapeadores.Producto
{ 
    public class MapeadorProductoGUI : MapeadorBaseGUI<ProductoDTO, ModeloProductoGUI>
    {
        public override ModeloProductoGUI MapearTipo1Tipo2(ProductoDTO entrada)
        {
            return new ModeloProductoGUI()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre,
                FechaRegistro = entrada.FechaRegistro,
                Serial=entrada.Serial,
                NombreMarca=entrada.NombreMarca,
                NombreCategoria = entrada.NombreCategoria,
                IdFoto=entrada.IdFoto,
                NombreTipoProducto = entrada.NombreTipoProducto,
                NombreEspacio = entrada.NombreEspacio,
                NombrePersona = entrada.NombrePersona
            };
        }

        public override IEnumerable<ModeloProductoGUI> MapearTipo1Tipo2(IEnumerable<ProductoDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override ProductoDTO MapearTipo2Tipo1(ModeloProductoGUI entrada)
        {
            return new ProductoDTO()
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
                NombrePersona = entrada.NombrePersona
            };
        }

        public override IEnumerable<ProductoDTO> MapearTipo2Tipo1(IEnumerable<ModeloProductoGUI> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}