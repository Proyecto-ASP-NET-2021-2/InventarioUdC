using AccesoDeDatos.DbModel.Piso;
using AccesoDeDatos.Implementacion.Piso;
using LogicaNegocio.DTO.Piso;
using LogicaNegocio.Mapeadores.Piso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Implementacion.Piso
{
    public class ImplPisoLogica
    {
        private ImplPisoDatos accesoDatos;
        public ImplPisoLogica()
        {
            this.accesoDatos = new ImplPisoDatos();
        }

        /// <summary>
        /// Listar registros
        /// </summary>
        /// <param name="filtro">filtro de búsqueda</param>
        /// <param name="numPagina">página actual</param>
        /// <param name="registrosPorPagina">Cantidad de registros a mostrar por página</param>
        /// <param name="totalRegistros">Total de registros en base de datos</param>
        /// <returns>Listado de registros para mostrar en la página actual que coincida con el filtro</returns>
        public IEnumerable<PisoDTO> ListarRegistros(String filtro, int numPagina, int registrosPorPagina, out int totalRegistros)
        {
            //int totalRegistrosLogica = 0;
            var listado = this.accesoDatos.ListarRegistros(filtro, numPagina, registrosPorPagina, out totalRegistros);
            //totalRegistros = totalRegistrosLogica;
            MapeadorPisoLogica mapeador = new MapeadorPisoLogica();
            return mapeador.MapearTipo1Tipo2(listado);
        }

        public IEnumerable<PisoDTO> ListarRegistros()
        {
            var listado = this.accesoDatos.ListarRegistros();
            MapeadorPisoLogica mapeador = new MapeadorPisoLogica();
            return mapeador.MapearTipo1Tipo2(listado);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PisoDTO BuscarRegistro(int id)
        {
            var registro = this.accesoDatos.BuscarRegistro(id);
            MapeadorPisoLogica mapeador = new MapeadorPisoLogica();
            return mapeador.MapearTipo1Tipo2(registro);
        }

        public Boolean EditarRegistro(PisoDTO registro)
        {
            MapeadorPisoLogica mapeador = new MapeadorPisoLogica();
            PisoDbModel reg = mapeador.MapearTipo2Tipo1(registro);
            Boolean res = this.accesoDatos.EditarRegistro(reg);
            return res;
        }

        public Boolean GuardarRegistro(PisoDTO registro)
        {
            MapeadorPisoLogica mapeador = new MapeadorPisoLogica();
            PisoDbModel reg = mapeador.MapearTipo2Tipo1(registro);
            Boolean res = this.accesoDatos.GuardarRegistro(reg);
            return res;
        }

        public Boolean EliminarRegistro(int id)
        {
            Boolean res = this.accesoDatos.EliminarRegistro(id);
            return res;
        }

        /*
        public Boolean EliminarRegistroFoto(int id)
        {
            Boolean res = this.accesoDatos.EliminarRegistroFoto(id);
            return res;
        }

        public Boolean GuardarNombreFoto(FotoPisoDTO dto)
        {
            MapeadorFotoPisoLogica mapeador = new MapeadorFotoPisoLogica();
            FotoPisoDbModel dbModel = mapeador.MapearTipo2Tipo1(dto);
            bool res = this.accesoDatos.GuardarFotoPiso(dbModel);
            return res;
        }

        public IEnumerable<FotoPisoDTO> ListarFotosPisoPorId(int idPiso)
        {

            IEnumerable<FotoPisoDbModel> listaDbModel = this.accesoDatos.ListarFotosPisoPorId(idPiso);
            MapeadorFotoPisoLogica mapeador = new MapeadorFotoPisoLogica();
            IEnumerable<FotoPisoDTO> lista = mapeador.MapearTipo1Tipo2(listaDbModel);
            return lista;
        }
        */
    }
}
