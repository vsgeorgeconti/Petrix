using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Petrix.Application.DTOs.Auth;
using Petrix.Application.UseCases.Auth;

namespace Petrix.Api.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : ControllerBase
    {

        private readonly RegisterUserUseCase _registerUserUseCase;
        private readonly LoginUseCase _loginUseCase;

        public AuthController(RegisterUserUseCase registerUserUseCase, LoginUseCase loginUseCase)
        {
            _registerUserUseCase = registerUserUseCase;
            _loginUseCase = loginUseCase;
        }

        [Authorize]
        [HttpGet("me")]
        public IActionResult Me()
        {
            var user = new
            {
                Id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value,
                Email = User.FindFirst(ClaimTypes.Email)?.Value,
                Name = User.FindFirst("name")?.Value
            };

            return Ok(user);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var result = await _registerUserUseCase.ExecuteAsync(request);

            if (result.Success == true)
                return Ok(result);

            if (result.Code == "EMAIL_EXISTS")
                return Conflict(result);

            return BadRequest(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var result = await _loginUseCase.LoginAsync(request);

            if (result.Success == true)
                return Ok(result);

            if (result.Code == "PASSWORD_INCORRECT")
                return Conflict(result);

            return BadRequest(result);
        }

    }
}