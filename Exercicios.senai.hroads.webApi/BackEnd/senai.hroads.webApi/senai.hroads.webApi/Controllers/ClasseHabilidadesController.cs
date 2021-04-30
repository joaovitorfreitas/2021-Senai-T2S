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
    public class ClasseHabilidadesController : ControllerBase
    {
        private IClasseHabilidadeRepository _ClasseHabilidadeRepository { get; set; }

        public ClasseHabilidadesController()
        {
            _ClasseHabilidadeRepository = new ClasseHabilidadeRepository();
        }

        /// <summary>
        /// Retorna uma de ClasseHabilidades
        /// </summary>
        /// <returns>Uma lista de classes Habilidades</returns>
        [AllowAnonymous] 
        [HttpGet]
        public IActionResult ListarClassesHabilidades()
        {
            if (_ClasseHabilidadeRepository.ListarClasseHabilidade() == null)
            {
                return NotFound("Lista de classes Habilidades não encontrada");
            }

            try
            {
                return Ok(_ClasseHabilidadeRepository.ListarClasseHabilidade());
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Retorna uma ClasseHabilidade
        /// </summary>
        /// <param name="id">id da classeHabilidade</param>
        /// <returns>A classe Habilidade Pequisada</returns>
        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult BuscarClassesHabilidades(int id)
        {

            {
                if (_ClasseHabilidadeRepository.BuscarClasseHabilidade(id) == null)
                {
                    return NotFound("classes Habilidades não encontrada");
                }

                try
                {
                    return Ok(_ClasseHabilidadeRepository.BuscarClasseHabilidade(id));
                }
                catch (Exception erro)
                {

                    return BadRequest(erro);
                }
            }
        }

        /// <summary>
        /// Alterar uma Classe Habilidade
        /// </summary>
        /// <param name="id">id da classe Habilidade</param>
        /// <param name="novaClasseHabilidade">Propriedade da Classe Habilidade</param>
        /// <returns>Uma ClasseHabilidade Alterada</returns>
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult AlterarClasseHabilidades(int id, ClasseHabilidade novaClasseHabilidade)
        {
            ClasseHabilidade ClasseBuscadoHabilidades = _ClasseHabilidadeRepository.BuscarClasseHabilidade(id);


            if (ClasseBuscadoHabilidades == null)
            {
                return NotFound("classe Habilidade não encontrada");
            }

            try
            {
                _ClasseHabilidadeRepository.AtualizarClasseHabilidade(id, novaClasseHabilidade);


                return NoContent();
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }

        }

        /// <summary>
        /// Retorna uma nova ClasseHabilidade
        /// </summary>
        /// <param name="novaClasseHabilidade">Propriedades da classe habilidade</param>
        /// <returns>Uma nova Classe Habilidade Cadastrada</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult CadastrarClasseHabilidades(ClasseHabilidade novaClasseHabilidade)
        {

            try
            {
                _ClasseHabilidadeRepository.CadastrarClasseHabilidade(novaClasseHabilidade);

                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }


        /// <summary>
        /// Deleta uma ClasseHabilidade
        /// </summary>
        /// <param name="id">Id da ClasseHabilidade a Ser Deletada</param>
        /// <returns>Uma ClasseHabilidade Deletada</returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult DeletarClasseHabilidades(int id)
        {
            ClasseHabilidade ClasseBuscadoHabilidades = _ClasseHabilidadeRepository.BuscarClasseHabilidade(id);

            if (ClasseBuscadoHabilidades == null)
            {
                return NotFound("classe Habilidade não encontrada");
            }

            try
            {
                _ClasseHabilidadeRepository.DeletarClasseHabilidade(id);

                return NoContent();
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }
    }
}
