using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/controlller")]
    [ApiController]
    public class TikectsSoporteController : Controller
    {
        private readonly ITikectsSoporte _tikectsSoporte;
        public TikectsSoporteController(ITikectsSoporte tikectsSoporte)
        {
            _tikectsSoporte = tikectsSoporte;
        }

        [HttpGet("GetTicketsSoporte")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetTicketsSoporte()
        {
            var response = await _tikectsSoporte.GetTicketsSoporte();
            return Ok(response);
        }

        [HttpPost("PostTicketsSoporte")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostTicketsSoporte([FromBody] TicketsSoporte tikectsSoporte)
        {
            try
            {
                var response = await _tikectsSoporte.PostTicketsSoporte(tikectsSoporte);
                if (response == true)
                    return Ok("Se ha agregado un ticket de soporte correctamente");
                else
                    return BadRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
