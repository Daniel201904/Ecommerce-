using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/controlller")]
    [ApiController]
    public class RolController : Controller
    {
        private readonly IRol _rol;
        public RolController(IRol rol)
        {
            _rol = rol;
        }

        [HttpGet("GetRol")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetRol()
        {
            var response = await _rol.GetRol();
            return Ok(response);
        }

        [HttpPost("PostRol")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostRol([FromBody] Rol rol)
        {
            try
            {
                var response = await _rol.PostRol(rol);
                if (response == true)
                    return Ok("Se ha agregado una Rol correctamente");
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
