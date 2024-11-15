using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/controlller")]
    [ApiController]
    public class ValoracionesController : ControllerBase
    {
        private readonly IValoraciones _valoraciones;
        public ValoracionesController(IValoraciones valoraciones)
        {
            _valoraciones = valoraciones;
        }

        [HttpGet("GetValoraciones")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetValoraciones()
        {
            var response = await _valoraciones.GetValoraciones();
            return Ok(response);
        }

        [HttpPost("PostValoraciones")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostValoraciones([FromBody] Valoraciones valoraciones)
        {
            try
            {
                var response = await _valoraciones.PostValoraciones(valoraciones);
                if (response == true)
                    return Ok("Se ha agregado a una Valoracion correctamente");
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
