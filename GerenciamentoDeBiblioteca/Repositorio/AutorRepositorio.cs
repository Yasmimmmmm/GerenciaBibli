using GerenciamentoDeBiblioteca.Data;
using GerenciamentoDeBiblioteca.Models;
using GerenciamentoDeBiblioteca.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoDeBiblioteca.Repositorio
{
    public class AutorRepositorio : IAutorRepositorio
    {
        private readonly GerenciamentoDeBibliotecaDbContext _dbcontext;

        public AutorRepositorio(GerenciamentoDeBibliotecaDbContext gerenciamentoDeBibliotecaDbContext)
        {
            _dbcontext = gerenciamentoDeBibliotecaDbContext;
        }

        public async Task<AutorModel> BuscarPorId(int id)
        {
            return await _dbcontext.Autor.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<AutorModel>> BuscarTodosAutores()
        {
            return await _dbcontext.Autor.ToListAsync();
        }
        public async Task<AutorModel> Adicionar(AutorModel autor)
        {
            await _dbcontext.Autor.AddAsync(autor);
            await _dbcontext.SaveChangesAsync();

            return autor;
        }

        public async Task<bool> Apagar(int id)
        {
            AutorModel autor = await BuscarPorId(id);
            if (autor == null)
            {
                throw new Exception($"usuario do id:{id} nao foi encontrado ");
            }

            _dbcontext.Autor.Remove(autor);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<AutorModel> Atualizar(AutorModel autor, int id)
        {
            AutorModel autorPorId = await BuscarPorId(id);
            if (autorPorId == null)
            {
                throw new Exception($"usuario do id:{id} nao foi encontrado ");
            }

            autorPorId.Nome = autor.Nome;
            autorPorId.Nacionalidade = autor.Nacionalidade;
            autorPorId.DataNascimento = autor.DataNascimento;

            _dbcontext.Autor.Update(autorPorId);
            await _dbcontext.SaveChangesAsync();
            return autorPorId;
        }
    }
}
