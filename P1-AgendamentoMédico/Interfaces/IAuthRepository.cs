using P1_AgendamentoMédico.Models;

namespace P1_AgendamentoMédico.Interfaces
{
    public interface IAuthRepository
    {
        public Task<Paciente?> GetCustomerByEmailAndPassword(string email, string password);

    }
}
