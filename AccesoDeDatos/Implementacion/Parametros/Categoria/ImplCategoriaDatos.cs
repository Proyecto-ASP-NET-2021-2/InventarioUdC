using AccesoDeDatos.DbModel.Parametros;
using AccesoDeDatos.DbModel.Producto;
using AccesoDeDatos.Mapeadores.Parametros;
using AccesoDeDatos.Mapeadores.Producto;
using AccesoDeDatos.ModeloDeDatos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AccesoDeDatos.Implementacion.Parametros
{
    public class ImplCategoriaDatos
    {
        public IEnumerable<CategoriaDbModel> ListarRegistros(String filtro,int paginaActual,int numRegistrosPorPagina, out int totalRegistros)
        {
            var lista = new List<CategoriaDbModel>();
                using (InventarioBDEntities bd = new InventarioBDEntities())
                {
                    int regDescartados = (paginaActual - 1) * numRegistrosPorPagina;
                    var listaDatos = (from m in bd.tb_categoria
                         where m.nombre.Contains(filtro)
                         select m).ToList();
                 totalRegistros = listaDatos.Count();
                 listaDatos = listaDatos.OrderBy(m => m.id).Skip(regDescartados).Take(numRegistrosPorPagina).ToList();
                 lista = new MapeadorCategoriaDatos().MapearTipo1Tipo2(listaDatos).ToList();

                }
                return lista;
        }
        public IEnumerable<CategoriaDbModel> ListarRegistros()
        {
            var lista = new List<CategoriaDbModel>();
            using (InventarioBDEntities bd = new InventarioBDEntities())
            {
                var listaDatos = (from m in bd.tb_categoria
                                 
                                  select m).ToList();
              
                lista = new MapeadorCategoriaDatos().MapearTipo1Tipo2(listaDatos).ToList();

            }
            return lista;
        }
        public bool GuardarRegistro(CategoriaDbModel registro)
        {
            try
            {
                using (InventarioBDEntities bd = new InventarioBDEntities())
                {
                    if (bd.tb_categoria.Where(x => x.nombre.ToUpper().Equals(registro.Nombre.ToUpper())).Count() > 0)
                    {
                        return false;
                    }
                    MapeadorCategoriaDatos mapeador = new MapeadorCategoriaDatos();
                    var reg = mapeador.MapearTipo2Tipo1(registro);
                    bd.tb_categoria.Add(reg);
                    bd.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public CategoriaDbModel BuscarRegistro(int id)
        {
            using (InventarioBDEntities bd = new InventarioBDEntities())
            {
                tb_categoria registro = bd.tb_categoria.Find(id);
                return new MapeadorCategoriaDatos().MapearTipo1Tipo2(registro);
            }
        }
        public bool EditarRegistro(CategoriaDbModel registro)
        {

            try
            {
                using (InventarioBDEntities bd = new InventarioBDEntities())
                {

                    if (bd.tb_categoria.Where(x => x.id == registro.Id).Count() == 0)
                    {
                        return false;
                    }
                    MapeadorCategoriaDatos mapeador = new MapeadorCategoriaDatos();
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

                    tb_categoria registro = bd.tb_categoria.Find(id);
                    if (registro == null || registro.tb_producto.Count() > 0)
                    {
                        return false;
                    }
                    bd.tb_categoria.Remove(registro);
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

      
        
    }
}
