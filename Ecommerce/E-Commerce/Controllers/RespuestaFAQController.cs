using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/controlller")]
    [ApiController]
    public class RespuestaFAQController : Controller
    {
        private readonly IRespuestaFAQ _respuestaFAQ;
        public RespuestaFAQController(IRespuestaFAQ respuestaFAQ)
        {
            _respuestaFAQ = respuestaFAQ;
        }

        [HttpGet("GetRespuestasFAQ")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetRespuestasFAQ()
        {
            var response = await _respuestaFAQ.GetRespuestasFAQ();
            return Ok(response);
        }

        [HttpPost("PostRespuestaFAQ")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostRespuestaFAQ([FromBody] RespuestasFAQ respuestaFAQ)
        {
            try
            {
                var response = await _respuestaFAQ.PostRespuestaFAQ(respuestaFAQ);
                if (response == true)
                    return Ok("Se ha agregado una RespuestaFAQ correctamente");
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
