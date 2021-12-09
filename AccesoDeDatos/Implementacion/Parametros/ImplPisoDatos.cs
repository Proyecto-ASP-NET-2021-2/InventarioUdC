using AccesoDeDatos.DbModel.Piso;
using AccesoDeDatos.Mapeadores.Piso;
using AccesoDeDatos.ModeloDeDatos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDeDatos.Implementacion.Piso
{
    public class ImplPisoDatos
    {
        /// <summary>
        /// Método para listar registros con un filtro
        /// </summary>
        /// <param name="filtro">Filtro a aplicar</param>
        /// <returns>Lista de registros con el filtro aplicado</returns>
        public IEnumerable<PisoDbModel> ListarRegistros(String filtro, int paginaActual, int numRegistrosPorPagina, out int totalRegistros)
        {
            var lista = new List<PisoDbModel>();
            using (InventarioBDEntities bd = new InventarioBDEntities())
            {
                int regDescartados = (paginaActual - 1) * numRegistrosPorPagina;
                //lista = bd.tb_piso.Where(x => x.nombre.Contains(filtro)).Skip(regDescartados).Take(numRegistrosPorPagina).ToList();
                var listaDatos = (from m in bd.tb_piso
                                  where m.nombre.Contains(filtro)
                                  select m).ToList();
                totalRegistros = listaDatos.Count();
                listaDatos = listaDatos.OrderBy(m => m.id).Skip(regDescartados).Take(numRegistrosPorPagina).ToList();
                lista = new MapeadorPisoDatos().MapearTipo1Tipo2(listaDatos).ToList();
            }
            return lista;
        }

        /// <summary>
        /// Método para almacenar un registro
        /// </summary>
        /// <param name="registro">el registro a almacenar</param>
        /// <returns>true cuando se almacena y false cuando ya existe un registro igual o una excepción</returns>
        public bool GuardarRegistro(PisoDbModel registro)
        {
            try
            {
                using (InventarioBDEntities bd = new InventarioBDEntities())
                {
                    // verificación de la existencia de un registro con el mismo serial del chasis
                    if (bd.tb_piso.Where(x => x.nombre.ToLower().Equals(registro.Nombre.ToLower())).Count() > 0)
                    {
                        return false;
                    }
                    MapeadorPisoDatos mapeador = new MapeadorPisoDatos();
                    var reg = mapeador.MapearTipo2Tipo1(registro);
                    bd.tb_piso.Add(reg);
                    bd.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Método de búsqueda de un registro
        /// </summary>
        /// <param name="id">id del registro a buscar</param>
        /// <returns>el objeto con el id buscado o null cuando no exista</returns>
        public PisoDbModel BuscarRegistro(int id)
        {
            using (InventarioBDEntities bd = new InventarioBDEntities())
            {
                tb_piso registro = bd.tb_piso.Find(id);
                return new MapeadorPisoDatos().MapearTipo1Tipo2(registro);
            }
        }

        /// <summary>
        /// Método para editar un registro
        /// </summary>
        /// <param name="registro">el registro a editar</param>
        /// <returns>true cuando se edita y false cuando no existe el registro o una excepción</returns>
        public bool EditarRegistro(PisoDbModel registro)
        {
            try
            {
                using (InventarioBDEntities bd = new InventarioBDEntities())
                {
                    // verificación de la existencia de un registro con el mismo id
                    if (bd.tb_piso.Where(x => x.id == registro.Id).Count() == 0)
                    {
                        return false;
                    }
                    MapeadorPisoDatos mapeador = new MapeadorPisoDatos();
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

        /// <summary>
        /// Método de eliminar un registro por el id
        /// </summary>
        /// <param name="id">id del registro a eliminar</param>
        /// <returns>true cuando se elimina, false cuando no existe el registro o una excepción</returns>
        public bool EliminarRegistro(int id)
        {
            try
            {
                using (InventarioBDEntities bd = new InventarioBDEntities())
                {
                    // verificación de la existencia de un registro con el mismo id
                    tb_piso registro = bd.tb_piso.Find(id);
                    if (registro == null) // || registro.tb_ventas.Count() > 0)
                    {
                        return false;
                    }
                    bd.tb_piso.Remove(registro);
                    bd.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /*
        public bool EliminarRegistroFoto(int id)
        {
            try
            {
                using (InventarioBDEntities bd = new InventarioBDEntities())
                {
                    // verificación de la existencia de un registro con el mismo id
                    tb_foto registro = bd.tb_foto.Find(id);
                    if (registro == null)
                    {
                        return false;
                    }
                    registro.estado = false;
                    bd.Entry(registro).State = EntityState.Modified;
                    bd.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool GuardarFotoPiso(FotoPisoDbModel dbModel)
        {
            try
            {
                using (InventarioBDEntities bd = new InventarioBDEntities())
                {
                    if (bd.tb_piso.Where(x => x.id == dbModel.IdPiso).Count() > 0)
                    {
                        MapeadorFotoPisoDatos mapeador = new MapeadorFotoPisoDatos();
                        tb_foto foto = mapeador.MapearTipo2Tipo1(dbModel);
                        bd.tb_foto.Add(foto);
                        bd.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<FotoPisoDbModel> ListarFotosPisoPorId(int id)
        {
            using(InventarioBDEntities bd = new InventarioBDEntities())
            {
                //var lista = bd.tb_foto.Where(x => x.id_vehiculo == id).ToList();
                var lista = (from f in bd.tb_foto
                              where f.id_vehiculo == id && f.estado
                              select f).ToList();
                MapeadorFotoPisoDatos mapeador = new MapeadorFotoPisoDatos();
                IEnumerable<FotoPisoDbModel> listaDbModel = mapeador.MapearTipo1Tipo2(lista);
                return listaDbModel;
            }
        }
        */

    }
}
