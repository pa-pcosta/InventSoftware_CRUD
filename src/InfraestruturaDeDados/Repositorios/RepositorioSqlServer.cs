using Dominio;
using Microsoft.Data.SqlClient;
using System.Configuration;
using static Dominio.EnumTipoTapecaria;

namespace InfraestruturaDeDados.Repositorios
{
    public class RepositorioSqlServer : IRepositorio
    {
        private static readonly string _connectionString = ConfigurationManager.ConnectionStrings["SQL_Server_Controle_De_Estoque"].ConnectionString;

        public void Criar(ProdutoTapecaria produtoTapecaria)
        {
            var conexaoSql = new SqlConnection(_connectionString);

            var query = $@"INSERT INTO tb_Tapecaria (Tipo, DataEntrada, Area, PrecoMetroQuadrado, EhEntrega, Detalhes) 
                        VALUES (@Tipo, 
                                @DataEntrada, 
                                @Area, 
                                @PrecoMetroQuadrado, 
                                @EhEntrega, 
                                @Detalhes);
                        SELECT SCOPE_IDENTITY();";

            var comandoSql = new SqlCommand(query, conexaoSql);

            comandoSql.Parameters.AddWithValue("@Tipo", produtoTapecaria.Tipo);
            comandoSql.Parameters.AddWithValue("@DataEntrada", produtoTapecaria.DataEntrada);
            comandoSql.Parameters.AddWithValue("@Area", produtoTapecaria.Area);
            comandoSql.Parameters.AddWithValue("@PrecoMetroQuadrado", produtoTapecaria.PrecoMetroQuadrado);
            comandoSql.Parameters.AddWithValue("@EhEntrega", produtoTapecaria.EhEntrega);
            comandoSql.Parameters.AddWithValue("@Detalhes", produtoTapecaria.Detalhes);

            conexaoSql.Open();
            produtoTapecaria.Id = Convert.ToInt32(comandoSql.ExecuteScalar());
            conexaoSql.Close();
        }

        public List<ProdutoTapecaria> ObterTodos(string? tipo, string? detalhes)
        {
            var conexaoSql = new SqlConnection(_connectionString);

            var query = @"SELECT * 
                        FROM tb_Tapecaria ";

            if (tipo is not null || detalhes is not null) 
            {
                query += $"WHERE ";

                if (tipo is not null)
                {
                    query += $"Tipo = {tipo} ";
                }

                if (tipo is not null & detalhes is not null)
                {
                    query += $"AND ";
                }

                if (detalhes is not null)
                {
                    query += $"LOWER(Detalhes) LIKE LOWER('%{detalhes}%') ";
                }
            }

            var comandoSql = new SqlCommand(query, conexaoSql);
            conexaoSql.Open();

            SqlDataReader reader = comandoSql.ExecuteReader();
            var listaTapecaria = ConverterDataReaderParaLista(reader);

            conexaoSql.Close();

            return listaTapecaria;
        }

        public ProdutoTapecaria ObterPorId(int id)
        {
            var conexaoSql = new SqlConnection(_connectionString);
            var query = $@"SELECT * 
                        FROM tb_Tapecaria 
                        WHERE Id = {id}";

            var comandoSql = new SqlCommand(query, conexaoSql);
            conexaoSql.Open();

            SqlDataReader reader = comandoSql.ExecuteReader();

            ProdutoTapecaria produtoTapecaria = new();

            if (reader.Read())
                produtoTapecaria = ConverterReaderParaProdutoTapecaria(reader);

            conexaoSql.Close();

            return produtoTapecaria;
        }

        public int Atualizar(ProdutoTapecaria novoProdutoTapecaria)
        {
            var conexaoSql = new SqlConnection(_connectionString);
            var query = @"UPDATE tb_Tapecaria
                        SET Tipo = @Tipo, 
                            DataEntrada = @DataEntrada, 
                            Area = @Area, 
                            PrecoMetroQuadrado = @PrecoMetroQuadrado, 
                            EhEntrega = @EhEntrega, 
                            Detalhes = @Detalhes
                        WHERE Id = @Id";

            var comandoSql = new SqlCommand(query, conexaoSql);

            comandoSql.Parameters.AddWithValue("@Id", novoProdutoTapecaria.Id);
            comandoSql.Parameters.AddWithValue("@Tipo", novoProdutoTapecaria.Tipo);
            comandoSql.Parameters.AddWithValue("@DataEntrada", novoProdutoTapecaria.DataEntrada);
            comandoSql.Parameters.AddWithValue("@Area", novoProdutoTapecaria.Area);
            comandoSql.Parameters.AddWithValue("@PrecoMetroQuadrado", novoProdutoTapecaria.PrecoMetroQuadrado);
            comandoSql.Parameters.AddWithValue("@EhEntrega", novoProdutoTapecaria.EhEntrega);
            comandoSql.Parameters.AddWithValue("@Detalhes", novoProdutoTapecaria.Detalhes);

            conexaoSql.Open();
            comandoSql.ExecuteNonQuery();
            conexaoSql.Close();

            return novoProdutoTapecaria.Id;
        }

        public void Remover(int id)
        {
            var conexaoSql = new SqlConnection(_connectionString);
            var query = @"DELETE FROM tb_Tapecaria
                          WHERE Id = @Id";

            var comandoSql = new SqlCommand(query, conexaoSql);

            comandoSql.Parameters.AddWithValue("@Id", id);

            conexaoSql.Open();
            comandoSql.ExecuteNonQuery();
            conexaoSql.Close();
        }

        private ProdutoTapecaria ConverterReaderParaProdutoTapecaria(SqlDataReader reader)
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

        private List<ProdutoTapecaria> ConverterDataReaderParaLista(SqlDataReader reader)
        {
            List<ProdutoTapecaria> listaTapecaria = new();

            while (reader.Read())
            {
                var produtoTapecaria = ConverterReaderParaProdutoTapecaria(reader);
                listaTapecaria.Add(produtoTapecaria);
            }

            return listaTapecaria;
        }
    }
}
