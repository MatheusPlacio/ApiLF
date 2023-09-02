using Domain.DTOs.AgendamentosDTO;
using Domain.Models;

namespace Domain.Interfaces.IService
{
    public interface IAgendamentoService
    {
        IList<AgendamentoDTO> ObterAgendamentos();
        IList<AgendamentoFuncionProcedimentosDTO> ObterTodosAgendamentosFuncionariosProcedimentos();
        Agendamento CriarAgendamento(AgendamentoFuncionProcedimentosRegisterDTO agendamentoDTO);
    }
}
