using AccesoDeDatos.DbModel.Parametros;
using AccesoDeDatos.ModeloDeDatos;
using LogicaNegocio.Mapeadores.Parametros;
using LogicaNegocio.DTO.Parametros;
using System.Collections.Generic;

namespace LogicaNegocio.Mapeadores.Parametros
{
    public class MapeadorPersonaLogica : MapeadorBaseLogica<PersonaDbModel, PersonaDTO>
    {
        public override PersonaDTO MapearTipo1Tipo2(PersonaDbModel entrada)
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

        public override IEnumerable<PersonaDTO> MapearTipo1Tipo2(IEnumerable<PersonaDbModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override PersonaDbModel MapearTipo2Tipo1(PersonaDTO entrada)
        {
            return new PersonaDbModel()
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

        public override IEnumerable<PersonaDbModel> MapearTipo2Tipo1(IEnumerable<PersonaDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}