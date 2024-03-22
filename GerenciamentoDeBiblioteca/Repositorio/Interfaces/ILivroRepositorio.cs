using GerenciamentoDeBiblioteca.Models;

namespace GerenciamentoDeBiblioteca.Repositorio.Interfaces
{
    public interface ILivroRepositorio
    {
        Task<List<LivroModel>> BuscarTodosLivros();

        Task<LivroModel> BuscarPorId(int Id);

        Task<LivroModel> Adicionar(LivroModel livro);

        Task<LivroModel> Atualizar(LivroModel livro, int id);

        Task<bool> Apagar(int Id);
    }
}
