using Inventario.GUI.Models.Parametros;
using LogicaNegocio.DTO.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventario.GUI.Mapeadores.Parametros
{
    public class MapeadorFotosGUI : MapeadorBaseGUI<FotosDTO, ModeloFotosGUI>
    {
        public override ModeloFotosGUI MapearTipo1Tipo2(FotosDTO entrada)
        {
            return new ModeloFotosGUI()
            {
                Id = entrada.Id,
                Ruta = entrada.Ruta,
                NombreProducto = entrada.NombreProducto,
                IdProducto = entrada.IdProducto
            };
        }

        public override IEnumerable<ModeloFotosGUI> MapearTipo1Tipo2(IEnumerable<FotosDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override FotosDTO MapearTipo2Tipo1(ModeloFotosGUI entrada)
        {
            return new FotosDTO()
            {
                Id = entrada.Id,
                Ruta = entrada.Ruta,
                NombreProducto = entrada.NombreProducto,
                IdProducto = entrada.IdProducto
            };
        }

        public override IEnumerable<FotosDTO> MapearTipo2Tipo1(IEnumerable<ModeloFotosGUI> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}