﻿using LinqToDB.Mapping;
using System.ComponentModel.DataAnnotations.Schema;
using ColumnAttribute = LinqToDB.Mapping.ColumnAttribute;
using TableAttribute = LinqToDB.Mapping.TableAttribute;

namespace ControleDeEstoque.Dominio
{
    [Table(Name = "tb_Tapecaria")]
    public class ProdutoTapecaria
    {
        [PrimaryKey, Identity]
        public int Id { get; set; }

        [Column("Tipo")]
        public TipoTapecaria Tipo { get; set; }

        [Column("DataEntrada")]
        public DateTime DataEntrada { get; set; }

        [Column("Area")]
        public double Area { get; set; }

        [Column("PrecoMetroQuadrado")]
        public decimal PrecoMetroQuadrado { get; set; }

        [Column("EhEntrega")]
        public bool EhEntrega { get; set; }

        [Column("Detalhes")]
        public string Detalhes { get; set; }
    }

    public enum TipoTapecaria
    {
        Tapete,
        Cortina,
        Estofado,
        Outros
    };
}
