using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/Controllers")]
    [ApiController]
    public class CuponesController : ControllerBase
    {
        private readonly ICupones _cupones;
        public CuponesController(ICupones cupones)
        {
            _cupones = cupones;
        }

        [HttpGet("GetCupones")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetCupones()
        {
            var response = await _cupones.GetCupones();
            return Ok(response);
        }

        [HttpPost("PostCupones")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostCupones([FromBody] Cupones cupones)
        {
            try
            {
                var response = await _cupones.PostCupones(cupones);
                if (response == true)
                    return Ok("Cupon Agregado correctamente");
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
