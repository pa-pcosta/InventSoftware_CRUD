using LinqToDB.Mapping;
using System.ComponentModel.DataAnnotations.Schema;
using TableAttribute = LinqToDB.Mapping.TableAttribute;

namespace ControleDeEstoque.Dominio
{
    [Table(Name = "tb_Tapecaria")]
    public class ProdutoTapecaria
    {
        [PrimaryKey, Identity]
        public int Id { get; set; }

        public TipoTapecaria Tipo { get; set; }

        public DateTime DataEntrada { get; set; }

        public double Area { get; set; }

        public decimal PrecoMetroQuadrado { get; set; }

        public bool EhEntrega { get; set; }

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
