using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/controlller")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {

        private readonly ICategoria _categoria;
        public CategoriasController(ICategoria categoria)
        {
            _categoria = categoria;
        }

        [HttpGet("GetCategorias")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetCategoria()
        {
            var response = await _categoria.GetCategoria();
            return Ok(response);
        }

        [HttpPost("PosCategorias")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostCategoria([FromBody] Categoria categoria)
        {
            try
            {
                var response = await _categoria.PostCategoria(categoria);
                if (response == true)
                    return Ok("Categoria Insertada correctamente");
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
