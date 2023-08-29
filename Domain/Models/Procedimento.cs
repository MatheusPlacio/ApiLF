using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Procedimento
    {
        public int ProcedimentoId { get; set; }

        //===========================================================================================================================//
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string NomeProcedimento { get; set; }

        //===========================================================================================================================//
        //EF
        public List<ProcedimentoAgendamento> ProcedimentoAgendamentos { get; set; }
    }
}
