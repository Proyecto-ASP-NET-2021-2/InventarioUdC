using Inventario.GUI.Models.Parametros;
using LogicaNegocio.DTO.Parametros;
using System.Collections.Generic;

namespace Inventario.GUI.Mapeadores.Parametros.Categoria
{
    public class MapeadorFotoCategoriaGUI : MapeadorBaseGUI<fotoCategoriaDTO, ModeloFotoCategoriaGUI>
    {
        public override ModeloFotoCategoriaGUI MapearTipo1Tipo2(fotoCategoriaDTO entrada)
        {
            return new ModeloFotoCategoriaGUI()
            {
                Id = entrada.Id,
                IdProducto = entrada.IdProducto,
                NombreFoto = entrada.NombreFoto
            };
        }

        public override IEnumerable<ModeloFotoCategoriaGUI> MapearTipo1Tipo2(IEnumerable<fotoCategoriaDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override fotoCategoriaDTO MapearTipo2Tipo1(ModeloFotoCategoriaGUI entrada)
        {
            return new fotoCategoriaDTO()
            {
                Id = entrada.Id,
                IdProducto = entrada.IdProducto,
                NombreFoto = entrada.NombreFoto
            };
        }

        public override IEnumerable<fotoCategoriaDTO> MapearTipo2Tipo1(IEnumerable<ModeloFotoCategoriaGUI> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}