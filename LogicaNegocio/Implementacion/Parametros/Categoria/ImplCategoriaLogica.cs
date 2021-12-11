using AccesoDeDatos.DbModel.Parametros;
using AccesoDeDatos.Implementacion.Parametros;
using LogicaNegocio.DTO.Parametros;
using LogicaNegocio.DTO.Producto;
using LogicaNegocio.Mapeadores.Parametros;
using LogicaNegocio.Mapeadores.Producto;
using System;
using System.Collections.Generic;

namespace LogicaNegocio.Implementacion.Parametros.Categoria
{
    public class ImplCategoriaLogica
    {
        private ImplCategoriaDatos accesoDatos;
        public ImplCategoriaLogica()
        {
            this.accesoDatos = new ImplCategoriaDatos();
        }
        public IEnumerable<CategoriaDTO> ListarRegistros(String filtro,int numPagina,int registrosPorPagina,out int totalRegistros)
        {
            var listado = this.accesoDatos.ListarRegistros(filtro,numPagina,registrosPorPagina,out totalRegistros);
            MapeadorCategoriaLogica mapeador = new MapeadorCategoriaLogica();
            return mapeador.MapearTipo1Tipo2(listado);
        }
        // esto va en producto
        public IEnumerable<ProductoDTO> ListarRegistros()
        {
            var listado = this.accesoDatos.ListarRegistros();
            MapeadorProductoLogica mapeador = new MapeadorProductoLogica();
            return mapeador.MapearTipo1Tipo2(listado);
        }


        public CategoriaDTO BuscarRegistro(int id)
        {
            var registro = this.accesoDatos.BuscarRegistro(id);
            MapeadorCategoriaLogica mapeador = new MapeadorCategoriaLogica();
            return mapeador.MapearTipo1Tipo2(registro);
        }

        public bool GuardarRegistro(CategoriaDTO registro)
        {
            MapeadorCategoriaLogica mapeador = new MapeadorCategoriaLogica();
            CategoriaDbModel reg = mapeador.MapearTipo2Tipo1(registro);
            bool res = this.accesoDatos.GuardarRegistro(reg);
            return res;
        }

        public bool EditarRegistro(CategoriaDTO registro)
        {
            MapeadorCategoriaLogica mapeador = new MapeadorCategoriaLogica();
            CategoriaDbModel reg = mapeador.MapearTipo2Tipo1(registro);
            bool res = this.accesoDatos.EditarRegistro(reg);
            return res;
        }

        public bool EliminarRegistro(int id)
        {
            bool res = this.accesoDatos.EliminarRegistro(id);
            return res;
        }

       
        public Boolean EliminarRegistroFoto(int id)
        {
            Boolean res = this.accesoDatos.EliminarRegistroFoto(id);
            return res;
        }
    }
}
