using Exercicios_Inlock_webApi.Domains;
using Exercicios_Inlock_webApi.Interfaces;
using Exercicios_Inlock_webApi.Repositories;
using Microsoft.AspNetCore.Authorization;
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

     
  
            private IjogoRepository _jogoRepository { get; set; }


            public jogosController()
            {
                _jogoRepository = new jogoRepository();
            }

        [Authorize(Roles = "1,2")]
        
        [HttpGet]

            public IActionResult ListarJogos()
            {
                return Ok(_jogoRepository.ListarJogo());
            }

        [Authorize(Roles = "1")]
        [HttpPost]
            public IActionResult CadastrarJogo(jogoDomain jogos)
            {
                _jogoRepository.CadastrarJogo(jogos);

                return StatusCode(201);
            }
        
    }
}
