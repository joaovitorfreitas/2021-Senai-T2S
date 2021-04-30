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
    public class TipoHabilidadesController : ControllerBase
    {
        private ITipoHabilidadeRepository _tipoHabilidadeRepository { get; set;}

        public TipoHabilidadesController()
        {
            _tipoHabilidadeRepository = new TipoHabilidadeRepository();
        }


        /// <summary>
        /// retorna uma lista de TipoHabilidade
        /// </summary>
        /// <returns>Lista de TipoHabilidade</returns>
        [HttpGet]
        public IActionResult ListarTipoHabilidade()
        {
            if (_tipoHabilidadeRepository.ListarTipoHabilidade() == null)
            {
                return NotFound("Lista Tipo Habilidade não encontrada");
            }

            try
            {
                return Ok(_tipoHabilidadeRepository.ListarTipoHabilidade());
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }

        }

        /// <summary>
        /// Um TipoHabilidade
        /// </summary>
        /// <param name="id">Id do TipoHabilidade passado</param>
        /// <returns>o TipoHabilidade Pequisado</returns>
        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult BuscaTipoHabilidade(int id)
        {
            if (_tipoHabilidadeRepository.BuscarTipoHabilidade(id) == null)
            {
                return NotFound("Lista Tipo Habilidade não encontrada");
            }

            try
            {
                return Ok(_tipoHabilidadeRepository.BuscarTipoHabilidade(id));
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }            
        }

        /// <summary>
        ///  Altera um TipoHabilidade
        /// </summary>
        /// <param name="id">id do TipoHabilidade</param>
        /// <param name="AtualizarTipoHabilidade">Propriedade do TipoHabilidade</param>
        /// <returns>Um TipoHabilidade Alterado</returns>
        [AllowAnonymous]
        [HttpPut("{id}")]
        public IActionResult AlterarTipoHabilidade(int id, TipoHabilidade AtualizarTipoHabilidade)
        {
            TipoHabilidade tipoHabilidadeBuscado = _tipoHabilidadeRepository.BuscarTipoHabilidade(id);


            if (tipoHabilidadeBuscado == null)
            {
                return NotFound("Tipo de Habilidade não encontrada");
            }

            try
            {
                _tipoHabilidadeRepository.AtualizarTipoHabilidade(id, AtualizarTipoHabilidade);


                return NoContent();
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        /// <summary>
        ///  Retorna um novo TipoHabilidade
        /// </summary>
        /// <param name="NovoTipoHabilidade">Propriedades do TipoHabilidade</param>
        /// <returns>Um TipoHabilidade Cadastrado</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult CadastrarTipoHabilidade(TipoHabilidade NovoTipoHabilidade)
        {
            try
            {
                _tipoHabilidadeRepository.CadastrarTipoHabilidade(NovoTipoHabilidade);

                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }

        }

        /// <summary>
        ///  Deleta um TipoHabilidade
        /// </summary>
        /// <param name="id">Id do TipoHabilidade a Ser Deletado</param>
        /// <returns>Um TipoHabilidade Deletado</returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult RemoverTipoHabilidade(int id)
        {
            TipoHabilidade tipoHabilidadeBuscado = _tipoHabilidadeRepository.BuscarTipoHabilidade(id);

            if (tipoHabilidadeBuscado == null)
            {
                return NotFound("Tipo de Habilidade não encontrada");
            }

            try
            {
                _tipoHabilidadeRepository.DeletarTipoHabilidade(id);

                return NoContent();
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }


    }
}
