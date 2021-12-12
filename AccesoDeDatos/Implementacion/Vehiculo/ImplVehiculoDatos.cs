using AccesoDeDatos.DbModel.Parametros;
using AccesoDeDatos.DbModel.Producto;
using AccesoDeDatos.Mapeadores.Producto;
using AccesoDeDatos.Mapeadores.Vehiculo;
using AccesoDeDatos.ModeloDeDatos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDeDatos.Implementacion.Producto
{
    public class ImplProductoDatos
    {
        /// <summary>
        /// Método para listar registros con un filtro
        /// </summary>
        /// <param name="filtro">Filtro a aplicar</param>
        /// <returns>Lista de registros con el filtro aplicado</returns>
        public IEnumerable<ProductoDbModel> ListarRegistros(String filtro, int paginaActual, int numRegistrosPorPagina, out int totalRegistros)
        {
            var lista = new List<ProductoDbModel>();
            using (InventarioBDEntities bd = new InventarioBDEntities())
            {
                int regDescartados = (paginaActual - 1) * numRegistrosPorPagina;
                //lista = bd.tb_producto.Where(x => x.nombre.Contains(filtro)).Skip(regDescartados).Take(numRegistrosPorPagina).ToList();
                var listaDatos = (from m in bd.tb_producto
                                  where m.nombre.Contains(filtro)
                                  select m).ToList();
                totalRegistros = listaDatos.Count();
                listaDatos = listaDatos.OrderBy(m => m.id).Skip(regDescartados).Take(numRegistrosPorPagina).ToList();
                lista = new MapeadorProductoDatos().MapearTipo1Tipo2(listaDatos).ToList();
            }
            return lista;
        }

        public IEnumerable<ProductoDbModel> ListarRegistros()
        {
            var lista = new List<ProductoDbModel>();
            using (InventarioBDEntities bd = new InventarioBDEntities())
            {
                var listaDatos = (from m in bd.tb_producto

                                  select m).ToList();

                lista = new MapeadorProductoDatos().MapearTipo1Tipo2(listaDatos).ToList();

            }
            return lista;
        }

        /// <summary>
        /// Método para almacenar un registro
        /// </summary>
        /// <param name="registro">el registro a almacenar</param>
        /// <returns>true cuando se almacena y false cuando ya existe un registro igual o una excepción</returns>
        public bool GuardarRegistro(ProductoDbModel registro)
        {
            try
            {
                using (InventarioBDEntities bd = new InventarioBDEntities())
                {
                    // verificación de la existencia de un registro con el mismo serial del chasis
                    if (bd.tb_producto.Where(x => x.nombre.ToLower().Equals(registro.Nombre.ToLower())).Count() > 0)
                    {
                        return false;
                    }
                    MapeadorProductoDatos mapeador = new MapeadorProductoDatos();
                    var reg = mapeador.MapearTipo2Tipo1(registro);
                    bd.tb_producto.Add(reg);
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
        public ProductoDbModel BuscarRegistro(int id)
        {
            using (InventarioBDEntities bd = new InventarioBDEntities())
            {
                tb_producto registro = bd.tb_producto.Find(id);
                return new MapeadorProductoDatos().MapearTipo1Tipo2(registro);
            }
        }

        /// <summary>
        /// Método para editar un registro
        /// </summary>
        /// <param name="registro">el registro a editar</param>
        /// <returns>true cuando se edita y false cuando no existe el registro o una excepción</returns>
        public bool EditarRegistro(ProductoDbModel registro)
        {
            try
            {
                using (InventarioBDEntities bd = new InventarioBDEntities())
                {
                    // verificación de la existencia de un registro con el mismo id
                    if (bd.tb_producto.Where(x => x.id == registro.Id).Count() == 0)
                    {
                        return false;
                    }
                    MapeadorProductoDatos mapeador = new MapeadorProductoDatos();
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
                    tb_producto registro = bd.tb_producto.Find(id);
                    if (registro == null) // || registro.tb_ventas.Count() > 0)
                    {
                        return false;
                    }
                    bd.tb_producto.Remove(registro);
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
                    //registro.id = false;
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

        public bool GuardarFotoProducto(fotoProductoDbModel dbModel)
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
            catch(Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<fotoProductoDbModel> ListarFotosProductoPorId(int id)
        {
            using(InventarioBDEntities bd = new InventarioBDEntities())
            {
                //var lista = bd.tb_foto.Where(x => x.id_vehiculo == id).ToList();
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
