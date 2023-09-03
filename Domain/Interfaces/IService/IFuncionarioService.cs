using Domain.DTOs.FuncionariosDTO;
using Domain.Models;

namespace Domain.Interfaces.IService
{
    public interface IFuncionarioService
    {
        IList<FuncionarioDTO> ObterTodosFuncionarios();
        FuncionarioDTO ObterFuncionarioPorId(int id);
        void CriarFuncionario(Funcionario funcionario);
        bool AtualizarFuncionario(FuncionarioDTO funcionarioDTO);
        bool DeletarFuncionario(int funcionarioId);

    }
}
