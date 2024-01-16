using Dominio;
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

        [HttpGet]
        public IActionResult ObterTodos()
        {
            try
            {
                var listaTapecaria = _repositorio.ObterTodos();
                return Ok(listaTapecaria);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        public IActionResult ObterPorId(int id)
        {
            try
            {
                var produtoTapecaria = _repositorio.ObterTodos();
                return Ok(produtoTapecaria);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
