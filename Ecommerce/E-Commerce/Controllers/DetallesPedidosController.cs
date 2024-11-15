using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("Api/Controllers")]
    [ApiController]
    public class DetallesPedidosController : ControllerBase
    {
        private readonly IDetallesPedidos _detalles;
        public DetallesPedidosController(IDetallesPedidos detalles)
        {
            _detalles = detalles;
        }

        [HttpGet("GetDetallesPedidos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetDetallesPedidos()
        {
            var response = await _detalles.GetDetallesPedidos();
            return Ok(response);
        }

        [HttpPost("PostDetallesPedidos")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostDetallesPedidos([FromBody]  DetallesPedidos detallesPedidos)
        {
            try
            {
                var response = await _detalles.PostDetallesPedidos(detallesPedidos);
                if (response == true)
                    return Ok("Detalle del pedido agregado correctamente");
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
