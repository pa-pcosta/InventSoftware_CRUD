using ControleDeEstoque.Dominio;
using Microsoft.Data.SqlClient;
using System.Configuration;

namespace ControleDeEstoque.Repositorios
{
    internal class RepositorioBancoDeDados : IRepository
    {
        private static readonly string _connectionString = ConfigurationManager.ConnectionStrings["SQL_Server_Controle_De_Estoque"].ConnectionString;

        public List<ProdutoTapecaria> ObterTodos()
        {
            SqlConnection conexaoSql = new(_connectionString);
            List<ProdutoTapecaria> listaTapecaria = new();

            var query = "SELECT * " +
                        "FROM tb_Tapecaria " +
                        "ORDER BY Id";

            SqlCommand comandoSql = new(query, conexaoSql);

            conexaoSql.Open();

            SqlDataReader reader = comandoSql.ExecuteReader();

            listaTapecaria = ConverterDataReaderParaLista(reader);

            conexaoSql.Close();

            return listaTapecaria;
        }

        public ProdutoTapecaria ObterPorId(int id)
        {
            SqlConnection conexaoSql = new(_connectionString);
            var query = $@"SELECT * 
                        FROM tb_Tapecaria 
                        WHERE Id = {id}";

            SqlCommand comandoSql = new(query, conexaoSql);

            conexaoSql.Open();

            SqlDataReader reader = comandoSql.ExecuteReader();

            ProdutoTapecaria produtoTapecaria = new();

            if (reader.Read())
                produtoTapecaria = GerarProdutoTapecaria(reader);

            conexaoSql.Close();

            return produtoTapecaria;
        }

        public void Criar(ProdutoTapecaria produtoTapecaria)
        {
            SqlConnection conexaoSql = new(_connectionString);

            var query = $@"INSERT INTO tb_Tapecaria (Tipo, DataEntrada, Area, PrecoMetroQuadrado, EhEntrega, Detalhes) 
                        VALUES (@Tipo, 
                                @DataEntrada, 
                                @Area, 
                                @PrecoMetroQuadrado, 
                                @EhEntrega, 
                                @Detalhes)";

            SqlCommand comandoSql = new(query, conexaoSql);

            comandoSql.Parameters.AddWithValue("@Tipo", produtoTapecaria.Tipo);
            comandoSql.Parameters.AddWithValue("@DataEntrada", produtoTapecaria.DataEntrada);
            comandoSql.Parameters.AddWithValue("@Area", produtoTapecaria.Area);
            comandoSql.Parameters.AddWithValue("@PrecoMetroQuadrado", produtoTapecaria.PrecoMetroQuadrado);
            comandoSql.Parameters.AddWithValue("@EhEntrega", produtoTapecaria.EhEntrega);
            comandoSql.Parameters.AddWithValue("@Detalhes", produtoTapecaria.Detalhes);

            conexaoSql.Open();
            comandoSql.ExecuteNonQuery();
            conexaoSql.Close();
        }

        public void Atualizar(int idProdutoASerEditado, ProdutoTapecaria novoProdutoTapecaria)
        {
            SqlConnection _conexaoSql = new(_connectionString);
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
            SqlConnection _conexaoSql = new SqlConnection(_connectionString);
            var query = @"DELETE FROM tb_Tapecaria
                          WHERE Id = @Id";

            SqlCommand comandoSql = new(query, _conexaoSql);

            comandoSql.Parameters.AddWithValue("@Id", id);

            _conexaoSql.Open();
            comandoSql.ExecuteNonQuery();
            _conexaoSql.Close();
        }

        private static ProdutoTapecaria GerarProdutoTapecaria(SqlDataReader reader)
        {
            ProdutoTapecaria produtoTapecaria = new()
            {
                Id = Convert.ToInt32(reader["Id"]),
                Tipo = (TipoTapecaria)reader["Tipo"],
                DataEntrada = (DateTime)reader["DataEntrada"],
                Area = Convert.ToDouble(reader["Area"]),
                PrecoMetroQuadrado = Convert.ToDecimal(reader["PrecoMetroQuadrado"]),
                EhEntrega = Convert.ToBoolean(reader["EhEntrega"]),
                Detalhes = reader["Detalhes"].ToString()
            };

            return produtoTapecaria;
        }

        private static List<ProdutoTapecaria> ConverterDataReaderParaLista(SqlDataReader reader)
        {
            ProdutoTapecaria produtoTapecaria = new();
            List<ProdutoTapecaria> listaTapecaria = new();

            while (reader.Read())
            {
                produtoTapecaria = GerarProdutoTapecaria(reader);
                listaTapecaria.Add(produtoTapecaria);
            }

            return listaTapecaria;
        }
    }
}
