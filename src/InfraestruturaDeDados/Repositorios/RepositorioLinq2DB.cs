using ControleDeEstoque.Dominio;
using LinqToDB.Data;
using LinqToDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque.InfraestruturaDeDados.Repositorios
{
    public class RepositorioLinq2DB : IRepositorio
    {
        public void Atualizar(int idProdutoASerEditado, ProdutoTapecaria novoProdutoTapecaria)
        {
            var db = CriarConexao();
            
        }

        public void Criar(ProdutoTapecaria produtoTapecaria)
        {
            throw new NotImplementedException();
        }

        public ProdutoTapecaria? ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<ProdutoTapecaria> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public void Remover(int id)
        {
            throw new NotImplementedException();
        }

        private DataConnection CriarConexao()
        {
            return new DataConnection(new DataOptions().UseSqlServer(ConstantesGlobais.sqlServerConnectionString));
        }
    }
}
