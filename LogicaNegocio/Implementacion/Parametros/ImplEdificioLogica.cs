using AccesoDeDatos.DbModel.Edificio;
using AccesoDeDatos.DbModel.Parametros;
using AccesoDeDatos.Implementacion.Parametros;
using LogicaNegocio.DTO.Edificio;
using LogicaNegocio.Mapeadores.Edificio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Implementacion.Parametros

{
    public class ImplEdificioLogica
    {
        private ImplEdificioDatos accesoDatos;
        public ImplEdificioLogica()
        {
            this.accesoDatos = new ImplEdificioDatos();
        }

        /// <summary>
        /// Listar registros
        /// </summary>
        /// <param name="filtro">filtro de búsqueda</param>
        /// <param name="numPagina">página actual</param>
        /// <param name="registrosPorPagina">Cantidad de registros a mostrar por página</param>
        /// <param name="totalRegistros">Total de registros en base de datos</param>
        /// <returns>Listado de registros para mostrar en la página actual que coincida con el filtro</returns>
        public IEnumerable<EdificioDTO> ListarRegistros(String filtro, int numPagina, int registrosPorPagina, out int totalRegistros)
        {
            //int totalRegistrosLogica = 0;
            var listado = this.accesoDatos.ListarRegistros(filtro, numPagina, registrosPorPagina, out totalRegistros);
            //totalRegistros = totalRegistrosLogica;
            MapeadorEdificioLogica mapeador = new MapeadorEdificioLogica();
            return mapeador.MapearTipo1Tipo2(listado);
        }

        public IEnumerable<EdificioDTO> ListarRegistrosReporte()
        {
            //int totalRegistrosLogica = 0;
            var listado = this.accesoDatos.ListarRegistrosReporte();
            MapeadorEdificioLogica mapeador = new MapeadorEdificioLogica();
            return mapeador.MapearTipo1Tipo2(listado);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public EdificioDTO BuscarRegistro(int id)
        {
            var registro = this.accesoDatos.BuscarRegistro(id);
            MapeadorEdificioLogica mapeador = new MapeadorEdificioLogica();
            return mapeador.MapearTipo1Tipo2(registro);
        }

        public Boolean EditarRegistro(EdificioDTO registro)
        {
            MapeadorEdificioLogica mapeador = new MapeadorEdificioLogica();
            EdificioDbModel reg = mapeador.MapearTipo2Tipo1(registro);
            Boolean res = this.accesoDatos.EditarRegistro(reg);
            return res;
        }

        public Boolean GuardarRegistro(EdificioDTO registro)
        {
            MapeadorEdificioLogica mapeador = new MapeadorEdificioLogica();
            EdificioDbModel reg = mapeador.MapearTipo2Tipo1(registro);
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

        public Boolean GuardarNombreFoto(FotoEdificioDTO dto)
        {
            MapeadorFotoEdificioLogica mapeador = new MapeadorFotoEdificioLogica();
            FotoEdificioDbModel dbModel = mapeador.MapearTipo2Tipo1(dto);
            bool res = this.accesoDatos.GuardarFotoEdificio(dbModel);
            return res;
        }

        public IEnumerable<FotoEdificioDTO> ListarFotosEdificioPorId(int idEdificio)
        {

            IEnumerable<FotoEdificioDbModel> listaDbModel = this.accesoDatos.ListarFotosEdificioPorId(idEdificio);
            MapeadorFotoEdificioLogica mapeador = new MapeadorFotoEdificioLogica();
            IEnumerable<FotoEdificioDTO> lista = mapeador.MapearTipo1Tipo2(listaDbModel);
            return lista;
        }
        */
    }
}
