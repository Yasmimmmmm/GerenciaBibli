﻿using GerenciamentoDeBiblioteca.Models;
using GerenciamentoDeBiblioteca.Repositorio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoDeBiblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvaliacaoController : ControllerBase
    {
        private readonly IAvaliacaoRepositorio _avaliacaoRepositorio;
        public AvaliacaoController(IAvaliacaoRepositorio avaliacaoRepositorio)
        {
            _avaliacaoRepositorio = avaliacaoRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<AvaliacaoModel>>> BuscarTodasAvaliacoes()
        {
            List<AvaliacaoModel> avaliacao = await _avaliacaoRepositorio.BuscarTodasAvaliacoes();
            return Ok(avaliacao);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<AvaliacaoModel>> BuscarPorId(int id)
        {
            AvaliacaoModel avaliacao = await _avaliacaoRepositorio.BuscarPorId(id);
            return Ok(avaliacao);
        }

        [HttpPost]

        public async Task<ActionResult<AvaliacaoModel>> Adicionar([FromBody] AvaliacaoModel avaliacaoModel)
        {
            AvaliacaoModel avaliacao = await _avaliacaoRepositorio.Adicionar(avaliacaoModel);
            return Ok(avaliacao);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<AvaliacaoModel>> Atualizar(int id, [FromBody] AvaliacaoModel avaliacaoModel)
        {
            avaliacaoModel.Id = id;
            AvaliacaoModel avaliacao = await _avaliacaoRepositorio.Atualizar(avaliacaoModel, id);
            return Ok(avaliacao);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<AvaliacaoModel>> Apagar(int id)
        {
            bool apagado = await _avaliacaoRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
