using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.hroads.webApi_.Domains;
using senai.hroads.webApi_.Interfaces;
using senai.hroads.webApi_.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Controllers
{   
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository _UsuarioRepository { get; set; }

        public UsuariosController()
        {
            _UsuarioRepository = new UsuarioRepository();
        }


        /// <summary>
        /// retorna uma lista de Usuario
        /// </summary>
        /// <returns>Lista de Usuario</returns>
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult ListarPersonagems()
        {
            if (_UsuarioRepository.ListarUsuario() == null)
            {
                return NotFound("Lista de Usuario não encontrada");
            }

            try
            {
                return Ok(_UsuarioRepository.ListarUsuario());
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }


        /// <summary>
        /// Um Usuario
        /// </summary>
        /// <param name="id">Id do Usuario passado</param>
        /// <returns>o Usuario Pequisado</returns>
        [Authorize(Roles = "1")]
        [HttpGet("{id}")]
        public IActionResult BuscarUsuario(int id)
        {

            {
                if (_UsuarioRepository.BuscarUsuario(id) == null)
                {
                    return NotFound("Usuario não encontrada");
                }

                try
                {
                    return Ok(_UsuarioRepository.BuscarUsuario(id));
                }
                catch (Exception erro)
                {

                    return BadRequest(erro);
                }
            }
        }


        /// <summary>
        /// Altera um Usuario
        /// </summary>
        /// <param name="id">id do Usuario</param>
        /// <param name="novaUsuario">Propriedade do Usuario</param>
        /// <returns>Um Usuario Alterado</returns>
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult AlterarPersonagems(int id, Usuario novaUsuario)
        {
            Usuario BuscaUsuario = _UsuarioRepository.BuscarUsuario(id);


            if (BuscaUsuario == null)
            {
                return NotFound("Usuario não encontrada");
            }

            try
            {
                _UsuarioRepository.AtualizarUsuario(id, novaUsuario);


                return NoContent();
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }

        }

        /// <summary>
        ///  Retorna um novo Usuario
        /// </summary>
        /// <param name="novaUsuario">Propriedades do Usuario</param>
        /// <returns>Um Usuario Cadastrado</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult CadastrarUsuario(Usuario novaUsuario)
        {

            try
            {
                _UsuarioRepository.CadastrarUsuario(novaUsuario);

                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Deleta um Usuario
        /// </summary>
        /// <param name="id">Id do Usuario a Ser Deletado</param>
        /// <returns>Um Usuario Deletado</returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult DeletarUsuario(int id)
        {
            Usuario BuscaUsuario = _UsuarioRepository.BuscarUsuario(id);

            if (BuscaUsuario == null)
            {
                return NotFound("Usuario não encontrada");
            }

            try
            {
                _UsuarioRepository.DeletarUsuario(id);

                return NoContent();
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }
    }
}
