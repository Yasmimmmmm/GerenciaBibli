﻿using GerenciamentoDeBiblioteca.Models;
using GerenciamentoDeBiblioteca.Repositorio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoDeBiblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private readonly IReservaRepositorio _reservaRepositorio;
        public ReservaController(IReservaRepositorio reservaRepositorio)
        {
            _reservaRepositorio = reservaRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<ReservaModel>>> BuscarTodasReservas()
        {
            List<ReservaModel> reserva = await _reservaRepositorio.BuscarTodasReservas();
            return Ok(reserva);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<ReservaModel>> BuscarPorId(int id)
        {
            ReservaModel reserva = await _reservaRepositorio.BuscarPorId(id);
            return Ok(reserva);
        }

        [HttpPost]

        public async Task<ActionResult<ReservaModel>> Adicionar([FromBody] ReservaModel reservaModel)
        {
            ReservaModel reserva = await _reservaRepositorio.Adicionar(reservaModel);
            return Ok(reserva);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<ReservaModel>> Atualizar(int id, [FromBody] ReservaModel reservaModel)
        {
            reservaModel.Id = id;
            ReservaModel reserva = await _reservaRepositorio.Atualizar(reservaModel, id);
            return Ok(reserva);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<ReservaModel>> Apagar(int id)
        {
            bool apagado = await _reservaRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
