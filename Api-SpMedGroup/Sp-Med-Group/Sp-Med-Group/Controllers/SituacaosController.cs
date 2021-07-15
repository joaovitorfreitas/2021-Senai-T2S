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
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class SituacaosController : ControllerBase
    {
        private ISituacao _situacao {get; set;}

        public SituacaosController()
        {
            _situacao = new SituacaoRepository();
        }

        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult ListarTudo()
        {
            return Ok(_situacao.Listar());
        }
    }
}
