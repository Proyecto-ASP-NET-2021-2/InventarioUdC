﻿using Inventario.GUI.Models.Parametros;
using LogicaNegocio.DTO.Parametros;
using System.Collections.Generic;

namespace Inventario.GUI.Mapeadores.Parametros
{ 
    public class MapeadorPisoGUI : MapeadorBaseGUI<PisoDTO, ModeloPisoGUI>
    {
        public override ModeloPisoGUI MapearTipo1Tipo2(PisoDTO entrada)
        {
            return new ModeloPisoGUI()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre,
                IdEdificio = entrada.IdEdificio,
                NombreEdificio = entrada.NombreEdificio
            };
        }

        public override IEnumerable<ModeloPisoGUI> MapearTipo1Tipo2(IEnumerable<PisoDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override PisoDTO MapearTipo2Tipo1(ModeloPisoGUI entrada)
        {
            return new PisoDTO()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre,
                IdEdificio = entrada.IdEdificio,
                NombreEdificio = entrada.NombreEdificio
            };
        }

        public override IEnumerable<PisoDTO> MapearTipo2Tipo1(IEnumerable<ModeloPisoGUI> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}