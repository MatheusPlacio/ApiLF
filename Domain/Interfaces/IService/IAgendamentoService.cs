using Domain.DTOs.AgendamentosDTO;
using Domain.Models;

namespace Domain.Interfaces.IService
{
    public interface IAgendamentoService
    {
        IList<AgendamentoFuncionProcedimentosDTO> ObterTodosAgendamentosFuncionariosProcedimentos();
        AgendamentoFuncionProcedimentosDTO? ObterTodosAgendamentosFuncionariosProcedimentosPorId(int id);
        Agendamento CriarAgendamento(AgendamentoFuncionProcedimentosRegisterDTO agendamentoDTO);
        bool DeletarAgendamento(int id);
    }
}
