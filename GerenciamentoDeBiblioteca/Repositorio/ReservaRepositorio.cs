using GerenciamentoDeBiblioteca.Data;
using GerenciamentoDeBiblioteca.Models;
using GerenciamentoDeBiblioteca.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoDeBiblioteca.Repositorio
{
    public class ReservaRepositorio : IReservaRepositorio
    {
        private readonly GerenciamentoDeBibliotecaDbContext _dbcontext;

        public ReservaRepositorio(GerenciamentoDeBibliotecaDbContext gerenciamentoDeBibliotecaDbContext)
        {
            _dbcontext = gerenciamentoDeBibliotecaDbContext;
        }

        public async Task<ReservaModel> BuscarPorId(int id)
        {
            return await _dbcontext.Reserva.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<ReservaModel>> BuscarTodasReservas()
        {
            return await _dbcontext.Reserva.ToListAsync();
        }
        public async Task<ReservaModel> Adicionar(ReservaModel reserva)
        {
            await _dbcontext.Reserva.AddAsync(reserva);
            await _dbcontext.SaveChangesAsync();

            return reserva;
        }

        public async Task<bool> Apagar(int id)
        {
            ReservaModel reserva = await BuscarPorId(id);
            if (reserva == null)
            {
                throw new Exception($"usuario do id:{id} nao foi encontrado ");
            }

            _dbcontext.Reserva.Remove(reserva);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<ReservaModel> Atualizar(ReservaModel reserva, int id)
        {
            ReservaModel reservaPorId = await BuscarPorId(id);
            if (reservaPorId == null)
            {
                throw new Exception($"usuario do id:{id} nao foi encontrado ");
            }

            reservaPorId.DataReserva = reserva.DataReserva;
            reservaPorId.StatusR = reserva.StatusR;

            _dbcontext.Reserva.Update(reservaPorId);
            await _dbcontext.SaveChangesAsync();
            return reservaPorId;
        }
    }
}
