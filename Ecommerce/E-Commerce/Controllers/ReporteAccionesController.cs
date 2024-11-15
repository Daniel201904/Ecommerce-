using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/controlller")]
    [ApiController]
    public class ReporteAccionesController : Controller
    {
        private readonly IReporteAcciones _reporteAcciones;
        public ReporteAccionesController(IReporteAcciones reporteAcciones)
        {
            _reporteAcciones = reporteAcciones;
        }

        [HttpGet("GetReporteAcciones")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetReporteAcciones()
        {
            var response = await _reporteAcciones.GetReporteAcciones();
            return Ok(response);
        }

        [HttpPost("PostReporteAcciones")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostReporteAcciones([FromBody] ReporteAcciones reporteAcciones)
        {
            try
            {
                var response = await _reporteAcciones.PostReporteAcciones(reporteAcciones);
                if (response == true)
                    return Ok("Se ha agregado el reporte de una accion correctamente");
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
