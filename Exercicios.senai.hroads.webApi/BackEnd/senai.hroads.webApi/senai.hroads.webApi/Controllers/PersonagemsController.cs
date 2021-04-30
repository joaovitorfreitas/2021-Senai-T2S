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
    public class PersonagemsController : ControllerBase
    {
        private IPersonagemRepository _PersonagemRepository { get; set; }

        public PersonagemsController()
        {
            _PersonagemRepository = new PersonagemRepository();
        }

        /// <summary>
        /// retorna uma lista de Personagem
        /// </summary>
        /// <returns>Lista de Personagem</returns>
        [Authorize(Roles = "3,1")]
        [HttpGet]
        public IActionResult ListarPersonagems()
        {
            if (_PersonagemRepository.ListarPersonagens() == null)
            {
                return NotFound("Lista de Personagem não encontrada");
            }

            try
            {
                return Ok(_PersonagemRepository.ListarPersonagens());
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Um Personagem
        /// </summary>
        /// <param name="id">Id do Personagem passado</param>
        /// <returns>o Personagem Pequisado</returns>
        [Authorize(Roles = "3,1")]
        [HttpGet("{id}")]
        public IActionResult BuscarPersonagems(int id)
        {

            {
                if (_PersonagemRepository.BuscarPersonagem(id) == null)
                {
                    return NotFound("Personagem não encontrada");
                }

                try
                {
                    return Ok(_PersonagemRepository.BuscarPersonagem(id));
                }
                catch (Exception erro)
                {

                    return BadRequest(erro);
                }
            }
        }

        /// <summary>
        /// Altera um Personagem
        /// </summary>
        /// <param name="id">id do Personagem</param>
        /// <param name="novaPersonagem">Propriedade do Personagem</param>
        /// <returns>Um Personagem Alterado</returns>
        [Authorize(Roles = "3")]
        [HttpPut("{id}")]
        public IActionResult AlterarPersonagems(int id, Personagem novaPersonagem)
        {
            Personagem BuscaPersonagem = _PersonagemRepository.BuscarPersonagem(id);


            if (BuscaPersonagem == null)
            {
                return NotFound("Personagem não encontrada");
            }

            try
            {
                _PersonagemRepository.AtualizarPersonagem(id, novaPersonagem);


                return NoContent();
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }

        }

        /// <summary>
        /// Retorna um novo Personagem
        /// </summary>
        /// <param name="novaPersonagem">Propriedades do Personagem</param>
        /// <returns>Um Personagem Cadastrado</returns>  
        [Authorize(Roles = "3")]
        [HttpPost]
        public IActionResult CadastrarPersonagems(Personagem novaPersonagem)
        {

            try
            {
                _PersonagemRepository.CadastrarPersonagem(novaPersonagem);

                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        /// <summary>
        ///  Deleta um Personagem
        /// </summary>
        /// <param name="id">Id do Personagem a Ser Deletado</param>
        /// <returns>Um Personagem Deletado</returns>
        [Authorize(Roles = "3")]
        [HttpDelete("{id}")]
        public IActionResult DeletarPersonagems(int id)
        {
            Personagem BuscaPersonagem = _PersonagemRepository.BuscarPersonagem(id);

            if (BuscaPersonagem == null)
            {
                return NotFound("Personagem não encontrada");
            }

            try
            {
                _PersonagemRepository.DeletarPersonagem(id);

                return NoContent();
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }
    }
}
