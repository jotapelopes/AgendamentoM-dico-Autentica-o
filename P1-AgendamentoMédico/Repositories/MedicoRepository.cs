using Microsoft.EntityFrameworkCore;
using P1_AgendamentoMédico.Models;

namespace P1_AgendamentoMédico.Repositories
{
    public class MedicoRepository
    {
        private readonly AgendamentoMedicoDbContext _context;

        public MedicoRepository(AgendamentoMedicoDbContext context)
        {
            _context = context;
        }

        public async Task<Medico?> ObterMedicoPorId(string medicoId)
        {
            return await _context.Medicos.FirstOrDefaultAsync(m => m.Id == medicoId);
        }

        public async Task<bool> MedicoEstaDisponivelNaData(string medicoId, DateTime data)
        {
            return !await _context.agendamentos.AnyAsync(a => a.Medico.Id == medicoId && a.Data.Date == data.Date);
        }
    }
}
