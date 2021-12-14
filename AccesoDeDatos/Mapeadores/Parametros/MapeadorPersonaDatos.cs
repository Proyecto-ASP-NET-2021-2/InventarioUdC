using AccesoDeDatos.DbModel.Parametros;
using AccesoDeDatos.ModeloDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDeDatos.Mapeadores.Parametros
{
    public class MapeadorPersonaDatos : MapeadorBaseDatos<tb_persona, PersonaDbModel>
    {
        public override PersonaDbModel MapearTipo1Tipo2(tb_persona entrada)
        {
            return new PersonaDbModel()
            {
                Id = entrada.id,
                Nombre = entrada.nombres,
                PrimerApellido = entrada.primer_apellido,
                SegundoApellido = entrada.segundo_apellido,
                Documento = entrada.documento,
                Celular = entrada.celular,
                Correo = entrada.correo
            };
        }

        public override IEnumerable<PersonaDbModel> MapearTipo1Tipo2(IEnumerable<tb_persona> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override tb_persona MapearTipo2Tipo1(PersonaDbModel entrada)
        {
            return new tb_persona()
            {
                id = entrada.Id,
                nombres = entrada.Nombre,
                primer_apellido = entrada.PrimerApellido,
                segundo_apellido = entrada.SegundoApellido,
                documento = entrada.Documento,
                celular = entrada.Celular,
                correo = entrada.Correo
            };
        }

        public override IEnumerable<tb_persona> MapearTipo2Tipo1(IEnumerable<PersonaDbModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}
