using System.Security.Claims;

namespace P1_AgendamentoMédico.Interfaces
{
    public interface IAuthService
    {
        public Task<string> SignIn(string email, string password);

        public string? GetAuthenticatedUserId(ClaimsPrincipal Paciente);

    }
}
