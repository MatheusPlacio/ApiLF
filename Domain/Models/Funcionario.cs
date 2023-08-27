using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Funcionario
    {
        public int FuncionarioId { get; set; }

        //===========================================================================================================================//

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }

        //===========================================================================================================================//

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string SobreNome { get; set; }

        //===========================================================================================================================//

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Idade { get; set; }

        //===========================================================================================================================//

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Especialidade { get; set; }

        //===========================================================================================================================//

        //EF
        public List<Agendamento> Agendamentos { get; set; }
    }
}
