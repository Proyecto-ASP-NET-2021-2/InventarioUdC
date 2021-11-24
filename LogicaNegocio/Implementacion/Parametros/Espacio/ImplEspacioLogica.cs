using AccesoDeDatos.DbModel.Parametros;
using LogicaNegocio.DTO.Parametros;
using LogicaNegocio.Mapeadores.Parametros;
using System;
using System.Collections.Generic;

namespace LogicaNegocio.Implementacion.Parametros.Espacio
{
    public class ImplEspacioLogica
    {
        private ImplEspacioDatos accesoDatos;
        public ImplEspacioLogica()
        {
            this.accesoDatos = new ImplEspacioDatos();
        }
        public IEnumerable<EspacioDTO> ListarRegistros(String filtro)
        {
            var listado = this.accesoDatos.ListarRegistros(filtro);
            MapeadorEspacioLogica mapeador = new MapeadorEspacioLogica();
            return mapeador.MapearTipo1Tipo2(listado);
        }

        public EspacioDTO BuscarRegistro(int id)
        {
            var registro = this.accesoDatos.BuscarRegistro(id);
            MapeadorEspacioLogica mapeador = new MapeadorEspacioLogica();
            return mapeador.MapearTipo1Tipo2(registro);
        }

        public bool GuardarRegistro(EspacioDTO registro)
        {
            MapeadorEspacioLogica mapeador = new MapeadorEspacioLogica();
            EspacioDbModel reg = mapeador.MapearTipo2Tipo1(registro);
            bool res = this.accesoDatos.GuardarRegistro(reg);
            return res;
        }

        public bool EditarRegistro(EspacioDTO registro)
        {
            MapeadorEspacioLogica mapeador = new MapeadorEspacioLogica();
            EspacioDbModel reg = mapeador.MapearTipo2Tipo1(registro);
            bool res = this.accesoDatos.EditarRegistro(reg);
            return res;
        }

        public bool EliminarRegistro(int id)
        {
            bool res = this.accesoDatos.EliminarRegistro(id);
            return res;
        }
    }
}
