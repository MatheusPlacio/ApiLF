using Domain.DTOs.PacientesDTO;
using Domain.Models;

namespace Domain.Interfaces.IService
{
    public interface IPacienteService
    {
        IList<PacienteDTO> ObterTodosPacientes();
        PacienteDTO? ObterPacientePorId(int id);
        void CriarPaciente(Paciente paciente);
        bool AtualizarPaciente(PacienteUpdateDTO pacienteDTO);
        bool DeletarPaciente(int pacienteId);
        IList<PacienteEnderecoDTO> GetTodosPacientesEnderecos();
    }
}
