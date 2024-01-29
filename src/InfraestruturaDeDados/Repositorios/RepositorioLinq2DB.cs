using LinqToDB.Data;
using LinqToDB;
using System.Configuration;
using Dominio;

namespace InfraestruturaDeDados.Repositorios
{
    public class RepositorioLinq2DB : IRepositorio
    {
        public int Criar(ProdutoTapecaria produtoTapecaria)
        {
            try
            {
                var conexaoSql = CriarConexao();

                using(conexaoSql)
                {
                    produtoTapecaria.Id = conexaoSql.InsertWithInt32Identity(produtoTapecaria);
                }

                return produtoTapecaria.Id;
            }
            catch (Exception)
            {
                throw new Exception("Erro na implentação de [void Criar( )] no RepositorioLinq2DB");
            }
        }

        public ProdutoTapecaria? ObterPorId(int id)
        {
            try
            {
                var conexaoSql = CriarConexao();

                using (conexaoSql)
                {
                    var produtoTapecaria = conexaoSql
                                                .GetTable<ProdutoTapecaria>()
                                                .FirstOrDefault(x => x.Id == id);

                    return produtoTapecaria;
                }
            }
            catch (Exception)
            {
                throw new Exception("Erro na implentação de [ObterPorId( )] no RepositorioLinq2DB");
            }
        }

        public List<ProdutoTapecaria> ObterTodos(int? id)
        {
            try
            {
                var conexaoSql = CriarConexao();

                using (conexaoSql)
                {
                    if (id is null)
                    {
                        return conexaoSql
                                .GetTable<ProdutoTapecaria>()
                                .ToList();
                    }
                    else
                    {
                        return conexaoSql
                               .GetTable<ProdutoTapecaria>()
                                   .Where(x => x.Id == id)
                               .ToList();
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("Erro na implentação de [ObterTodos( )] no RepositorioLinq2DB");
            }
        }

        public int Atualizar(ProdutoTapecaria novoProdutoTapecaria)
        {
            try
            {
                var conexaoSql = CriarConexao();

                using (conexaoSql)
                {
                    conexaoSql.Update(novoProdutoTapecaria);
                }

                return novoProdutoTapecaria.Id;
            }
            catch (Exception)
            {
                throw new Exception("Erro na implentação de [Atualizar( )] no RepositorioLinq2DB");
            }
        }

        public void Remover(int id)
        {
            try
            {
                var conexaoSql = CriarConexao();

                using (conexaoSql)
                {
                    conexaoSql
                        .GetTable<ProdutoTapecaria>()
                              .Where(p => p.Id == id)
                              .Delete();
                }
            }
            catch (Exception)
            {
                throw new Exception("Erro na implentação de [Remover( )] no RepositorioLinq2DB");
            }
        }

        private DataConnection CriarConexao()
        {
            try
            {
                var connectionString = ConfigurationManager.ConnectionStrings["SQL_Server_Controle_De_Estoque"].ConnectionString;

                return new DataConnection(new DataOptions().UseSqlServer(connectionString));
            }
            catch (Exception)
            {
                throw new Exception("Erro de conexão ao banco de dados no RepositorioLinq2DB");
            }
        }
    }
}
