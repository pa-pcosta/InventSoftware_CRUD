using Dominio;
using InfraestruturaDeDados.Repositorios;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace InterfaceSAPUI5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TapecariaController : ControllerBase 
    {
        private readonly IRepositorio _repositorio = new RepositorioSqlServer();

        public TapecariaController(/*IRepositorio repositorio*/)
        {
            //_repositorio = repositorio;
        }

        [HttpPost]
        public IActionResult Criar(ProdutoTapecaria produtoTapecaria)
        {
                _repositorio.Criar(produtoTapecaria);
                return Created($"produtoTapecaria/{produtoTapecaria.Id}", produtoTapecaria);
        }

        [HttpGet]
        public IActionResult ObterTodos()
        {
                var listaTapecaria = _repositorio.ObterTodos();
                return Ok(listaTapecaria);
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId([FromRoute] int id)
        {
            var produtoTapecaria = _repositorio.ObterPorId(id);
            return Ok(produtoTapecaria);
        }

        [HttpPut]
        public IActionResult Atualizar(ProdutoTapecaria novoProdutoTapecaria)
        {
            _repositorio.Atualizar(novoProdutoTapecaria);
            return Ok(novoProdutoTapecaria);
        }

        [HttpDelete]
        public IActionResult Remover(int id)
        {
            _repositorio.Remover(id);
            return Ok();
        }
    }
}
