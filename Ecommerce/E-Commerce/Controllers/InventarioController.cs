using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/controlller")]
    [ApiController]
    public class InventarioController : ControllerBase
    {
        private readonly IInventarios _inventarios;
        public InventarioController(IInventarios inventarios)
        {
            _inventarios = inventarios;
        }

        [HttpGet("GetInventarios")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetInventarios()
        {
            var response = await _inventarios.GetInventarios();
            return Ok(response);
        }

        [HttpPost("PostInventarios")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostInventarios([FromBody] Inventarios inventarios)
        {
            try
            {
                var response = await _inventarios.PostInventarios(inventarios);
                if (response == true)
                    return Ok("El nuevo inventario a sido agregado correctamente");
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
