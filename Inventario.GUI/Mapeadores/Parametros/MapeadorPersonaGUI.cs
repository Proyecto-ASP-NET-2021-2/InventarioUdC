using Inventario.GUI.Models.Parametros;
using LogicaNegocio.DTO.Parametros;
using System.Collections.Generic;

namespace Inventario.GUI.Mapeadores.Parametros
{
    public class MapeadorPersonaGUI : MapeadorBaseGUI<PersonaDTO, ModeloPersonaGUI>
    {
        public override ModeloPersonaGUI MapearTipo1Tipo2(PersonaDTO entrada)
        {
            return new ModeloPersonaGUI()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre,
                PrimerApellido = entrada.PrimerApellido,
                SegundoApellido = entrada.SegundoApellido,
                Documento = entrada.Documento,
                Celular = entrada.Celular,
                Correo = entrada.Correo
            };
        }

        public override IEnumerable<ModeloPersonaGUI> MapearTipo1Tipo2(IEnumerable<PersonaDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override PersonaDTO MapearTipo2Tipo1(ModeloPersonaGUI entrada)
        {
            return new PersonaDTO()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre,
                PrimerApellido = entrada.PrimerApellido,
                SegundoApellido = entrada.SegundoApellido,
                Documento = entrada.Documento,
                Celular = entrada.Celular,
                Correo = entrada.Correo
            };
        }

        public override IEnumerable<PersonaDTO> MapearTipo2Tipo1(IEnumerable<ModeloPersonaGUI> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}