using Microsoft.AspNetCore.Mvc;
using Suivi_Colis_Back.DTOs;
using Suivi_Colis_Back.Services;

namespace Suivi_Colis_Back.Controllers
{
    //@https://learn.microsoft.com/fr-fr/aspnet/core/fundamentals/app-state?view=aspnetcore-7.0

    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto dto)
        {
            var user = _authService.Authenticate(dto.Email, dto.Password);
            if (user == null)
                return Unauthorized("Email ou mot de passe incorrect.");

            
            HttpContext.Session.SetString("UserId", user.Id.ToString());
            HttpContext.Session.SetString("Role", user.Role);

            return Ok(new { message = "Connexion réussie.", role = user.Role });
        }
        
        [HttpPost("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Ok(new { message = "Déconnexion réussie." });
        }
    }
}
