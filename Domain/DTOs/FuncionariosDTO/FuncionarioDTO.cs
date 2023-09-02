using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs.FuncionariosDTO
{
    public class FuncionarioDTO
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
    }
}
