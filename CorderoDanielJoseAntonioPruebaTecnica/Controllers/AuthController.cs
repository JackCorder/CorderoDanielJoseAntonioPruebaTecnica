using CorderoDanielJoseAntonioPruebaTecnica.Models;
using CorderoDanielJoseAntonioPruebaTecnica.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text;

namespace CorderoDanielJoseAntonioPruebaTecnica.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            try
            {
                var token = _authService.Authenticate(request.Email, request.Password);

                return Ok(new
                {
                    access_token = token,
                    token_type = "Bearer",
                    expires_in = 60 * 60
                });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { mensaje = ex.Message });
            }
        }
    }
}
