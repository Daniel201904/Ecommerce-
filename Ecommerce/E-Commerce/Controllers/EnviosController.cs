using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/controlller")]
    [ApiController]
    public class EnviosController : ControllerBase
    {
        private readonly IEnvios _envios;
        public EnviosController(IEnvios envios)
        {
            _envios = envios;
        }

        [HttpGet("GetEnvios")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetEnvios()
        {
            var response = await _envios.GetEnvios();
            return Ok(response);
        }

        [HttpPost("PostEnvios")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostEnvios([FromBody] Envios envios)
        {
            try
            {
                var response = await _envios.PostEnvios(envios);
                if (response == true)
                    return Ok("El envio a sido agregado correctamente");
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
