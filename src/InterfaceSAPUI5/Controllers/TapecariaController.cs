using Dominio;
using Dominio.ValidacaoProdutoTapecaria;
using InfraestruturaDeDados.Repositorios;
using LinqToDB.Common;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
            if (produtoTapecaria is not null)
            {
                var validacao = new ValidadorProdutoTapecaria();
                var listaDeErros = validacao.ValidarProduto(produtoTapecaria);

                if (!listaDeErros.Any())
                {
                    _repositorio.Criar(produtoTapecaria);
                    return Created($"produtoTapecaria/{produtoTapecaria.Id}", produtoTapecaria);
                }
                else { return BadRequest(listaDeErros);}
            }
            else{ return BadRequest("É NULO");}
        }

        [HttpGet]
        public IActionResult ObterTodos(string? tipo)
        {
                var listaTapecaria = _repositorio.ObterTodos(tipo);
                return Ok(listaTapecaria);
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId([FromRoute] int id)
        {
            var produtoTapecaria = _repositorio.ObterPorId(id);
            return Ok(produtoTapecaria);
        }

        [HttpPut]
        public IActionResult Atualizar([FromBody]ProdutoTapecaria novoProdutoTapecaria)
        {
            if (novoProdutoTapecaria is not null)
            {
                var validacao = new ValidadorProdutoTapecaria();
                var listaDeErros = validacao.ValidarProduto(novoProdutoTapecaria);

                if (!listaDeErros.Any())
                {
                    _repositorio.Atualizar(novoProdutoTapecaria);
                    return Ok(novoProdutoTapecaria);
                }
                else { return BadRequest(listaDeErros); }
            }
            else { return BadRequest(); }
        }

        [HttpDelete("{id}")]
        public IActionResult Remover([FromRoute] int id)
        {
            _repositorio.Remover(id);
            return Ok();
        }
    }
}
