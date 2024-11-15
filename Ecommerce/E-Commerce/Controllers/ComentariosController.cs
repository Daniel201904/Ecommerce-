using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/controlller")]
    [ApiController]
    public class ComentariosController : ControllerBase
    {
        private readonly IComentarios _comentarios;
        public ComentariosController(IComentarios comentarios)
        {
            _comentarios = comentarios;
        }

        [HttpGet("GetComentarios")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetComentarios()
        {
            var response = await _comentarios.GetComentarios();
            return Ok(response);
        }

        [HttpPost("PostComentarios")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostComentarios([FromBody] Comentarios comentarios)
        {
            try
            {
                var response = await _comentarios.PostComentarios(comentarios);
                if (response == true)
                    return Ok("Comentario Agregado correctamente");
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
