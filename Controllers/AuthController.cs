using Microsoft.AspNetCore.Mvc;
using smart_alert_api.Models.Auth;
using smart_alert_api.Services.Auth;

namespace smart_alert_api.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest registerRequest)
        {
            var authResult = _authService.Register(
                registerRequest.email, 
                registerRequest.phone, 
                registerRequest.password);

            var response = new AuthResponse(authResult.email);

            return Ok(response);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest loginRequest)
        {
            var authResult = _authService.Login(
                loginRequest.email,
                loginRequest.password);

            var response = new AuthResponse(authResult.email);

            return Ok(response);
        }
    }
}
