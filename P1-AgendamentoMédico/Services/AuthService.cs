using static P1_AgendamentoMédico.Services.AuthService;
using System.Security.Claims;
using P1_AgendamentoMédico.Models;

namespace P1_AgendamentoMédico.Services
{
    public class AuthService : IAuthService
    {

        private readonly IAuthRepository _authRepository;
        private readonly ITokenService _tokenService;

        public AuthService(IAuthRepository authRepository, ITokenService tokenService)
        {
            _authRepository = authRepository;
            _tokenService = tokenService;
        }

        public string? GetAuthenticatedUserId(ClaimsPrincipal User)
        {
            return User.FindFirst("id")?.Value;
        }

        public async Task<string> SignIn(string email, string password)
        {
            Paciente? paciente = await _authRepository.GetCustomerByEmailAndPassword(email, password);
            if (paciente == null)
            {
                throw new Exception("Usuário e/ou senha inválidos");
            }

            string token = _tokenService.CreateCustomerToken(paciente);

            return token;
        }
    }
}
