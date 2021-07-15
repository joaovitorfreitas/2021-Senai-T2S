using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sp_Med_Group.Interfaces;
using Sp_Med_Group.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sp_Med_Group.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class PacientesController : ControllerBase
    {
        private IPaciente _Paciente { get; set;  }


        public PacientesController()
        {
            _Paciente = new PacienteRepository();
        }

        /// <summary>
        /// Lista de pacientes
        /// </summary>
        /// <returns> Lista de todos os Pacientes existentes</returns>
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_Paciente.Listar());
        }
    }
}
