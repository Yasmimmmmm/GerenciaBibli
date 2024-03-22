using GerenciamentoDeBiblioteca.Data;
using GerenciamentoDeBiblioteca.Models;
using GerenciamentoDeBiblioteca.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoDeBiblioteca.Repositorio
{
    public class EditoraRepositorio : IEditoraRepositorio
    {
        private readonly GerenciamentoDeBibliotecaDbContext _dbcontext;

        public EditoraRepositorio(GerenciamentoDeBibliotecaDbContext gerenciamentoDeBibliotecaDbContext)
        {
            _dbcontext = gerenciamentoDeBibliotecaDbContext;
        }

        public async Task<EditoraModel> BuscarPorId(int id)
        {
            return await _dbcontext.Editora.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<EditoraModel>> BuscarTodasEditoras()
        {
            return await _dbcontext.Editora.ToListAsync();
        }
        public async Task<EditoraModel> Adicionar(EditoraModel editora)
        {
            await _dbcontext.Editora.AddAsync(editora);
            await _dbcontext.SaveChangesAsync();

            return editora;
        }

        public async Task<bool> Apagar(int id)
        {
            EditoraModel editora = await BuscarPorId(id);
            if (editora == null)
            {
                throw new Exception($"usuario do id:{id} nao foi encontrado ");
            }

            _dbcontext.Editora.Remove(editora);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<EditoraModel> Atualizar(EditoraModel editora, int id)
        {
            EditoraModel editoraPorId = await BuscarPorId(id);
            if (editoraPorId == null)
            {
                throw new Exception($"usuario do id:{id} nao foi encontrado ");
            }

            editoraPorId.Nome = editora.Nome;
            editoraPorId.Localizacao = editora.Localizacao;
            editoraPorId.AnoFundacao = editora.AnoFundacao;

            _dbcontext.Editora.Update(editoraPorId);
            await _dbcontext.SaveChangesAsync();
            return editoraPorId;
        }
    }
}
