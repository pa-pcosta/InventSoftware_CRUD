using Dominio;
using Dominio.ValidacaoProdutoTapecaria;
using Microsoft.AspNetCore.Mvc;
using static Dominio.EnumTipoTapecaria;

namespace InterfaceSAPUI5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TapecariaController : ControllerBase 
    {
        private readonly IRepositorio _repositorio;

        public TapecariaController(IRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpPost]
        public IActionResult Criar([FromBody]ProdutoTapecaria produtoTapecaria)
        {
            try
            {
                var validacao = new ValidadorProdutoTapecaria();
                validacao.ValidarProduto(produtoTapecaria);

                _repositorio.Criar(produtoTapecaria);
                return Created($"produtoTapecaria/{produtoTapecaria.Id}", produtoTapecaria);
            }  
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpGet]
        public IActionResult ObterTodos(string? tipo, string? detalhes)
        {
                var listaTapecaria = _repositorio.ObterTodos(tipo, detalhes);
                return Ok(listaTapecaria);
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId([FromRoute] int id)
        {
            var produtoTapecaria = _repositorio.ObterPorId(id);
            return Ok(produtoTapecaria);
        }

        [HttpGet("enumTipoTapecaria")]
        public IActionResult ObterTiposTapecaria()
        {
            var tiposTapecaria = new List<object>();

            foreach (var tipo in Enum.GetValues(typeof(TipoTapecaria)))
            {
                tiposTapecaria.Add(new
                {
                    chave = (int)tipo,
                    descricao = tipo.ToString()
                });
            }

            return Ok(tiposTapecaria);
        }

        [HttpPut]
        public IActionResult Atualizar([FromBody]ProdutoTapecaria novoProdutoTapecaria)
        {
            try
            {
                var validacao = new ValidadorProdutoTapecaria();
                validacao.ValidarProduto(novoProdutoTapecaria);

                _repositorio.Atualizar(novoProdutoTapecaria);
                return Ok(novoProdutoTapecaria);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Remover([FromRoute] int id)
        {
            _repositorio.Remover(id);
            return Ok();
        }
    }
}
