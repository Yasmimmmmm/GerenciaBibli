﻿using GerenciamentoDeBiblioteca.Models;
using GerenciamentoDeBiblioteca.Repositorio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoDeBiblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly ILivroRepositorio _livroRepositorio;
        public LivroController(ILivroRepositorio livroRepositorio)
        {
            _livroRepositorio = livroRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<LivroModel>>> BuscarTodosLivros()
        {
            List<LivroModel> livro = await _livroRepositorio.BuscarTodosLivros();
            return Ok(livro);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<LivroModel>> BuscarPorId(int id)
        {
            LivroModel livro = await _livroRepositorio.BuscarPorId(id);
            return Ok(livro);
        }

        [HttpPost]

        public async Task<ActionResult<LivroModel>> Adicionar([FromBody] LivroModel livroModel)
        {
            LivroModel livro = await _livroRepositorio.Adicionar(livroModel);
            return Ok(livro);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<LivroModel>> Atualizar(int id, [FromBody] LivroModel livroModel)
        {
            livroModel.Id = id;
            LivroModel livro = await _livroRepositorio.Atualizar(livroModel, id);
            return Ok(livro);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<LivroModel>> Apagar(int id)
        {
            bool apagado = await _livroRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
