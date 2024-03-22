using GerenciamentoDeBiblioteca.Models;
using GerenciamentoDeBiblioteca.Repositorio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoDeBiblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IAutorRepositorio _autorRepositorio;
        public AutorController(IAutorRepositorio autorRepositorio)
        {
            _autorRepositorio = autorRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<AutorModel>>> BuscarTodosAutores()
        {
            List<AutorModel> autor = await _autorRepositorio.BuscarTodosAutores();
            return Ok(autor);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<AutorModel>> BuscarPorId(int id)
        {
            AutorModel autor = await _autorRepositorio.BuscarPorId(id);
            return Ok(autor);
        }

        [HttpPost]

        public async Task<ActionResult<AutorModel>> Adicionar([FromBody] AutorModel autorModel)
        {
            AutorModel autor = await _autorRepositorio.Adicionar(autorModel);
            return Ok(autor);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<AutorModel>> Atualizar(int id, [FromBody] AutorModel autorModel)
        {
            autorModel.Id = id;
            AutorModel autor = await _autorRepositorio.Atualizar(autorModel, id);
            return Ok(autor);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<AutorModel>> Apagar(int id)
        {
            bool apagado = await _autorRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
