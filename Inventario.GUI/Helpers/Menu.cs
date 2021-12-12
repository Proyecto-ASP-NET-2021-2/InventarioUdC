using Inventario.GUI.Mapeadores.Seguridad;
using Inventario.GUI.Models.Seguridad;
using LogicaNegocio.DTO.Seguridad;
using LogicaNegocio.Implementacion.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventario.GUI.Helpers
{
    public static class Menu
    {
        private static UserImplController controller = new UserImplController();
        public static IEnumerable<FormModel> GetMenuForms(int userId) 
        {
            IEnumerable<FormDTO> dtoList = controller.GetRoleFormsByUser(userId);
            FormModelMapper mapper = new FormModelMapper();
            IEnumerable<FormModel> list = mapper.MapearTipo1Tipo2(dtoList);
            return list;
        }


        public static bool ValidateUserInForm(int userId, int formId)
        {
            return controller.ValidateUserInForm(userId, formId);
        }
    }
}