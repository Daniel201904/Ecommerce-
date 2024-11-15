using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using E_Commerce.Repositories.Interfaces;
using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;

namespace E_Commerce.Controllers
{
    [Route("api/controlller")]
    [ApiController]

    public class AuditoriasControler : ControllerBase
    {
        private readonly IAuditorias _auditorias;
        public AuditoriasControler(IAuditorias auditorias)
        {
            _auditorias = auditorias;
        }

        [HttpGet("GetAuditorias")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetAuditorias()
        {
            var response = await _auditorias.GetAuditorias();
            return Ok(response);
        }

        [HttpPost("PostAuditorias")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostAuditorias([FromBody] Auditorias auditorias)
        {
            try
            {
                var response = await _auditorias.PostAuditorias(auditorias);
                if (response == true)
                    return Ok("Insertado correctamente");
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

