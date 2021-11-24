using AccesoDeDatos.DbModel.Parametros;
using AccesoDeDatos.Mapeadores.Parametros;
using AccesoDeDatos.ModeloDeDatos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace LogicaNegocio.Implementacion.Parametros
{
    public class ImplEspacioDatos
    {
        public IEnumerable<EspacioDbModel> ListarRegistros(String filtro)
        {
            var lista = new List<tb_espacio>();
            using (InventarioBDEntities bd = new InventarioBDEntities())
            {
                //lista = bd.tb_espacio.Where(x => x.nombre.ToUpper().Contains(filtro.ToUpper())).ToList();
                lista = (from c in bd.tb_espacio
                         where c.nombre.Contains(filtro)
                         select c).ToList();

            }
            return new MapeadorEspacioDatos().MapearTipo1Tipo2(lista);
        }
        public bool GuardarRegistro(EspacioDbModel registro)
        {
            try
            {
                using (InventarioBDEntities bd = new InventarioBDEntities())
                {
                    if (bd.tb_espacio.Where(x => x.nombre.ToUpper().Equals(registro.Nombre.ToUpper())).Count() > 0)
                    {
                        return false;
                    }
                    var reg = new MapeadorEspacioDatos().MapearTipo2Tipo1(registro);
                    bd.tb_espacio.Add(reg);
                    bd.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public EspacioDbModel BuscarRegistro(int id)
        {
            using (InventarioBDEntities bd = new InventarioBDEntities())
            {
                tb_espacio registro = bd.tb_espacio.Find(id);
                return new MapeadorEspacioDatos().MapearTipo1Tipo2(registro);
            }
        }
        public bool EditarRegistro(EspacioDbModel registro)
        {

            try
            {
                using (InventarioBDEntities bd = new InventarioBDEntities())
                {

                    if (bd.tb_espacio.Where(x => x.id == registro.Id).Count() == 0)
                    {
                        return false;
                    }
                    tb_espacio reg = new MapeadorEspacioDatos().MapearTipo2Tipo1(registro);
                    bd.Entry(reg).State = EntityState.Modified;
                    bd.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public bool EliminarRegistro(int id)
        {
            try
            {
                using (InventarioBDEntities bd = new InventarioBDEntities())
                {

                    tb_espacio registro = bd.tb_espacio.Find(id);
                    if (registro == null )
                    {
                        return false;
                    }
                    bd.tb_espacio.Remove(registro);
                    bd.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
