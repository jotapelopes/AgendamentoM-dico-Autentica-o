using Microsoft.EntityFrameworkCore;
using P1_AgendamentoMédico.Interfaces;
using P1_AgendamentoMédico.Models;

namespace P1_AgendamentoMédico.Repositories
{
    public class AuthRepository : IAuthRepository
    {
  
            private readonly AgendamentoMedicoDbContext _context;

            public AuthRepository(AgendamentoMedicoDbContext context)
            {
                _context = context;
            }

            public async Task<Paciente?> GetCustomerByEmailAndPassword(string email, string password)
            {
                return await _context.Pacientes.FirstOrDefaultAsync(c => c.Email == email && c.Password == password);
            }
        }
    }

