using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/controlller")]
    [ApiController]
    public class LogsSistemaController : Controller
    {
        private readonly ILogsSistema _logsSistema;
        public LogsSistemaController(ILogsSistema logsSistema)
        {
            _logsSistema = logsSistema;
        }

        [HttpGet("GetLogsSistema")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetLogsSistema()
        {
            var response = await _logsSistema.GetLogsSistema();
            return Ok(response);
        }

        [HttpPost("PostLogsSistema")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostLogsSistema([FromBody] LogsSistema logsSistema)
        {
            try
            {
                var response = await _logsSistema.PostLogsSistema(logsSistema);
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
