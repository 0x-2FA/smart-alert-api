using Microsoft.AspNetCore.Mvc;
using smart_alert_api.Interfaces;
using smart_alert_api.Models.Auth;
using smart_alert_api.Services.Auth;

namespace smart_alert_api.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUserRepository _userRepository;

        public AuthController(IAuthService authService, IUserRepository userRepository)
        {
            _authService = authService;
            _userRepository = userRepository;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest registerRequest)
        {
            if (_userRepository.FindUserByEmail(registerRequest.email) != null)
            {
                return BadRequest();
            }

            var authResult = _authService.Register(
                registerRequest.email, 
                registerRequest.phone, 
                registerRequest.password);

            var response = new AuthResponse(authResult.user.Email);

            return Ok(response);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest loginRequest)
        {
 
            if (_userRepository.FindUserByEmail(loginRequest.email) == null)
            {
                return BadRequest();
            }

            if (!_userRepository.IsPasswordValid(loginRequest.email, loginRequest.password))
            {
                return BadRequest();
            }

            var authResult = _authService.Login(
                loginRequest.email,
                loginRequest.password);

            var response = new AuthResponse(authResult.user.Email);

            return Ok(response);
        }
    }
}
