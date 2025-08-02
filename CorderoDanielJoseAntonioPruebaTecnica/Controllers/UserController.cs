using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CorderoDanielJoseAntonioPruebaTecnica.Controllers
{
    [ApiController]
    [Route("api/v1/user")]
    public class UserController : ControllerBase
    {
        [Authorize]
        [HttpGet]
        public IActionResult Perfil()
        {
            var email = User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.Email)?.Value;
            return Ok(new { mensaje = "Ruta protegida accedida", usuario = email });
        }
    }
}
