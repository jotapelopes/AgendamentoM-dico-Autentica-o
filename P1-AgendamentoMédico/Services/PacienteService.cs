using P1_AgendamentoMédico.Models;
using P1_AgendamentoMédico.Repositories;

namespace P1_AgendamentoMédico.Services
{
    public class PacienteService
    {

        private readonly PacienteRepository _pacienteRepository;

        public PacienteService(PacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }

        public async Task<Paciente> ObterPacientePorId(string pacienteId)
        {
            Paciente? paciente = await _pacienteRepository.ObterPacientePorId(pacienteId);

            if (paciente == null)
            {
                throw new Exception("Paciente não encontrado");
            }

            return paciente;
        }
    }
}
