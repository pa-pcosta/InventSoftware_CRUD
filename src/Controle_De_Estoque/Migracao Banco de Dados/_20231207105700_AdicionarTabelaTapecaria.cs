using FluentMigrator;
using FluentMigrator.SqlServer;

namespace Controle_De_Estoque.Migracao_Banco_de_Dados
{
    [Migration(20231207105700)]

    public class _20231207105700_AdicionarTabelaTapecaria : Migration
    {
        public override void Up()
        {
            Create.Table("tb_Tapecaria")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity(1,1)
                .WithColumn("Tipo").AsInt32()
                .WithColumn("DataEntrada").AsDate()
                .WithColumn("Area").AsDouble()
                .WithColumn("PrecoMetroQuadrado").AsDecimal()
                .WithColumn("EhEntrega").AsBoolean()
                .WithColumn("Detalhes").AsString();
        }    

        public override void Down()
        {
            Delete.Table("Tapecaria");
        }
    }
}
