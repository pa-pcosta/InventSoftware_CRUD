using System.Collections.Generic;

namespace Controle_De_Estoque
{
    public interface IRepository
    {
        public List<ProdutoTapecaria> ObterTodos();

        void ObterPorId(int id);

        public void Criar(ProdutoTapecaria produtoTapecaria);

        public void Atualizar(int id);

        public void Remover(int id);
    }
}
