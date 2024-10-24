using P1_AgendamentoMédico.Models;

namespace P1_AgendamentoMédico.Repositories
{
    public class AgendamentoRepository
    {
        private readonly AgendamentoMedicoDbContext _context;

        public AgendamentoRepository(AgendamentoMedicoDbContext context)
        {
            _context = context;
        }

        public async Task<Agendamento> SalvarAgendamento(Agendamento agendamento)
        {
            _context.agendamentos.Add(agendamento);
            await _context.SaveChangesAsync();

            return agendamento;
        }
    }
}
