using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/controlller")]
    [ApiController]
    public class TrackingEnvioController : ControllerBase
    {
        private readonly ITrackingEnvio _trackingEnvio;
        public TrackingEnvioController(ITrackingEnvio trackingEnvio)
        {
            _trackingEnvio = trackingEnvio;
        }

        [HttpGet("GetTrackingEnvio")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetTrackingEnvio()
        {
            var response = await _trackingEnvio.GetTrackingEnvio();
            return Ok(response);
        }

        [HttpPost("PostTrackingEnvio")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostTrackingEnvio([FromBody]  TrackingEnvio trackingEnvio)
        {
            try
            {
                var response = await _trackingEnvio.PostTrackingEnvio(trackingEnvio);
                if (response == true)
                    return Ok("Se ha agregado un Envio Tracking correctamente");
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
