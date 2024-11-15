using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/controlller")]
    [ApiController]
    public class TokensController : ControllerBase
    {
        private readonly ITokens _tokens;
        public TokensController(ITokens tikectsSoporte)
        {
            _tokens = tikectsSoporte;
        }

        [HttpGet("GetTokens")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetTokens()
        {
            var response = await _tokens.GetTokens();
            return Ok(response);
        }

        [HttpPost("PostTokens")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostTokens([FromBody] Tokens tokens)
        {
            try
            {
                var response = await _tokens.PostTokens(tokens);
                if (response == true)
                    return Ok("Se ha agregado un token correctamente");
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
