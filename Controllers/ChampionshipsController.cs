using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kolokwium2.DAL;
using kolokwium2.DTOs.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace kolokwium2.Controllers
{
    [Route("api/championships")]
    [ApiController]
    public class ChampionshipsController : ControllerBase
    {
        private IChampionshipDbService _service;

        public ChampionshipsController(IChampionshipDbService service)
        {
            _service = service;
        }

        [HttpPut("{id}/orders")]
        public IActionResult UpdateChampionship(int id, UpdateChampionshipRequest request)
        {
            var res = _service.UpdateChampionship(id, request);

            if (res == null)
            {
                return BadRequest("Druzyna nie brala udzialu w mistrzowstwie");
            }
            else
            {
                return Ok(res);
            }
        }
    }
}