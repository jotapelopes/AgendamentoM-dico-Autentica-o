using P1_AgendamentoMédico.Models;
using P1_AgendamentoMédico.Repositories;

namespace P1_AgendamentoMédico.Services
{
    public class MedicoService
    {
        private readonly MedicoRepository _medicoRepository;

        public MedicoService(MedicoRepository medicoRepository)
        {
            _medicoRepository = medicoRepository;
        }


        public async Task<Medico> ObterMedicoPorId(string medicoId)
        {
            Medico? medico = await _medicoRepository.ObterMedicoPorId(medicoId);

            if (medico == null)
            {
                throw new Exception("Médico não encontrado");
            }

            return medico;
        }

        public async Task<bool> MedicoEstaDisponivelNaData(string medicoId, DateTime data)
        {
            return await _medicoRepository.MedicoEstaDisponivelNaData(medicoId, data);
        }
    }
}
