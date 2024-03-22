using GerenciamentoDeBiblioteca.Models;

namespace GerenciamentoDeBiblioteca.Repositorio.Interfaces
{
    public interface IAvaliacaoRepositorio
    {
        Task<List<AvaliacaoModel>> BuscarTodasAvaliacoes();

        Task<AvaliacaoModel> BuscarPorId(int Id);

        Task<AvaliacaoModel> Adicionar(AvaliacaoModel avaliacao);

        Task<AvaliacaoModel> Atualizar(AvaliacaoModel avaliacao, int id);

        Task<bool> Apagar(int Id);
    }
}
