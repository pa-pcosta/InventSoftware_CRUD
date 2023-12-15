using ControleDeEstoque.Dominio;
using Microsoft.Data.SqlClient;
using System.Configuration;

namespace ControleDeEstoque.Repositorio
{
    internal class RepositorioBancoDeDados : IRepository
    {
        private static readonly string _connectionString = ConfigurationManager.ConnectionStrings["SQL_Server_Controle_De_Estoque"].ConnectionString;
        private SqlConnection _conexaoSql = new SqlConnection(_connectionString);

        public List<ProdutoTapecaria> ObterTodos()
        {
            List<ProdutoTapecaria> listaTapecaria = new List<ProdutoTapecaria>();

            var query = "SELECT * " +
                        "FROM tb_Tapecaria " +
                        "ORDER BY Id";

            SqlCommand comandoSql = new SqlCommand(query, _conexaoSql);

            _conexaoSql.Open();

            SqlDataReader reader = comandoSql.ExecuteReader();

            listaTapecaria = GeraLista(reader);

            _conexaoSql.Close();

            return listaTapecaria;
        }

        public ProdutoTapecaria ObterPorId(int id)
        {
            var query = $@"SELECT * 
                        FROM tb_Tapecaria 
                        WHERE Id = {id}";

            SqlCommand comandoSql = new SqlCommand(query, _conexaoSql);

            _conexaoSql.Open();

            SqlDataReader reader = comandoSql.ExecuteReader();

            ProdutoTapecaria produtoTapecaria = new();

            if (reader.Read())
                produtoTapecaria = ConverterDataReaderParaLista(reader);

            _conexaoSql.Close();

            return produtoTapecaria;
        }

        public void Criar(ProdutoTapecaria produtoTapecaria)
        {
            var ehEntrega = produtoTapecaria.EhEntrega == true ? 1 : 0;

            var query = $@"INSERT INTO tb_Tapecaria (Tipo, DataEntrada, Area, PrecoMetroQuadrado, EhEntrega, Detalhes) 
                        VALUES (@Tipo, 
                                @DataEntrada, 
                                @Area, 
                                @PrecoMetroQuadrado, 
                                @EhEntrega, 
                                @Detalhes)";

            SqlCommand comandoSql = new SqlCommand(query, _conexaoSql);

            comandoSql.Parameters.AddWithValue("@Tipo", produtoTapecaria.Tipo);
            comandoSql.Parameters.AddWithValue("@DataEntrada", produtoTapecaria.DataEntrada);
            comandoSql.Parameters.AddWithValue("@Area", produtoTapecaria.Area);
            comandoSql.Parameters.AddWithValue("@PrecoMetroQuadrado", produtoTapecaria.PrecoMetroQuadrado);
            comandoSql.Parameters.AddWithValue("@EhEntrega", produtoTapecaria.EhEntrega == true ? 1 : 0);
            comandoSql.Parameters.AddWithValue("@Detalhes", produtoTapecaria.Detalhes);

            _conexaoSql.Open();
            comandoSql.ExecuteNonQuery();
            _conexaoSql.Close();
        }

        public void Atualizar(int idProdutoASerEditado, ProdutoTapecaria novoProdutoTapecaria)
        {
            var query = @"UPDATE tb_Tapecaria
                        SET Tipo = @Tipo, 
                            DataEntrada = @DataEntrada, 
                            Area = @Area, 
                            PrecoMetroQuadrado = @PrecoMetroQuadrado, 
                            EhEntrega = @EhEntrega, 
                            Detalhes = @Detalhes
                        WHERE Id = @Id";

            SqlCommand comandoSql = new(query, _conexaoSql);

            comandoSql.Parameters.AddWithValue("@Tipo", novoProdutoTapecaria.Tipo);
            comandoSql.Parameters.AddWithValue("@DataEntrada", novoProdutoTapecaria.DataEntrada);
            comandoSql.Parameters.AddWithValue("@Area", novoProdutoTapecaria.Area);
            comandoSql.Parameters.AddWithValue("@PrecoMetroQuadrado", novoProdutoTapecaria.PrecoMetroQuadrado);
            comandoSql.Parameters.AddWithValue("@EhEntrega", novoProdutoTapecaria.EhEntrega);
            comandoSql.Parameters.AddWithValue("@Detalhes", novoProdutoTapecaria.Detalhes);
            comandoSql.Parameters.AddWithValue("@Id", idProdutoASerEditado);

            _conexaoSql.Open();
            comandoSql.ExecuteNonQuery();
            _conexaoSql.Close();
        }

        public void Remover(int id)
        {
            var query = @"DELETE FROM tb_Tapecaria
                          WHERE Id = @Id";

            SqlCommand comandoSql = new(query, _conexaoSql);

            comandoSql.Parameters.AddWithValue("@Id", id);

            _conexaoSql.Open();
            comandoSql.ExecuteNonQuery();
            _conexaoSql.Close();
        }

        private ProdutoTapecaria ConverterDataReaderParaLista(SqlDataReader reader)
        {
            ProdutoTapecaria produtoTapecaria = new ProdutoTapecaria();

            produtoTapecaria.Id = (int)reader["Id"];
            produtoTapecaria.Tipo = (TipoTapecaria)reader["Tipo"];
            produtoTapecaria.DataEntrada = (DateTime)reader["DataEntrada"];
            produtoTapecaria.Area = Convert.ToDouble(reader["Area"]);
            produtoTapecaria.PrecoMetroQuadrado = Convert.ToDecimal(reader["PrecoMetroQuadrado"]);
            produtoTapecaria.EhEntrega = (bool)reader["EhEntrega"];
            produtoTapecaria.Detalhes = reader["Detalhes"].ToString();

            return produtoTapecaria;
        }

        private List<ProdutoTapecaria> GeraLista(SqlDataReader reader)
        {
            ProdutoTapecaria produtoTapecaria = new ProdutoTapecaria();
            List<ProdutoTapecaria> listaTapecaria = new List<ProdutoTapecaria>();

            while (reader.Read())
            {
                produtoTapecaria = ConverterDataReaderParaLista(reader);
                listaTapecaria.Add(produtoTapecaria);
            }

            return listaTapecaria;
        }
    }
}
