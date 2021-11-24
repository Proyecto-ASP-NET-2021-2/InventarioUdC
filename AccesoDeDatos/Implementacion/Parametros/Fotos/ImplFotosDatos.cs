using AccesoDeDatos.DbModel.Parametros;
using AccesoDeDatos.Mapeadores.Parametros;
using AccesoDeDatos.ModeloDeDatos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace LogicaNegocio.Implementacion.Parametros
{
    public class ImplFotosDatos
    {
        public IEnumerable<FotosDbModel> ListarRegistros(String filtro, int paginaActual, int numRegistrosPorPagina, out int totalRegistros)
        {
            var lista = new List<FotosDbModel>();
            using (InventarioBDEntities bd = new InventarioBDEntities())
            {
                int regDescartados = (paginaActual - 1) * numRegistrosPorPagina;
                var listaDatos = (from m in bd.tb_foto
                                  where m.ruta.Contains(filtro)
                                  select m).ToList();
                totalRegistros = listaDatos.Count();
                listaDatos = listaDatos.OrderBy(m => m.id).Skip(regDescartados).Take(numRegistrosPorPagina).ToList();
                lista = new MapeadorFotosDatos().MapearTipo1Tipo2(listaDatos).ToList();

            }
            return lista;
        }
        public bool GuardarRegistro(FotosDbModel registro)
        {
            try
            {
                using (InventarioBDEntities bd = new InventarioBDEntities())
                {
                    if (bd.tb_foto.Where(x => x.ruta.ToUpper().Equals(registro.Ruta.ToUpper())).Count() > 0)
                    {
                        return false;
                    }
                    MapeadorFotosDatos mapeador = new MapeadorFotosDatos();
                    var reg = mapeador.MapearTipo2Tipo1(registro);
                    bd.tb_foto.Add(reg);
                    bd.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public FotosDbModel BuscarRegistro(int id)
        {
            using (InventarioBDEntities bd = new InventarioBDEntities())
            {
                tb_foto registro = bd.tb_foto.Find(id);
                return new MapeadorFotosDatos().MapearTipo1Tipo2(registro);
            }
        }
        public bool EditarRegistro(FotosDbModel registro)
        {

            try
            {
                using (InventarioBDEntities bd = new InventarioBDEntities())
                {

                    if (bd.tb_foto.Where(x => x.id == registro.Id).Count() == 0)
                    {
                        return false;
                    }
                    MapeadorFotosDatos mapeador = new MapeadorFotosDatos();
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

                    tb_foto registro = bd.tb_foto.Find(id);
                    if (registro == null || registro.tb_producto.tb_foto.Count()>0)
                    {
                        return false;
                    }
                    bd.tb_foto.Remove(registro);
                    bd.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

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
                    //registro.estado = false;
                    
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

        public bool guardarFotoProducto(fotoProductoDbModel dbModel)
        {
            try
            {
                using (InventarioBDEntities bd = new InventarioBDEntities())
                {
                    if (bd.tb_producto.Where(x => x.id == dbModel.IdProducto).Count() > 0)
                    {
                        MapeadorFotoProductosDatos mapeador = new MapeadorFotoProductosDatos();
                        tb_foto foto = mapeador.MapearTipo2Tipo1(dbModel);
                        bd.tb_foto.Add(foto);
                        bd.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public IEnumerable<fotoProductoDbModel> ListarFotosVehiculoPorId(int id)
        {
            using (InventarioBDEntities bd = new InventarioBDEntities())
            {
                //var lista = bd.tb_fotos.Where(x => x.id_vehiculo == id).ToList();
                var lista = (from f in bd.tb_foto
                             where f.id_producto == id
                             select f).ToList();
                MapeadorFotoProductosDatos mapeador = new MapeadorFotoProductosDatos();
                IEnumerable<fotoProductoDbModel> listaDbModel = mapeador.MapearTipo1Tipo2(lista);
                return listaDbModel;
            }
        }
    }
}
