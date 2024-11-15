using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/controlller")]
    [ApiController]
    public class EmpresasEnvioController : Controller
    {
        private readonly IEmpresasEnvio _empresasEnvio;
        public EmpresasEnvioController(IEmpresasEnvio empresasEnvio)
        {
            _empresasEnvio = empresasEnvio;
        }

        [HttpGet("GetEmpresasEnvios")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetEmpresasEnvios()
        {
            var response = await _empresasEnvio.GetEmpresasEnvios();
            return Ok(response);
        }

        [HttpPost("PostEmpresasEnvios")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostEmpresasEnvios([FromBody]  EmpresasEnvio empresasEnvio)
        {
            try
            {
                var response = await _empresasEnvio.PostEmpresasEnvios(empresasEnvio);
                if (response == true)
                    return Ok("La Empresa del Envio fue agregada correctamente");
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
