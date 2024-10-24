using Microsoft.EntityFrameworkCore;
using P1_AgendamentoMédico.Models;

namespace P1_AgendamentoMédico.Repositories
{
    public class PacienteRepository
    {
        private readonly AgendamentoMedicoDbContext _context;

        public PacienteRepository(AgendamentoMedicoDbContext context)
        {
            _context = context;
        }

        public async Task<Paciente> ObterPacientePorId(string pacienteId)
        {
            return await _context.Pacientes.FirstOrDefaultAsync(p => p.Id == pacienteId);
        }
    }
}
