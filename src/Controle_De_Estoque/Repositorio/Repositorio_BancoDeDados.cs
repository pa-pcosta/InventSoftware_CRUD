using Controle_De_Estoque.Dominio;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle_De_Estoque.Repositorio
{
    internal class Repositorio_BancoDeDados : IRepository
    {
        private static readonly string _connectionString = ConfigurationManager.ConnectionStrings["SQL_Server_Controle_De_Estoque"].ConnectionString;
        private SqlConnection _conexaoSql = new SqlConnection(_connectionString);

        public List<ProdutoTapecaria> ObterTodos()
        {
            List<ProdutoTapecaria> listaTapecaria = new List<ProdutoTapecaria>();

            var query = "SELECT * " +
                        "FROM tb_Tapecaria " +
                        "ORDER BY Id";

            SqlCommand comandoSql = new SqlCommand(query,_conexaoSql);

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

            ProdutoTapecaria produtoTapecaria = GeraProdutoTapecaria(reader);

            _conexaoSql.Close();

            return produtoTapecaria;
        }

        public void Criar(ProdutoTapecaria produtoTapecaria)
        {
            string data = produtoTapecaria.DataEntrada.ToString();

            var query = $@"INSERT INTO tb_Tapecaria (Tipo, Area, PrecoMetroQuadrado, EhEntrega, Detalhes) 
                        VALUES ({(int)produtoTapecaria.Tipo}, {produtoTapecaria.Area}, {produtoTapecaria.PrecoMetroQuadrado}, {produtoTapecaria.EhEntrega}, {produtoTapecaria.Detalhes})";
            
            SqlCommand comandoSql = new SqlCommand(query, _conexaoSql);

            _conexaoSql.Open();

            comandoSql.ExecuteNonQuery();
                    
            _conexaoSql.Close();
        }

        public void Atualizar(int idProdutoASerEditado, ProdutoTapecaria novoProdutoTapecaria)
        {
            throw new NotImplementedException();
        }

        public void Remover(int id)
        {
        }

        private ProdutoTapecaria GeraProdutoTapecaria(SqlDataReader reader)
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
                produtoTapecaria = GeraProdutoTapecaria(reader);
                listaTapecaria.Add(produtoTapecaria);
            }

            return listaTapecaria;
        }
    }
}
