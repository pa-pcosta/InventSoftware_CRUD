﻿using System;

namespace Controle_De_Estoque
{
    public class ProdutoTapecaria
    {
        public int Id { get; set; }

        public TipoTapecaria Tipo {  get; set; }

        public DateTime DataEntrada { get; set; }

        public double Area { get; set; }

        public decimal PrecoMetroQuadrado { get; set; }

        public bool EntregarAposServico { get; set; }

        public string Detalhes { get; set; }
    }

    public enum TipoTapecaria
    {
        tapete, cortina, estofado, outros
    };
}
