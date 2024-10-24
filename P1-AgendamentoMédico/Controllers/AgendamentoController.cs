using Microsoft.AspNetCore.Mvc;
using P1_AgendamentoMédico.DTOs;
using P1_AgendamentoMédico.Models;
using P1_AgendamentoMédico.Services;

namespace P1_AgendamentoMédico.Controllers
{
    [Route("api/medicos")]
    [ApiController]
    public class AgendamentoController : ControllerBase
    {
        private readonly AgendamentoService _agendamentoService;

        public AgendamentoController(AgendamentoService agendamentoService)
        {
            _agendamentoService = agendamentoService;
        }


        [HttpPost("{medicoId}/agendamentos")]
        public async Task<ActionResult<Agendamento>> CriarAgendamento(string medicoId, CriarAgendamentoDTO agendamentoDTO)
        {
            Agendamento agendamento = await _agendamentoService.CriarAgendamento(medicoId, agendamentoDTO.PacienteId, agendamentoDTO.DataConsulta);

            return CreatedAtAction(nameof(CriarAgendamento), new { id = agendamento.Id }, agendamento);
        }
    }
}
