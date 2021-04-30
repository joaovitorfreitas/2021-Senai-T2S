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
    public class HabilidadesController : ControllerBase
    {
        private IHabilidadeRepository _HabilidadeRepository { get; set; }

        public HabilidadesController()
        {
            _HabilidadeRepository = new HabilidadeRepository();
        }

        /// <summary>
        /// retorna uma lista de Habilidades
        /// </summary>
        /// <returns>Lista de Habilidades</returns>
        [AllowAnonymous]
        [HttpGet]
        public IActionResult ListarHabilidades()
        {
            if (_HabilidadeRepository.ListarHabilidade() == null)
            {
                return NotFound("Lista de Habilidades não encontrada");
            }

            try
            {
                return Ok(_HabilidadeRepository.ListarHabilidade());
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Uma Habilidade
        /// </summary>
        /// <param name="id">Id da Habilidade passada</param>
        /// <returns>A Habilidade Pequisada</returns>
        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult BuscarHabilidades(int id)
        {

            {
                if (_HabilidadeRepository.BuscarHabilidade(id) == null)
                {
                    return NotFound("Habilidades não encontrada");
                }

                try
                {
                    return Ok(_HabilidadeRepository.BuscarHabilidade(id));
                }
                catch (Exception erro)
                {

                    return BadRequest(erro);
                }
            }
        }

        /// <summary>
        /// Altera uma Habilidade
        /// </summary>
        /// <param name="id">id da classe Habilidade</param>
        /// <param name="novaHabilidade">Propriedade da Classe Habilidade</param>
        /// <returns>Uma Habilidade Alterada</returns>
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult AlterarHabilidades(int id, Habilidade novaHabilidade)
        {
            Habilidade BuscaHabilidades = _HabilidadeRepository.BuscarHabilidade(id);


            if (BuscaHabilidades == null)
            {
                return NotFound("Habilidade não encontrada");
            }

            try
            {
                _HabilidadeRepository.AtualizarHabilidade(id, novaHabilidade);


                return NoContent();
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }

        }

        /// <summary>
        /// Retorna uma nova Habilidade
        /// </summary>
        /// <param name="novaHabilidade">Propriedades da Habilidade</param>
        /// <returns>Uma Habilidade Cadastrada</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult CadastrarHabilidades(Habilidade novaHabilidade)
        {

            try
            {
                _HabilidadeRepository.CadastrarHabilidade(novaHabilidade);

                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Deleta uma Habilidade
        /// </summary>
        /// <param name="id">Id da Habilidade a Ser Deletada</param>
        /// <returns>Uma Habilidade Deletada</returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult DeletarHabilidades(int id)
        {
            Habilidade BuscaHabilidades = _HabilidadeRepository.BuscarHabilidade(id);

            if (BuscaHabilidades == null)
            {
                return NotFound("Habilidade não encontrada");
            }

            try
            {
                _HabilidadeRepository.DeletarHabilidade(id);

                return NoContent();
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }
    }
}
