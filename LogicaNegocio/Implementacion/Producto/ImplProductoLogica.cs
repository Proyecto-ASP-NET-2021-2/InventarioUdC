using AccesoDeDatos.DbModel.Parametros;
using AccesoDeDatos.DbModel.Producto;
using AccesoDeDatos.Implementacion.Producto;
using LogicaNegocio.DTO.Parametros;
using LogicaNegocio.DTO.Producto;
using LogicaNegocio.Mapeadores.Parametros;
using LogicaNegocio.Mapeadores.Producto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Implementacion.Producto
{
    public class ImplProductoLogica
    {
        private ImplProductoDatos accesoDatos;
        public ImplProductoLogica()
        {
            this.accesoDatos = new ImplProductoDatos();
        }

        /// <summary>
        /// Listar registros
        /// </summary>
        /// <param name="filtro">filtro de búsqueda</param>
        /// <param name="numPagina">página actual</param>
        /// <param name="registrosPorPagina">Cantidad de registros a mostrar por página</param>
        /// <param name="totalRegistros">Total de registros en base de datos</param>
        /// <returns>Listado de registros para mostrar en la página actual que coincida con el filtro</returns>
        public IEnumerable<ProductoDTO> ListarRegistros(String filtro, int numPagina, int registrosPorPagina, out int totalRegistros)
        {
            //int totalRegistrosLogica = 0;
            var listado = this.accesoDatos.ListarRegistros(filtro, numPagina, registrosPorPagina, out totalRegistros);
            //totalRegistros = totalRegistrosLogica;
            MapeadorProductoLogica mapeador = new MapeadorProductoLogica();
            return mapeador.MapearTipo1Tipo2(listado);
        }

       

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ProductoDTO BuscarRegistro(int id)
        {
            var registro = this.accesoDatos.BuscarRegistro(id);
            MapeadorProductoLogica mapeador = new MapeadorProductoLogica();
            return mapeador.MapearTipo1Tipo2(registro);
        }
        public IEnumerable<ProductoDTO> ListarRegistros()
        {
            var listado = this.accesoDatos.ListarRegistros();
            MapeadorProductoLogica mapeador = new MapeadorProductoLogica();
            return mapeador.MapearTipo1Tipo2(listado);
        }
        public Boolean EditarRegistro(ProductoDTO registro)
        {
            MapeadorProductoLogica mapeador = new MapeadorProductoLogica();
            ProductoDbModel reg = mapeador.MapearTipo2Tipo1(registro);
            Boolean res = this.accesoDatos.EditarRegistro(reg);
            return res;
        }

        public Boolean GuardarRegistro(ProductoDTO registro)
        {
            MapeadorProductoLogica mapeador = new MapeadorProductoLogica();
            ProductoDbModel reg = mapeador.MapearTipo2Tipo1(registro);
            Boolean res = this.accesoDatos.GuardarRegistro(reg);
            return res;
        }

        public Boolean EliminarRegistro(int id)
        {
            Boolean res = this.accesoDatos.EliminarRegistro(id);
            return res;
        }

        
        public Boolean EliminarRegistroFoto(int id)
        {
            Boolean res = this.accesoDatos.EliminarRegistroFoto(id);
            return res;
        }

        public Boolean guardarNombreFoto(fotosProductoDTO dto)
        {
            MapeadorFotosProductoLogica mapeador = new MapeadorFotosProductoLogica();
            fotoProductoDbModel dbModel = mapeador.MapearTipo2Tipo1(dto);
            bool res = this.accesoDatos.GuardarFotoProducto(dbModel);
            return res;
        }

        public IEnumerable<fotosProductoDTO> ListarFotosProductoPorId(int idProducto)
        {

            IEnumerable<fotoProductoDbModel> listaDbModel = this.accesoDatos.ListarFotosProductoPorId(idProducto);
            MapeadorFotosProductoLogica mapeador = new MapeadorFotosProductoLogica();
            IEnumerable<fotosProductoDTO> lista = mapeador.MapearTipo1Tipo2(listaDbModel);
            return lista;
        }
       

    }
}
