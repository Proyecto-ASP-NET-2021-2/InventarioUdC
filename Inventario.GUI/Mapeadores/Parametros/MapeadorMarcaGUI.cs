﻿using Inventario.GUI.Models.Parametros;
using LogicaNegocio.DTO.Parametros;
using System.Collections.Generic;

namespace Inventario.GUI.Mapeadores.Parametros
{
    public class MapeadorMarcaGUI : MapeadorBaseGUI<MarcaDTO, ModeloMarcaGUI>
    {
        public override ModeloMarcaGUI MapearTipo1Tipo2(MarcaDTO entrada)
        {
            return new ModeloMarcaGUI()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre
            };
        }

        public override IEnumerable<ModeloMarcaGUI> MapearTipo1Tipo2(IEnumerable<MarcaDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override MarcaDTO MapearTipo2Tipo1(ModeloMarcaGUI entrada)
        {
            return new MarcaDTO()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre
            };
        }

        public override IEnumerable<MarcaDTO> MapearTipo2Tipo1(IEnumerable<ModeloMarcaGUI> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}