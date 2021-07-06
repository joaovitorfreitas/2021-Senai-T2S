using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sp_Med_Group.Domains;
using Sp_Med_Group.Interfaces;
using Sp_Med_Group.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace Sp_Med_Group.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ConsultumController : ControllerBase
    {
        private IConsultum _consulta { get; set; }

        public ConsultumController()
        {
            _consulta = new ConsultumRepository();
        }

        /// <summary>
        /// Busca a uma consulta de um Paciente relacionado
        /// </summary>
        /// <param name="idConsulta">Id da consulta buscada</param>
        /// <param name="idPacientes">Id do Paciente relacionado</param>
        /// <returns>retorna uma consulta pesquisa do Paciente logado</returns>
        [Authorize(Roles = "3")]
        [HttpGet("BuscarRelacionadoPaciente/{idConsulta}")]
        public IActionResult BuscarPaciente(int idConsulta, int idPacientes)
        {
            try
            {

               idPacientes = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                return Ok(_consulta.BuscarConsultaPacientes(idConsulta, idPacientes));
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Busca a uma consulta de um medico relacionado
        /// </summary>
        /// <param name="idConsulta">Id da consulta buscada</param>
        /// <param name="idMedico">Id do medico relacionado</param>
        /// <returns> retorna uma consulta pesquisa do medico logado </returns>
        [Authorize(Roles = "2")]
        [HttpGet("BuscarRelacionadoMedico/{idConsulta}")]
        public IActionResult BuscarMedico(int idConsulta, int idMedico)
        {
            try
            {
                idMedico = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                return Ok(_consulta.BuscarConsultaMedicos(idConsulta, idMedico));
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Lista todos as consultas medicos
        /// </summary>
        /// <returns>uma consulta onde está associado ao medico logado</returns>
        [Authorize(Roles = "2")]
        [HttpGet("ConsultasMedicosRelacionada")]
        public IActionResult ListarMedicos()
        {
            try
            {
                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                return Ok(_consulta.ListarConsultaMedicos(idUsuario));
            }
            catch (Exception error)
            {

                return BadRequest(error);
            }
        }

        /// <summary>
        ///  Lista todos as consultas pacientes
        /// </summary>
        /// <returns>uma consulta onde está associado ao paciente logado</returns>
        [Authorize(Roles = "3")]
        [HttpGet("ConsultasPacientesRelacionada")]

        public IActionResult ListarPacientes()
        {
            try
            {
                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                return Ok(_consulta.ListarConsultaPacientes(idUsuario));
            }
            catch (Exception error)
            {

                return BadRequest(error);
            }
        }


        /// <summary>
        /// Cadastra uma nova consulta
        /// </summary>
        /// <param name="novaConsulta">Objeto da consulta a ser passado</param>
        /// <returns> uma nova consulta cadastrada</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult CadastrarConsulta(Consultum novaConsulta)
        {
            try
            {
                _consulta.Cadastrar(novaConsulta);

                return StatusCode(201);
            }
            catch (Exception error )
            {

                return BadRequest(error);
            }
         

        }
        /// <summary>
        /// Altera Descrição atual da consulta
        /// </summary>
        /// <param name="id">Id da descrição da consulta ser alterada</param>
        /// <param name="Descricao">descricao ser alterada</param>
        /// <returns> retorna uma consulta com uma descrição alterada</returns>
        [Authorize(Roles = "2")]
        [HttpPatch("medicoAlterarDesc/{id}")]
        public IActionResult PatchDescricao(int id, Consultum Descricao)
        {
            try
            {
                _consulta.MudarDescricao(id, Descricao);
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        ///  lista de consulta
        /// </summary>
        /// <returns> uma lista de todas as consultas</returns>
        [Authorize(Roles = "1")]
        [HttpGet("ListarTodos")]
        public IActionResult ListarTodos()
        {
            try
            {
                return Ok(_consulta.ListarTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Altera a situação da consulta
        /// </summary>
        /// <param name="id">id da consulta a ser passada</param>
        /// <param name="status">status a alterar da consulta</param>
        /// <returns>um status alterado de consulta</returns>
        [Authorize(Roles = "1")]
        [HttpPatch("medicoAlterarSit/{id}")]
        public IActionResult PatchSituacao(int id, Situacao status)
        {
            try
            {
               _consulta.MudarSituacao(id, status.IdSituacao.ToString());

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
    