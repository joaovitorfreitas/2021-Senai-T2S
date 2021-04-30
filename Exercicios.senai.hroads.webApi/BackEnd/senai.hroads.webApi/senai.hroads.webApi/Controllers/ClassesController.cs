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
    public class ClassesController : ControllerBase
    {
        private IClasseRepository _ClasseRepository { get; set; }

        public ClassesController()
        {
            _ClasseRepository = new ClasseRepository();
        }

        /// <summary>
        /// retorna uma lista de classes
        /// </summary>
        /// <returns>Lista de classes</returns>
        [AllowAnonymous] 
        [HttpGet]
        public IActionResult ListarClasses()
        {
            if (_ClasseRepository.ListarClasses() == null)
            {
                return NotFound("Lista de classes não encontrada");
            }

            try
            {
                return Ok(_ClasseRepository.ListarClasses());
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }
        /// <summary>
        /// Uma classe
        /// </summary>
        /// <param name="id">Id da classe passado</param>
        /// <returns>A classe Pequisada</returns>
        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult BuscarClasses(int id)
        {

            {
                if (_ClasseRepository.BuscarClasse(id) == null)
                {
                    return NotFound("classe não encontrada");
                }

                try
                {
                    return Ok(_ClasseRepository.BuscarClasse(id));
                }
                catch (Exception erro)
                {

                    return BadRequest(erro);
                }
            }
        }


        /// <summary>
        /// Altera uma Classe
        /// </summary>
        /// <param name="id">id da classe Classe</param>
        /// <param name="novaClasse">Propriedade da Classe Classe</param>
        /// <returns>Uma Classe Alterada</returns>
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult AlterarClasse(int id, Classe novaClasse)
        {
            Classe ClasseBuscado = _ClasseRepository.BuscarClasse(id);


            if (ClasseBuscado == null)
            {
                return NotFound("Classe não encontrada");
            }

            try
            {
                _ClasseRepository.AtualizarClasse(id, novaClasse);


                return NoContent();
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }

        }

        /// <summary>
        ///  Retorna uma nova Classe
        /// </summary>
        /// <param name="novaClasse">Propriedades da classe</param>
        /// <returns>Uma Classe Habilidade Cadastrada</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult CadastrarClasse(Classe novaClasse)
        {

            try
            {
                _ClasseRepository.CadastrarClasse(novaClasse);

                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Deleta uma Classe
        /// </summary>
        /// <param name="id">Id da Classe a Ser Deletada</param>
        /// <returns>Uma Classe Deletada</returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult DeletarClasse(int id)
        {
            Classe tipoUsuarioBuscado = _ClasseRepository.BuscarClasse(id);

            if (tipoUsuarioBuscado == null)
            {
                return NotFound("Classe não encontrada");
            }

            try
            {
                _ClasseRepository.DeletarClasse(id);

                return NoContent();
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }
    }
}
