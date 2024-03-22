using GerenciamentoDeBiblioteca.Models;

namespace GerenciamentoDeBiblioteca.Repositorio.Interfaces
{
    public interface IReservaRepositorio
    {
        Task<List<ReservaModel>> BuscarTodasReservas();

        Task<ReservaModel> BuscarPorId(int Id);

        Task<ReservaModel> Adicionar(ReservaModel reserva);

        Task<ReservaModel> Atualizar(ReservaModel reserva, int id);

        Task<bool> Apagar(int Id);
    }
}
