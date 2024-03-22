﻿using GerenciamentoDeBiblioteca.Models;

namespace GerenciamentoDeBiblioteca.Repositorio.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<List<UsuarioModel>> BuscarTodosUsuarios();

        Task<UsuarioModel> BuscarPorId(int Id);

        Task<UsuarioModel> Adicionar(UsuarioModel usuario);

        Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id);

        Task<bool> Apagar(int Id);
    }
}
