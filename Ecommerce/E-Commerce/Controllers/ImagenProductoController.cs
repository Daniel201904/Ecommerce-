using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/controlller")]
    [ApiController]
    public class ImagenProductoController : Controller
    {
        private readonly IImagenProducto _imagenProducto;
        public ImagenProductoController(IImagenProducto imgaenProducto)
        {
            _imagenProducto = imgaenProducto;
        }

        [HttpGet("GetImagenProducto")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetImagenProducto()
        {
            var response = await _imagenProducto.GetImagenProducto();
            return Ok(response);
        }

        [HttpPost(" PostEstadisticasVentas")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostImagenProducto([FromBody] ImagenProducto imagenProducto)
        {
            try
            {
                var response = await _imagenProducto.PostImagenProducto(imagenProducto);
                if (response == true)
                    return Ok("La imagen del producto a sido agregada correctamente");
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
