using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/controlller")]
    [ApiController]
    public class NotificacionesController : Controller
    {
        private readonly INotificaciones _notificaciones;
        public NotificacionesController(INotificaciones notificaciones)
        {
            _notificaciones = notificaciones;
        }

        [HttpGet("GetNotificaciones")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetNotificaciones()
        {
            var response = await _notificaciones.GetNotificaciones();
            return Ok(response);
        }

        [HttpPost("PostNotificaciones")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostNotificaciones([FromBody] Notificaciones notificaciones)
        {
            try
            {
                var response = await _notificaciones.PostNotificaciones(notificaciones);
                if (response == true)
                    return Ok("Se ha agregado una notifiacacion correctamente");
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
