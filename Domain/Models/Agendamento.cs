using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Agendamento
    {
        public int AgendamentoId { get; set; }
        //===========================================================================================================================//

        public DateTime DataHoraMarcada { get; set; }

        //===========================================================================================================================//

        [StringLength(10, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        public int Sessoes { get; set; }
        //===========================================================================================================================//


        [StringLength(10, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        public string Observacao { get; set; }
        //===========================================================================================================================//

        //EF
        public Funcionario Funcionario { get; set; }
        public int FuncionarioId { get; set; }


        public List<ProcedimentoAgendamento> ProcedimentoAgendamentos { get; set; }
    }
}
