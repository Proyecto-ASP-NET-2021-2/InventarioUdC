using Inventario.GUI.Models.Parametros;
using LogicaNegocio.DTO.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventario.GUI.Mapeadores.Producto
{
    public class MapeadorFotosProductoGUI : MapeadorBaseGUI<fotosProductoDTO, ModeloFotoProductoGUI>
    {
        public override ModeloFotoProductoGUI MapearTipo1Tipo2(fotosProductoDTO entrada)
        {
            return new ModeloFotoProductoGUI()
            {
                Id = entrada.Id,
                NombreFoto = entrada.NombreFoto,
                IdProducto = entrada.IdProducto
            };
        }

        public override IEnumerable<ModeloFotoProductoGUI> MapearTipo1Tipo2(IEnumerable<fotosProductoDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override fotosProductoDTO MapearTipo2Tipo1(ModeloFotoProductoGUI entrada)
        {
            return new fotosProductoDTO()
            {
                Id = entrada.Id,
                NombreFoto = entrada.NombreFoto,
                IdProducto = entrada.IdProducto
            };
        }

        public override IEnumerable<fotosProductoDTO> MapearTipo2Tipo1(IEnumerable<ModeloFotoProductoGUI> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}