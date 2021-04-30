using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai.hroads.webApi_.Domains;
using senai.hroads.webApi_.Interfaces;
using senai.hroads.webApi_.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _LoginRepository { get; set; }

        public LoginController()
        {
            _LoginRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Metodo de login
        /// </summary>
        /// <param name="user">Propriedades email e senha</param>
        /// <returns>Retorna um token </returns>
        [HttpPost]
        public IActionResult Login(Usuario user)
        {
            Usuario UsuarioLogin = _LoginRepository.Login(user.Email, user.Senha);

            if(UsuarioLogin == null)
            {
                return NotFound("E-mail ou senha errado");
            }

            var ClaimsDefinition = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, UsuarioLogin.Email),
                new Claim(JwtRegisteredClaimNames.Jti, UsuarioLogin.IdUsuario.ToString()),
                new Claim(ClaimTypes.Role, UsuarioLogin.IdTipoUsuario.ToString())
            };

            var chaveSeguranca = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Chave-Seguranca-Api-autenticacao"));

            var crendenciais = new SigningCredentials(chaveSeguranca, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer:"Hroads.WebApi",
                audience:"Hroads.WebApi",
                claims : ClaimsDefinition,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials : crendenciais

            );

            return Ok(
                new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });

        }
    }
}
