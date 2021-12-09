﻿using AccesoDeDatos.DbModel.Parametros;
using AccesoDeDatos.Implementacion.Parametros;
using LogicaNegocio.DTO.Parametros;
using LogicaNegocio.Mapeadores.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Implementacion.Parametros
{
    public class ImplSedeLogica
    {
        private ImplSedeDatos accesoDatos;
        public ImplSedeLogica()
        {
            this.accesoDatos = new ImplSedeDatos();
        }

        /// <summary>
        /// Listar registros
        /// </summary>
        /// <param name="filtro">filtro de búsqueda</param>
        /// <param name="numPagina">página actual</param>
        /// <param name="registrosPorPagina">Cantidad de registros a mostrar por página</param>
        /// <param name="totalRegistros">Total de registros en base de datos</param>
        /// <returns>Listado de registros para mostrar en la página actual que coincida con el filtro</returns>
        public IEnumerable<SedeDTO> ListarRegistros(String filtro, int numPagina, int registrosPorPagina, out int totalRegistros)
        {
            //int totalRegistrosLogica = 0;
            var listado = this.accesoDatos.ListarRegistros(filtro, numPagina, registrosPorPagina, out totalRegistros);
            //totalRegistros = totalRegistrosLogica;
            MapeadorSedeLogica mapeador = new MapeadorSedeLogica();
            return mapeador.MapearTipo1Tipo2(listado);
        }
        /*
        public IEnumerable<SedeDTO> ListarRegistrosReporte()
        {
            //int totalRegistrosLogica = 0;
            var listado = this.accesoDatos.ListarRegistrosReporte();
            //totalRegistros = totalRegistrosLogica;
            MapeadorSedeLogica mapeador = new MapeadorSedeLogica();
            return mapeador.MapearTipo1Tipo2(listado);
        }
        */
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SedeDTO BuscarRegistro(int id)
        {
            var registro = this.accesoDatos.BuscarRegistro(id);
            if (registro != null)
            {
                MapeadorSedeLogica mapeador = new MapeadorSedeLogica();
                return mapeador.MapearTipo1Tipo2(registro);
            }
            return null;
        }

        public Boolean EditarRegistro(SedeDTO registro)
        {
            MapeadorSedeLogica mapeador = new MapeadorSedeLogica();
            SedeDbModel reg = mapeador.MapearTipo2Tipo1(registro);
            Boolean res = this.accesoDatos.EditarRegistro(reg);
            return res;
        }

        public Boolean GuardarRegistro(SedeDTO registro)
        {
            MapeadorSedeLogica mapeador = new MapeadorSedeLogica();
            SedeDbModel reg = mapeador.MapearTipo2Tipo1(registro);
            Boolean res = this.accesoDatos.GuardarRegistro(reg);
            return res;
        }

        public Boolean EliminarRegistro(int id)
        {
            Boolean res = this.accesoDatos.EliminarRegistro(id);
            return res;
        }
    }
}
