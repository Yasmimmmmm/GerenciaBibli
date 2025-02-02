﻿using GerenciamentoDeBiblioteca.Data;
using GerenciamentoDeBiblioteca.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GerenciamentoDeBiblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly GerenciamentoDeBibliotecaDbContext _DbContext;
        public LoginController(GerenciamentoDeBibliotecaDbContext gerenciamentoDeBibliotecaDbContext)
        {
            _DbContext = gerenciamentoDeBibliotecaDbContext;
        }
        [HttpPost]
        public IActionResult Login(UsuarioModel usuario)
        {
            var usuariosVerdadero = _DbContext.Usuarios.FirstOrDefault(u => u.Email == usuario.Email);


            if (usuariosVerdadero != null && usuariosVerdadero.Senha == usuario.Senha)
            {
                var token = GerarToken();
                return Ok(new { token });
            }

            if (usuario.Email == "admin" && usuario.Senha == "admin")
            {
                var token = GerarToken();
                return Ok(new { token });
            }

            return BadRequest(new { mensagem = "Credenciais inválidas. Por favor, verifique e tente novamente." });
        }

        private string GerarToken()
        {
            string chaveSecreta = "20ccd6b9-a66a-4761-8b70-64a656226f52";

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(chaveSecreta));
            var credencial = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
             new Claim("login", "admin"),
             new Claim("Nome", "Administrador do Sistema")
         };

            var token = new JwtSecurityToken(
                issuer: "empresa",//emissor do token
                audience: "aplicacao",//destinatário= aplicação que irá usar o token
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credencial
             );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
