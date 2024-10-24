namespace P1_AgendamentoMédico.Models
{
    public class Agendamento
    {
        public string Id { get; set; }
        public Medico Medico { get; set; }
        public Paciente Paciente { get; set; }
        public DateTime Data { get; set; }

        public Agendamento(Medico medico, Paciente paciente, DateTime data)
        {
            Medico = medico;
            Paciente = paciente;
            Data = data;
        }

        private Agendamento() { }
    }
}
