using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Sp_Med_Group.Domains;
using Sp_Med_Group.Interfaces;
using Sp_Med_Group.Repositories;
using Sp_Med_Group.ViewModel;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Sp_Med_Group.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuario _usuario { get; set; }

        public LoginController()
        {
            _usuario = new UsuarioRepository();
        }

        /// <summary>
        /// Loga um usuario
        /// </summary>
        /// <param name="login">Objeto do login a ser passado</param>
        /// <returns>retorna um usuario logado</returns>
        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            try
            {
                Usuario UsuarioLogin = _usuario.Login(login.Email, login.Senha);

                if (UsuarioLogin == null)
                {
                    return NotFound("Email ou senha incorreta");
                }


                var ClaimsDefinition = new[]
                {

                new Claim(JwtRegisteredClaimNames.Email, UsuarioLogin.Email),
                new Claim(JwtRegisteredClaimNames.Jti, UsuarioLogin.IdUsuario.ToString()),
                new Claim(ClaimTypes.Role, UsuarioLogin.IdTipoUsuario.ToString()),
                new Claim(JwtRegisteredClaimNames.NameId, UsuarioLogin.IdTipoUsuario.ToString())
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("SpMed-chave-autenticacao"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "SpMed-WebApi",
                    audience: "SpMed-WebApi",
                    claims: ClaimsDefinition,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds
                );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });

            }
            catch (Exception error)
            {

                return BadRequest(error);
            }
        }
    }
}
