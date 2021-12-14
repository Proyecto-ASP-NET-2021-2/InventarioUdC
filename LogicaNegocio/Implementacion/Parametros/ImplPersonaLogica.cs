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
    public class ImplPersonaLogica
    {
        private ImplPersonaDatos accesoDatos;
        public ImplPersonaLogica()
        {
            this.accesoDatos = new ImplPersonaDatos();
        }

        /// <summary>
        /// Listar registros
        /// </summary>
        /// <param name="filtro">filtro de búsqueda</param>
        /// <param name="numPagina">página actual</param>
        /// <param name="registrosPorPagina">Cantidad de registros a mostrar por página</param>
        /// <param name="totalRegistros">Total de registros en base de datos</param>
        /// <returns>Listado de registros para mostrar en la página actual que coincida con el filtro</returns>
        public IEnumerable<PersonaDTO> ListarRegistros(String filtro, int numPagina, int registrosPorPagina, out int totalRegistros)
        {
            //int totalRegistrosLogica = 0;
            var listado = this.accesoDatos.ListarRegistros(filtro, numPagina, registrosPorPagina, out totalRegistros);
            //totalRegistros = totalRegistrosLogica;
            MapeadorPersonaLogica mapeador = new MapeadorPersonaLogica();
            return mapeador.MapearTipo1Tipo2(listado);
        }
        /*
        public IEnumerable<PersonaDTO> ListarRegistrosReporte()
        {
            //int totalRegistrosLogica = 0;
            var listado = this.accesoDatos.ListarRegistrosReporte();
            //totalRegistros = totalRegistrosLogica;
            MapeadorPersonaLogica mapeador = new MapeadorPersonaLogica();
            return mapeador.MapearTipo1Tipo2(listado);
        }
        */




        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PersonaDTO BuscarRegistro(int id)
        {
            var registro = this.accesoDatos.BuscarRegistro(id);
            if (registro != null)
            {
                MapeadorPersonaLogica mapeador = new MapeadorPersonaLogica();
                return mapeador.MapearTipo1Tipo2(registro);
            }
            return null;
        }

        public Boolean EditarRegistro(PersonaDTO registro)
        {
            MapeadorPersonaLogica mapeador = new MapeadorPersonaLogica();
            PersonaDbModel reg = mapeador.MapearTipo2Tipo1(registro);
            Boolean res = this.accesoDatos.EditarRegistro(reg);
            return res;
        }

        public Boolean GuardarRegistro(PersonaDTO registro)
        {
            MapeadorPersonaLogica mapeador = new MapeadorPersonaLogica();
            PersonaDbModel reg = mapeador.MapearTipo2Tipo1(registro);
            Boolean res = this.accesoDatos.GuardarRegistro(reg);
            return res;
        }

        public Boolean EliminarRegistro(int id)
        {
            Boolean res = this.accesoDatos.EliminarRegistro(id);
            return res;
        }

        public IEnumerable<PersonaDTO> ListarRegistros()
        {
            var listado = this.accesoDatos.ListarRegistros();

            MapeadorPersonaLogica mapeador = new MapeadorPersonaLogica();
            return mapeador.MapearTipo1Tipo2(listado);
        }
    }
}
