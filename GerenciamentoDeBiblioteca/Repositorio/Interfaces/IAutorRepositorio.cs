using GerenciamentoDeBiblioteca.Models;

namespace GerenciamentoDeBiblioteca.Repositorio.Interfaces
{
    public interface IAutorRepositorio
    {
        Task<List<AutorModel>> BuscarTodosAutores();

        Task<AutorModel> BuscarPorId(int Id);

        Task<AutorModel> Adicionar(AutorModel autor);

        Task<AutorModel> Atualizar(AutorModel autor, int id);

        Task<bool> Apagar(int Id);
    }
}
