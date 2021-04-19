using Exercicios_Inlock_webApi.Interfaces;
using Exercicios_Inlock_webApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercicios_Inlock_webApi.Controllers
{   

    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class jogosController : ControllerBase
    {
        private IjogoRepository _jogoRepository { get; set;}


        public jogosController()
        {
            _jogoRepository = new jogoRepository();
        }


        [HttpGet]

        public IActionResult ListarJogos()
        {
            return Ok(_jogoRepository.ListarJogo());
        }
    }
}
