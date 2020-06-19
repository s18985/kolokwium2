using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kolokwium2.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace kolokwium2.Controllers
{
    [Route("api/players")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private IChampionshipDbService _service;

        public PlayersController(IChampionshipDbService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public IActionResult GetPlayer(int id)
        {
            var res = _service.GetPlayer(id);

            if (res != null)
            {
                return Ok(res);
            }
            else
            {
                return NotFound("Nie ma takiego gracza");
            }
        }
    }
}