using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/controlller")]
    [ApiController]
    public class PromocionesController : Controller
    {
        private readonly IPromociones _promociones;
        public PromocionesController(IPromociones promociones)
        {
            _promociones = promociones;
        }

        [HttpGet("GetPromociones")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetPromociones()
        {
            var response = await _promociones.GetPromociones();
            return Ok(response);
        }

        [HttpPost("PostPromociones")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostPromociones([FromBody] Promociones promociones)
        {
            try
            {
                var response = await _promociones.PostPromociones(promociones);
                if (response == true)
                    return Ok("Se ha agregado una promocion correctamente");
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
