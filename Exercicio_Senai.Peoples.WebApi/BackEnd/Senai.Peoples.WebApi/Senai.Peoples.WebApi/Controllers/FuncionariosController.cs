using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using Senai.Peoples.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        private IFuncionariosRepository _FuncionariosRepository { get; set; }

        public FuncionariosController()
        {
            _FuncionariosRepository = new FuncionariosRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<FuncionariosDomain> listaFuncionarios = _FuncionariosRepository.Listar();

            return Ok(listaFuncionarios);
        }

        [HttpGet("{id}")]
        public IActionResult GetId(int id)
        {
            FuncionariosDomain funcionarioBuscado = _FuncionariosRepository.Buscarporid(id);

            if (funcionarioBuscado == null)
            {
                return NotFound("Funcionario não encontrado!");
            }

            return Ok(funcionarioBuscado);
        }

        [HttpGet("buscar/{nome}")]
        public IActionResult GetName(string nome)
        {
            FuncionariosDomain funcionarioBuscado = _FuncionariosRepository.BuscarporNome(nome);

            if (funcionarioBuscado == null)
            {
                return NotFound("Funcionario não encontrado!");
            }

            return Ok(funcionarioBuscado);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
           _FuncionariosRepository.Deletar(id);

            return StatusCode(204);

        }

        [HttpPost]
        public IActionResult Post(FuncionariosDomain novoFuncionario)
        {
            _FuncionariosRepository.Inserir(novoFuncionario);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, FuncionariosDomain funcionario)
        {
            FuncionariosDomain funcionariosBuscado = _FuncionariosRepository.Buscarporid(id);

            if(funcionariosBuscado == null)
            {
                return NotFound("Funcionario não encontrado");
            }

            try
            {
                _FuncionariosRepository.Atualizar(id, funcionario);

                return NoContent();
            }
            catch (Exception error)
            {

                return BadRequest(error);
            }
        }

        
    }
}
