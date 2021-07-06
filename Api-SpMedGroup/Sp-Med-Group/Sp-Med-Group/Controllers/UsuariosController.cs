using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sp_Med_Group.Domains;
using Sp_Med_Group.Interfaces;
using Sp_Med_Group.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sp_Med_Group.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]

    public class UsuariosController : ControllerBase
    {
        private IUsuario _usuario { get; set; }

        public UsuariosController()
        {
            _usuario = new UsuarioRepository();
        }

        /// <summary>
        /// Cadastra um usuario
        /// </summary>
        /// <param name="novoUsuario">Objeto do usuario a ser cadastrado</param>
        /// <returns>um novo usuario cadastrado</returns>
        [Authorize(Roles = "1")]
        [HttpPost]   
        public IActionResult CadastrarUser(Usuario novoUsuario)
        {
            try
            {
                _usuario.Cadastrar(novoUsuario);

                return StatusCode(201);
            }
            catch (Exception error)
            {

                return BadRequest(error);
            }
        }

    }
}
