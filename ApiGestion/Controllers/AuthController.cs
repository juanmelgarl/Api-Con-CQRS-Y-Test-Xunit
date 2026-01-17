using ApiGestion.DTOS.Request;
using ApiGestion.Repository;
using ApiGestion.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiGestion.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IauthService _authService;

        public AuthController(IauthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login(LoginDTO dto)
        {
            var token = _authService.Login(dto.EMAIL, dto.PASSWORD);
            return Ok(new { token });
        }
    }
}
