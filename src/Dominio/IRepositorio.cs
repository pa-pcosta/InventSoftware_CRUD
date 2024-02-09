namespace Dominio
{
    public interface IRepositorio
    {
        public int Criar(ProdutoTapecaria produtoTapecaria);

        public List<ProdutoTapecaria> ObterTodos(string? tipo, string? detalhes);

        public ProdutoTapecaria? ObterPorId(int id);

        public int Atualizar(ProdutoTapecaria novoProdutoTapecaria);

        public void Remover(int id);
    }
}
