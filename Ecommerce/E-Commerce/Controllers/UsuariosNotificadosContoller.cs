using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/controlller")]
    [ApiController]
    public class UsuariosNotificadosContoller : Controller
    {
        private readonly IUsuariosNotificados _usuariosNotificados;
        public UsuariosNotificadosContoller(IUsuariosNotificados usuariosNotificados)
        {
            _usuariosNotificados = usuariosNotificados;
        }

        [HttpGet("GetUsuariosNotificados")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetUsuariosNotificados()
        {
            var response = await _usuariosNotificados.GetUsuariosNotificados();
            return Ok(response);
        }

        [HttpPost("PostUsuariosNotificados")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostUsuariosNotificados([FromBody] UsuariosNotificados usuariosNotificados)
        {
            try
            {
                var response = await _usuariosNotificados.PostUsuariosNotificados(usuariosNotificados);
                if (response == true)
                    return Ok("Se ha agregado a una Notificacion a los usuarios correctamente");
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
