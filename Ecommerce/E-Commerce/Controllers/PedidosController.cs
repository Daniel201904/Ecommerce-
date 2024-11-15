using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/controlller")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidos _pedidos;
        public PedidosController(IPedidos pedidos)
        {
            _pedidos = pedidos;
        }

        [HttpGet("GetPedidos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetPedidos()
        {
            var response = await _pedidos.GetPedidos();
            return Ok(response);
        }

        [HttpPost("PostPedidos")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostPedidos([FromBody] Pedidos pedidos)
        {
            try
            {
                var response = await _pedidos.PostPedidos(pedidos);
                if (response == true)
                    return Ok("Se ha agregado un pedido correctamente");
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
