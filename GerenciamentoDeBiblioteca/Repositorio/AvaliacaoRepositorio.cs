using GerenciamentoDeBiblioteca.Data;
using GerenciamentoDeBiblioteca.Models;
using GerenciamentoDeBiblioteca.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoDeBiblioteca.Repositorio
{
    public class AvaliacaoRepositorio : IAvaliacaoRepositorio
    {
        private readonly GerenciamentoDeBibliotecaDbContext _dbcontext;

        public AvaliacaoRepositorio(GerenciamentoDeBibliotecaDbContext gerenciamentoDeBibliotecaDbContext)
        {
            _dbcontext = gerenciamentoDeBibliotecaDbContext;
        }

        public async Task<AvaliacaoModel> BuscarPorId(int id)
        {
            return await _dbcontext.Avaliacao.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<AvaliacaoModel>> BuscarTodasAvaliacoes()
        {
            return await _dbcontext.Avaliacao.ToListAsync();
        }
        public async Task<AvaliacaoModel> Adicionar(AvaliacaoModel avaliacao)
        {
            await _dbcontext.Avaliacao.AddAsync(avaliacao);
            await _dbcontext.SaveChangesAsync();

            return avaliacao;
        }

        public async Task<bool> Apagar(int id)
        {
            AvaliacaoModel avaliacao = await BuscarPorId(id);
            if (avaliacao == null)
            {
                throw new Exception($"usuario do id:{id} nao foi encontrado ");
            }

            _dbcontext.Avaliacao.Remove(avaliacao);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<AvaliacaoModel> Atualizar(AvaliacaoModel avaliacao, int id)
        {
            AvaliacaoModel avaliacaoPorId = await BuscarPorId(id);
            if (avaliacaoPorId == null)
            {
                throw new Exception($"usuario do id:{id} nao foi encontrado ");
            }

            avaliacaoPorId.Pontuacao = avaliacao.Pontuacao;
            avaliacaoPorId.Comentario = avaliacao.Comentario;
            avaliacaoPorId.DataAvaliacao = avaliacao.DataAvaliacao;

            _dbcontext.Avaliacao.Update(avaliacaoPorId);
            await _dbcontext.SaveChangesAsync();
            return avaliacaoPorId;
        }
    }
}
