using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/controlller")]
    [ApiController]
    public class RolesPermisosController : Controller
    {
        private readonly IRolesPermisos _rolesPermisos;
        public RolesPermisosController(IRolesPermisos rolesPermisos)
        {
            _rolesPermisos = rolesPermisos;
        }

        [HttpGet("GetRolesPermisos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetRolesPermisos()
        {
            var response = await _rolesPermisos.GetRolesPermisos();
            return Ok(response);
        }

        [HttpPost("PostRolesPermisos")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostRolesPermisos([FromBody] RolesPermisos rolesPermisos)
        {
            try
            {
                var response = await _rolesPermisos.PostRolesPermisos(rolesPermisos);
                if (response == true)
                    return Ok("Se ha agregado una RolPermiso correctamente");
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
