using Domain.DTOs.AgendamentosDTO;
using Domain.Interfaces.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Services;

namespace ApiLF.Controllers
{
    [Route("api/agendamentos")]
    [ApiController]
    public class AgendamentosController : ControllerBase
    {
        private readonly IAgendamentoService _agendamentoService;
        public AgendamentosController(IAgendamentoService agendamentoService )
        {
            _agendamentoService = agendamentoService;
        }

        [HttpGet("Agendamentos")]
        public IActionResult ObterTodosAgendamentosFuncionariosProcedimentos()
        {
            var agendamentos = _agendamentoService.ObterTodosAgendamentosFuncionariosProcedimentos();

            if (agendamentos == null)
                return NotFound("Nenhum paciente encontrado");

            return Ok(agendamentos);
        }

        [HttpGet("AgendamentosById/{id}")]
        public IActionResult ObterTodosAgendamentosFuncionariosProcedimentosPorId(int id)
        {
            var agendamentos = _agendamentoService.ObterTodosAgendamentosFuncionariosProcedimentosPorId(id);

            if (agendamentos == null)
            {
                return NotFound("Nenhum agendamento encontrado para o ID especificado.");
            }

            return Ok(agendamentos);
        }

        [HttpPost("Criar")]
        public IActionResult CriarAgendamento([FromBody] AgendamentoFuncionProcedimentosRegisterDTO agendamentoDTO)
        {
            try
            {
                var novoAgendamento = _agendamentoService.CriarAgendamento(agendamentoDTO);

                if (novoAgendamento == null)
                    return BadRequest("Falha ao criar o agendamento.");

                return CreatedAtAction(nameof(CriarAgendamento), new { id = novoAgendamento.AgendamentoId }, null);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpDelete("RemoverAgendamento/{id}")]
        public IActionResult DeletarEndereco(int id)
        {
            var result = _agendamentoService.DeletarAgendamento(id);

            if (!result)
                return BadRequest("Agendamento não encontrado");

            return Ok("Agendamento excluído com sucesso");
        }

    }
}
