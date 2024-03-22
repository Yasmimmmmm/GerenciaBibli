using GerenciamentoDeBiblioteca.Models;

namespace GerenciamentoDeBiblioteca.Repositorio.Interfaces
{
    public interface IEditoraRepositorio
    {
        Task<List<EditoraModel>> BuscarTodasEditoras();

        Task<EditoraModel> BuscarPorId(int Id);

        Task<EditoraModel> Adicionar(EditoraModel editora);

        Task<EditoraModel> Atualizar(EditoraModel editora, int id);

        Task<bool> Apagar(int Id);
    }
}
