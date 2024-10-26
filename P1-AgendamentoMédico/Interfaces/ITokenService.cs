using P1_AgendamentoMédico.Models;

namespace P1_AgendamentoMédico.Interfaces
{
    public interface ITokenService
    {

        public string CreateCustomerToken(Paciente paciente);
    }
}
