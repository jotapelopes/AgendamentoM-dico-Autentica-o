using P1_AgendamentoMédico.Models;
using P1_AgendamentoMédico.Repositories;

namespace P1_AgendamentoMédico.Services
{
    public class AgendamentoService
    {
        private readonly MedicoService _medicoService;
        private readonly PacienteService _pacienteService;
        private readonly AgendamentoRepository _agendamentoRepository;

        public AgendamentoService(MedicoService medicoService, PacienteService pacienteService, AgendamentoRepository agendamentoRepository)
        {
            _medicoService = medicoService;
            _pacienteService = pacienteService;
            _agendamentoRepository = agendamentoRepository;
        }

        public async Task<Agendamento> CriarAgendamento(string medicoId, string pacienteId, DateTime dataConsulta)
        {
            bool medicoEstaDisponivel = await _medicoService.MedicoEstaDisponivelNaData(medicoId, dataConsulta);
            if (!medicoEstaDisponivel)
            {
                throw new Exception("Médico não está disponível na data requerida");
            }

            Medico medico = await _medicoService.ObterMedicoPorId(medicoId);

            Paciente paciente = await _pacienteService.ObterPacientePorId(pacienteId);

            
            Agendamento agendamento = new Agendamento(medico, paciente, dataConsulta);
            agendamento = await _agendamentoRepository.SalvarAgendamento(agendamento);

            return agendamento;
        }
    }
}
