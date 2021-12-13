using AccesoDeDatos.DbModel.Parametros;
using AccesoDeDatos.DbModel.Piso;
using AccesoDeDatos.Mapeadores.Parametros;
using AccesoDeDatos.Mapeadores.Piso;
using AccesoDeDatos.ModeloDeDatos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AccesoDeDatos.Implementacion.Parametros
{
    public class ImplEspacioDatos
    {
        public IEnumerable<EspacioDbModel> ListarRegistros(String filtro, int paginaActual, int numRegistrosPorPagina, out int totalRegistros)
        {
            var lista = new List<EspacioDbModel>();
            using (InventarioBDEntities bd = new InventarioBDEntities())
            {
                int regDescartados = (paginaActual - 1) * numRegistrosPorPagina;
                var listaDatos = (from m in bd.tb_espacio

                                  select m).ToList();
                totalRegistros = listaDatos.Count();
                listaDatos = listaDatos.OrderBy(m => m.id).Skip(regDescartados).Take(numRegistrosPorPagina).ToList();
                lista = new MapeadorEspacioDatos().MapearTipo1Tipo2(listaDatos).ToList();

            }
            return lista;
        }

        public IEnumerable<EspacioDbModel> ListarRegistros()
        {
            var lista = new List<EspacioDbModel>();
            using (InventarioBDEntities bd = new InventarioBDEntities())
            {
                var listaDatos = (from m in bd.tb_espacio

                                  select m).ToList();

                lista = new MapeadorEspacioDatos().MapearTipo1Tipo2(listaDatos).ToList();

            }
            return lista;
        }
        public bool GuardarRegistro(EspacioDbModel registro)
        {
            try
            {
                using (InventarioBDEntities bd = new InventarioBDEntities())
                {
                    if (bd.tb_espacio.Where(x => x.id_piso.Equals(registro.Id)).Count() > 0)
                    {
                        return false;
                    }
                    MapeadorEspacioDatos mapeador = new MapeadorEspacioDatos();
                    var reg = mapeador.MapearTipo2Tipo1(registro);
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
                    MapeadorEspacioDatos mapeador = new MapeadorEspacioDatos();
                    var reg = mapeador.MapearTipo2Tipo1(registro);
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
                    if (registro == null)
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
