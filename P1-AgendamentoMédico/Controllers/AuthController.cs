    using Microsoft.AspNetCore.Mvc;
using P1_AgendamentoMédico.DTOs;
using P1_AgendamentoMédico.Interfaces;

namespace P1_AgendamentoMédico.Controllers
   {
        [Route("api/[controller]")]
        [ApiController]
        public class AuthController : ControllerBase
        {
            private readonly IAuthService _authService;

            public AuthController(IAuthService authService)
            {
                _authService = authService;
            }

            [HttpPost("signIn")]
            public async Task<ActionResult<string>> SignIn(SignInDTO signInDTO)
            {
                string token = await _authService.SignIn(signInDTO.Email, signInDTO.Password);

                return CreatedAtAction(nameof(SignIn), token);
            }
        }
}
