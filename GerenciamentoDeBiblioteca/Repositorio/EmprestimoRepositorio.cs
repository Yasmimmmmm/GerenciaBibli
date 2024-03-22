using GerenciamentoDeBiblioteca.Data;
using GerenciamentoDeBiblioteca.Models;
using GerenciamentoDeBiblioteca.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoDeBiblioteca.Repositorio
{
    public class EmprestimoRepositorio : IEmprestimoRepositorio
    {
        private readonly GerenciamentoDeBibliotecaDbContext _dbcontext;

        public EmprestimoRepositorio(GerenciamentoDeBibliotecaDbContext gerenciamentoDeBibliotecaDbContext)
        {
            _dbcontext = gerenciamentoDeBibliotecaDbContext;
        }

        public async Task<EmprestimoModel> BuscarPorId(int id)
        {
            return await _dbcontext.Emprestimo.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<EmprestimoModel>> BuscarTodosEmprestimos()
        {
            return await _dbcontext.Emprestimo.ToListAsync();
        }
        public async Task<EmprestimoModel> Adicionar(EmprestimoModel emprestimo)
        {
            await _dbcontext.Emprestimo.AddAsync(emprestimo);
            await _dbcontext.SaveChangesAsync();

            return emprestimo;
        }

        public async Task<bool> Apagar(int id)
        {
            EmprestimoModel emprestimo = await BuscarPorId(id);
            if (emprestimo == null)
            {
                throw new Exception($"usuario do id:{id} nao foi encontrado ");
            }

            _dbcontext.Emprestimo.Remove(emprestimo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<EmprestimoModel> Atualizar(EmprestimoModel emprestimo, int id)
        {
            EmprestimoModel emprestimoPorId = await BuscarPorId(id);
            if (emprestimoPorId == null)
            {
                throw new Exception($"usuario do id:{id} nao foi encontrado ");
            }

            emprestimoPorId.DataEmprestimo = emprestimo.DataEmprestimo;
            emprestimoPorId.DataDevolucao = emprestimo.DataDevolucao;
            emprestimoPorId.StatusE = emprestimo.StatusE;

            _dbcontext.Emprestimo.Update(emprestimoPorId);
            await _dbcontext.SaveChangesAsync();
            return emprestimoPorId;
        }
    }
}
