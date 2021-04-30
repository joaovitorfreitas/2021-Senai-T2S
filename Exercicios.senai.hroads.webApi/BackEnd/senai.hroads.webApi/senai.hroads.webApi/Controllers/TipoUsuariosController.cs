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
    public class TipoUsuariosController : ControllerBase
    {
        private ITipoUsuarioRepository _TipoUsuarioRepository { get; set; }

        public TipoUsuariosController()
        {
            _TipoUsuarioRepository = new TipoUsuarioRepository();
        }

        /// <summary>
        /// retorna uma lista de TipoUsuario
        /// </summary>
        /// <returns>Lista de TipoUsuario</returns>
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult ListarTipos()
        {   
            if(_TipoUsuarioRepository.ListarTipoUsuario() == null)
            {
                return NotFound("Lista Tipo usuario não encontrado");
            }

            try
            {
               return Ok(_TipoUsuarioRepository.ListarTipoUsuario());
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }

        }

        /// <summary>
        ///  Um TipoUsuario
        /// </summary>
        /// <param name="id">Id do TipoUsuario passado</param>
        /// <returns>o TipoUsuario Pequisado</returns>
        [Authorize(Roles = "1")]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)


        {   if(_TipoUsuarioRepository.BuscarTipoUsuario(id) == null)
            {
                return NotFound("Tipo usuario não encontrado");
            }

            try
            {
               return Ok(_TipoUsuarioRepository.BuscarTipoUsuario(id));
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }


        /// <summary>
        ///   Deleta um TipoUsuario
        /// </summary>
        /// <param name="id">Id do TipoUsuario a Ser Deletado</param>
        /// <returns>Um TipoUsuario Deletado</returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult DeletarPorId(int id)
        {
            TipoUsuario tipoUsuarioBuscado = _TipoUsuarioRepository.BuscarTipoUsuario(id);

            if(tipoUsuarioBuscado == null)
            {
                return NotFound("Tipo de usuario não encontrado");
            }

            try
            {
                _TipoUsuarioRepository.DeletarTipoUsuario(id);

                return NoContent();
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        /// <summary>
        ///  Altera um TipoUsuario
        /// </summary>
        /// <param name="id">id do TipoUsuario</param>
        /// <param name="usuarioAtualizado">Propriedade do TipoUsuario</param>
        /// <returns>Um TipoUsuario Alterado</returns>
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult AlterarTipoUsuario(int id, TipoUsuario usuarioAtualizado)
        {
            TipoUsuario tipoUsuarioBuscado = _TipoUsuarioRepository.BuscarTipoUsuario(id);


            if (tipoUsuarioBuscado == null)
            {
                return NotFound("Tipo de usuario não encontrado");
            }

            try
            {
                _TipoUsuarioRepository.AtualizarTipoUsuario(id, usuarioAtualizado);


                return NoContent();
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        /// <summary>
        ///  Retorna um novo TipoUsuario
        /// </summary>
        /// <param name="NovoTipoUsuario">Propriedades do TipoUsuario</param>
        /// <returns>Um TipoUsuario Cadastrado</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult CadastrarTipoUsuario(TipoUsuario NovoTipoUsuario)
        {

            try
            {
                _TipoUsuarioRepository.CadastrarTipoUsuario(NovoTipoUsuario);

                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }

        }

    }
}
