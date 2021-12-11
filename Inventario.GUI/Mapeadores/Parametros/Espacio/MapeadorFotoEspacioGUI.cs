using Inventario.GUI.Models.Parametros;
using LogicaNegocio.DTO.Parametros;
using System.Collections.Generic;

namespace Inventario.GUI.Mapeadores.Parametros.Espacio
{
    public class MapeadorFotoEspacioGUI : MapeadorBaseGUI<fotoEspacioDTO, ModeloFotosEspacioGUI>
    {
        public override ModeloFotosEspacioGUI MapearTipo1Tipo2(fotoEspacioDTO entrada)
        {
            return new ModeloFotosEspacioGUI()
            {
                Id = entrada.Id,
                IdPiso = entrada.IdPiso,
                NombreFoto = entrada.NombreFoto
            };
        }

        public override IEnumerable<ModeloFotosEspacioGUI> MapearTipo1Tipo2(IEnumerable<fotoEspacioDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override fotoEspacioDTO MapearTipo2Tipo1(ModeloFotosEspacioGUI entrada)
        {
            return new fotoEspacioDTO()
            {
                Id = entrada.Id,
                IdPiso = entrada.IdPiso,
                NombreFoto = entrada.NombreFoto
            };
        }

        public override IEnumerable<fotoEspacioDTO> MapearTipo2Tipo1(IEnumerable<ModeloFotosEspacioGUI> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}