﻿using ControleDeEstoque.Dominio;
using LinqToDB.Data;
using LinqToDB;

namespace ControleDeEstoque.InfraestruturaDeDados.Repositorios
{
    public class RepositorioLinq2DB : IRepositorio
    {
        public void Criar(ProdutoTapecaria produtoTapecaria)
        {
            try
             {
                var conexaoSql = CriarConexao();

                using (conexaoSql)
                {
                    conexaoSql.Insert(produtoTapecaria);
                }
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
                    var tb_Tapecaria = conexaoSql.GetTable<ProdutoTapecaria>();

                    var query = from produtoTapecaria in tb_Tapecaria
                                where produtoTapecaria.Id == id
                                select produtoTapecaria;

                    return query.FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw new Exception("Erro na implentação de [ObterPorId( )] no RepositorioLinq2DB");
            }
        }

        public List<ProdutoTapecaria> ObterTodos()
        {
            try
            {
                var conexaoSql = CriarConexao();

                using (conexaoSql)
                {
                    return conexaoSql.GetTable<ProdutoTapecaria>().ToList();
                }
            }
            catch (Exception)
            {
                throw new Exception("Erro na implentação de [ObterTodos( )] no RepositorioLinq2DB");
            }
        }

        public void Atualizar(ProdutoTapecaria novoProdutoTapecaria)
        {
            try
            {
                var conexaoSql = CriarConexao();

                using (conexaoSql)
                {
                    conexaoSql.Update(novoProdutoTapecaria);
                }
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
                    var tb_Tapecaria = conexaoSql.GetTable<ProdutoTapecaria>();

                    var query = from produtoTapecaria in tb_Tapecaria
                                where produtoTapecaria.Id == id
                                select produtoTapecaria;

                    query.Delete();
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
                return new DataConnection(new DataOptions().UseSqlServer(ConstantesGlobais.sqlServerConnectionString));
            }
            catch (Exception)
            {
                throw new Exception("Erro de conexão ao banco de dados no RepositorioLinq2DB");
            }
        }
    }
}
