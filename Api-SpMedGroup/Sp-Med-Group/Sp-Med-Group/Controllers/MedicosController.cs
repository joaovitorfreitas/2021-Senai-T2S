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
    public class MedicosController : ControllerBase
    {
        private IMedico _MedicoRepository {get; set;}

        public MedicosController()
        {
            _MedicoRepository = new MedicoRepository();
        }
        /// <summary>
        /// Lista de medicos
        /// </summary>
        /// <returns> Lista de todos os Medicos existentes </returns>
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_MedicoRepository.Listar());        }
    }
}
