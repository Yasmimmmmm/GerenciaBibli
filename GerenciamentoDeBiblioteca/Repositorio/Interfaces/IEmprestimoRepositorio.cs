using GerenciamentoDeBiblioteca.Models;

namespace GerenciamentoDeBiblioteca.Repositorio.Interfaces
{
    public interface IEmprestimoRepositorio
    {
        Task<List<EmprestimoModel>> BuscarTodosEmprestimos();

        Task<EmprestimoModel> BuscarPorId(int Id);

        Task<EmprestimoModel> Adicionar(EmprestimoModel emprestimo);

        Task<EmprestimoModel> Atualizar(EmprestimoModel emprestimo, int id);

        Task<bool> Apagar(int Id);
    }
}
