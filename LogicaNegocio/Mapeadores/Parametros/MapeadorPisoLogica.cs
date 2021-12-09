﻿using AccesoDeDatos.DbModel.Piso;
using AccesoDeDatos.ModeloDeDatos;
using LogicaNegocio.DTO.Piso;
using System.Collections.Generic;

namespace LogicaNegocio.Mapeadores.Piso
{ 
    public class MapeadorPisoLogica : MapeadorBaseLogica<PisoDbModel, PisoDTO>
    {
        public override PisoDTO MapearTipo1Tipo2(PisoDbModel entrada)
        {
            return new PisoDTO()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre,
                IdEdificio = entrada.IdEdificio
            };
        }

        public override IEnumerable<PisoDTO> MapearTipo1Tipo2(IEnumerable<PisoDbModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override PisoDbModel MapearTipo2Tipo1(PisoDTO entrada)
        {
            return new PisoDbModel()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre,
                IdEdificio = entrada.IdEdificio
            };
        }

        public override IEnumerable<PisoDbModel> MapearTipo2Tipo1(IEnumerable<PisoDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}