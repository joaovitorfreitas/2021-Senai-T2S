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
    [Produces("Application/json")]
    [ApiController]
    public class ClinicasController : ControllerBase
    {
        private IClinica _clinica {get; set;}

        public ClinicasController()
        {
            _clinica = new ClinicaRepository(); 
        }

        /// <summary>
        /// Cadastra uma nova Clinica
        /// </summary>
        /// <param name="novaClinica"> objeto da clinica a ser passada</param>
        /// <returns> retorna uma clinica cadastrada</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Clinica novaClinica)
        {
            try
            {
                _clinica.Cadastrar(novaClinica);

                return StatusCode(201);
            }
            catch (Exception error)
            {

                return BadRequest(error);
            }
        }
    }
}
