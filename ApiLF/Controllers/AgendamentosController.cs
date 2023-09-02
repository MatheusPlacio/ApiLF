using Domain.DTOs.AgendamentosDTO;
using Domain.Interfaces.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public IActionResult ObterTodosAgendamentos()
        {
            var agendamentos = _agendamentoService.ObterAgendamentos();

            if (agendamentos == null)
                return NotFound("Nenhum paciente encontrado");

            return Ok(agendamentos);
        }

        [HttpGet("AgendamentosFuncionariosProcedimentos")]
        public IActionResult ObterTodosAgendamentosFuncionariosProcedimentos()
        {
            var agendamentos = _agendamentoService.ObterTodosAgendamentosFuncionariosProcedimentos();

            if (agendamentos == null)
                return NotFound("Nenhum paciente encontrado");

            return Ok(agendamentos);
        }

        [HttpPost("criar")]
        public IActionResult CriarAgendamento([FromBody] AgendamentoFuncionProcedimentosRegisterDTO agendamentoDTO)
        {
            var novoAgendamento = _agendamentoService.CriarAgendamento(agendamentoDTO);

            if (novoAgendamento == null)
            {
                return BadRequest("Falha ao criar o agendamento.");
            }

            return CreatedAtAction(nameof(CriarAgendamento), new { id = novoAgendamento.AgendamentoId }, null);
        }
    }
}
