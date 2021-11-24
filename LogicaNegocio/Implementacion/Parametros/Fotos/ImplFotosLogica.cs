using AccesoDeDatos.DbModel.Parametros;
using LogicaNegocio.DTO.Parametros;
using LogicaNegocio.Mapeadores.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Implementacion.Parametros
{
    public class ImplFotosLogica
    {
        private ImplFotosDatos accesoDatos;
        public ImplFotosLogica()
        {
            this.accesoDatos = new ImplFotosDatos();
        }
        public IEnumerable<FotosDTO> ListarRegistros(String filtro, int numPagina, int registrosPorPagina, out int totalRegistros)
        {
            var listado = this.accesoDatos.ListarRegistros(filtro, numPagina, registrosPorPagina, out totalRegistros);
            MapeadorFotosLogica mapeador = new MapeadorFotosLogica();
            return mapeador.MapearTipo1Tipo2(listado);
        }

        public FotosDTO BuscarRegistro(int id)
        {
            var registro = this.accesoDatos.BuscarRegistro(id);
            MapeadorFotosLogica mapeador = new MapeadorFotosLogica();
            return mapeador.MapearTipo1Tipo2(registro);
        }

        public bool GuardarRegistro(FotosDTO registro)
        {
            MapeadorFotosLogica mapeador = new MapeadorFotosLogica();
            FotosDbModel reg = mapeador.MapearTipo2Tipo1(registro);
            bool res = this.accesoDatos.GuardarRegistro(reg);
            return res;
        }

        public bool EditarRegistro(FotosDTO registro)
        {
            MapeadorFotosLogica mapeador = new MapeadorFotosLogica();
            FotosDbModel reg = mapeador.MapearTipo2Tipo1(registro);
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

        public Boolean guardarNombreFoto(fotosProductoDTO dto)
        {
            MapeadorFotosProductoLogica mapeador = new MapeadorFotosProductoLogica();
            fotoProductoDbModel dbModel = mapeador.MapearTipo2Tipo1(dto);
            bool res = this.accesoDatos.guardarFotoProducto(dbModel);
            return res;
        }
        public IEnumerable<fotosProductoDTO> ListarFotosVehiculoPorId(int idVehiculo)
        {

            IEnumerable<fotoProductoDbModel> listaDbModel = this.accesoDatos.ListarFotosVehiculoPorId(idVehiculo);
            MapeadorFotosProductoLogica mapeador = new MapeadorFotosProductoLogica();
            IEnumerable<fotosProductoDTO> lista = mapeador.MapearTipo1Tipo2(listaDbModel);
            return lista;
        }
    }
}
