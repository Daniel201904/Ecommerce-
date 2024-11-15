using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/controlller")]
    [ApiController]
    public class PermisoController : ControllerBase
    {
        private readonly IPermiso _permiso;
        public PermisoController(IPermiso permiso)
        {
            _permiso = permiso;
        }

        [HttpGet("GetPermiso")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetPermiso()
        {
            var response = await _permiso.GetPermiso();
            return Ok(response);
        }

        [HttpPost("PostPermiso")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostPermiso([FromBody] Permiso permiso)
        {
            try
            {
                var response = await _permiso.PostPermiso(permiso);
                if (response == true)
                    return Ok("Se ha agregado un permiso correctamente");
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
