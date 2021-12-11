using Inventario.GUI.Models.Parametros;
using LogicaNegocio.DTO.Parametros;
using System.Collections.Generic;

namespace Inventario.GUI.Mapeadores.Parametros
{ 
    public class MapeadorEdificioGUI : MapeadorBaseGUI<EdificioDTO, ModeloEdificioGUI>
    {
        public override ModeloEdificioGUI MapearTipo1Tipo2(EdificioDTO entrada)
        {
            return new ModeloEdificioGUI()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre,
                IdSede = entrada.IdSede,
                NombreSede = entrada.NombreSede
            };
        }

        public override IEnumerable<ModeloEdificioGUI> MapearTipo1Tipo2(IEnumerable<EdificioDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override EdificioDTO MapearTipo2Tipo1(ModeloEdificioGUI entrada)
        {
            return new EdificioDTO()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre,
                IdSede = entrada.IdSede
            };
        }

        public override IEnumerable<EdificioDTO> MapearTipo2Tipo1(IEnumerable<ModeloEdificioGUI> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}