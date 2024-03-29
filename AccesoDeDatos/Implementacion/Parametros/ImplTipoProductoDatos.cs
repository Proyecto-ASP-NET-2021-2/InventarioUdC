﻿using AccesoDeDatos.DbModel.Parametros;
using AccesoDeDatos.Mapeadores.Parametros;
using AccesoDeDatos.ModeloDeDatos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDeDatos.Implementacion.Parametros
{
    public class ImplTipoProductoDatos
    {
        /// <summary>
        /// Método para listar registros con un filtro
        /// </summary>
        /// <param name="filtro">Filtro a aplicar</param>
        /// <returns>Lista de registros con el filtro aplicado</returns>
        public IEnumerable<TipoProductoDbModel> ListarRegistros(String filtro, int paginaActual, int numRegistrosPorPagina, out int totalRegistros)
        {
            var lista = new List<TipoProductoDbModel>();
            using (InventarioBDEntities bd = new InventarioBDEntities())
            {
                int regDescartados = (paginaActual - 1) * numRegistrosPorPagina;
                //lista = bd.tb_tipoProducto.Where(x => x.nombre.Contains(filtro)).Skip(regDescartados).Take(numRegistrosPorPagina).ToList();
                var listaDatos = (from m in bd.tb_tipoProducto
                                  where m.nombre.Contains(filtro)
                                  select m).ToList();
                totalRegistros = listaDatos.Count();
                listaDatos = listaDatos.OrderBy(m => m.id).Skip(regDescartados).Take(numRegistrosPorPagina).ToList();
                lista = new MapeadorTipoProductoDatos().MapearTipo1Tipo2(listaDatos).ToList();
            }
            return lista;
        }

        /// <summary>
        /// Método para almacenar un registro
        /// </summary>
        /// <param name="registro">el registro a almacenar</param>
        /// <returns>true cuando se almacena y false cuando ya existe un registro igual o una excepción</returns>
        public bool GuardarRegistro(TipoProductoDbModel registro)
        {
            try
            {
                using (InventarioBDEntities bd = new InventarioBDEntities())
                {
                    // verificación de la existencia de un registro con el mismo nombre
                    if (bd.tb_tipoProducto.Where(x => x.nombre.ToLower().Equals(registro.Nombre.ToLower())).Count() > 0)
                    {
                        return false;
                    }
                    MapeadorTipoProductoDatos mapeador = new MapeadorTipoProductoDatos();
                    var reg = mapeador.MapearTipo2Tipo1(registro);
                    bd.tb_tipoProducto.Add(reg);
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
        public TipoProductoDbModel BuscarRegistro(int id)
        {
            using (InventarioBDEntities bd = new InventarioBDEntities())
            {
                tb_tipoProducto registro = bd.tb_tipoProducto.Find(id);
                return new MapeadorTipoProductoDatos().MapearTipo1Tipo2(registro);
            }
        }

        /// <summary>
        /// Método para editar un registro
        /// </summary>
        /// <param name="registro">el registro a editar</param>
        /// <returns>true cuando se edita y false cuando no existe el registro o una excepción</returns>
        public bool EditarRegistro(TipoProductoDbModel registro)
        {
            try
            {
                using (InventarioBDEntities bd = new InventarioBDEntities())
                {
                    // verificación de la existencia de un registro con el mismo id
                    if (bd.tb_tipoProducto.Where(x => x.id == registro.Id).Count() == 0)
                    {
                        return false;
                    }
                    MapeadorTipoProductoDatos mapeador = new MapeadorTipoProductoDatos();
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
                    tb_tipoProducto registro = bd.tb_tipoProducto.Find(id);
                    if (registro == null || registro.tb_producto.Count() > 0)
                    {
                        return false;
                    }
                    bd.tb_tipoProducto.Remove(registro);
                    bd.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<TipoProductoDbModel> ListarRegistros()
        {
            var lista = new List<TipoProductoDbModel>();

            using (InventarioBDEntities bd = new InventarioBDEntities())
            {

                //lista = bd.tb_marca.Where(x => x.nombre.Contains(filtro)).Skip(regDescartados).Take(numRegistrosPorPagina).ToList();
                var listaDatos = (from m in bd.tb_tipoProducto

                                  select m).ToList();


                lista = new MapeadorTipoProductoDatos().MapearTipo1Tipo2(listaDatos).ToList();
            }
            return lista;

        }

    }
}
