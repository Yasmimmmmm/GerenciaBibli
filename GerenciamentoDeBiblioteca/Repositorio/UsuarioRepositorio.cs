using GerenciamentoDeBiblioteca.Data;
using GerenciamentoDeBiblioteca.Models;
using GerenciamentoDeBiblioteca.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoDeBiblioteca.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly GerenciamentoDeBibliotecaDbContext _dbcontext;

        public UsuarioRepositorio(GerenciamentoDeBibliotecaDbContext gerenciamentoDeBibliotecaDbContext)
        {
            _dbcontext = gerenciamentoDeBibliotecaDbContext;
        }

        public async Task<UsuarioModel> BuscarPorId(int id)
        {
            return await _dbcontext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _dbcontext.Usuarios.ToListAsync();
        }
        public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
        {
            await _dbcontext.Usuarios.AddAsync(usuario);
            await _dbcontext.SaveChangesAsync();

            return usuario;
        }

        public async Task<bool> Apagar(int id)
        {
            UsuarioModel usuario = await BuscarPorId(id);
            if (usuario == null)
            {
                throw new Exception($"usuario do id:{id} nao foi encontrado ");
            }

            _dbcontext.Usuarios.Remove(usuario);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);
            if (usuarioPorId == null)
            {
                throw new Exception($"usuario do id:{id} nao foi encontrado ");
            }

            usuarioPorId.Email = usuario.Email;
            usuarioPorId.Senha = usuario.Senha;

            _dbcontext.Usuarios.Update(usuarioPorId);
            await _dbcontext.SaveChangesAsync();
            return usuarioPorId;
        }


    }
}
