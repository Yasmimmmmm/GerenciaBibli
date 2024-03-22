using GerenciamentoDeBiblioteca.Data;
using GerenciamentoDeBiblioteca.Models;
using GerenciamentoDeBiblioteca.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoDeBiblioteca.Repositorio
{
    public class LivroRepositorio : ILivroRepositorio
    {
        private readonly GerenciamentoDeBibliotecaDbContext _dbcontext;

        public LivroRepositorio(GerenciamentoDeBibliotecaDbContext gerenciamentoDeBibliotecaDbContext)
        {
            _dbcontext = gerenciamentoDeBibliotecaDbContext;
        }

        public async Task<LivroModel> BuscarPorId(int id)
        {
            return await _dbcontext.Livro.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<LivroModel>> BuscarTodosLivros()
        {
            return await _dbcontext.Livro.ToListAsync();
        }
        public async Task<LivroModel> Adicionar(LivroModel livro)
        {
            await _dbcontext.Livro.AddAsync(livro);
            await _dbcontext.SaveChangesAsync();

            return livro;
        }

        public async Task<bool> Apagar(int id)
        {
            LivroModel livro = await BuscarPorId(id);
            if (livro == null)
            {
                throw new Exception($"usuario do id:{id} nao foi encontrado ");
            }

            _dbcontext.Livro.Remove(livro);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<LivroModel> Atualizar(LivroModel livro, int id)
        {
            LivroModel livroPorId = await BuscarPorId(id);
            if (livroPorId == null)
            {
                throw new Exception($"usuario do id:{id} nao foi encontrado ");
            }

            livroPorId.Titulo = livro.Titulo;
            livroPorId.Genero = livro.Genero;
            livroPorId.AnoPubli = livro.AnoPubli;
            livroPorId.Sinopse = livro.Sinopse;
            livroPorId.ISBN = livro.ISBN;

            _dbcontext.Livro.Update(livroPorId);
            await _dbcontext.SaveChangesAsync();
            return livroPorId;
        }
    }
}
