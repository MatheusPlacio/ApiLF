using Amazon.Lambda.Model;
using Domain.DTOs.AgendamentosDTO;
using Domain.Interfaces.IService;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using OpenQA.Selenium;
using Service.Services;
using System.ComponentModel.DataAnnotations;

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

        [HttpPatch("RemarcarAgendamento/{id}")]
        public IActionResult AtualizarAgendamento(int id, [FromBody] JsonPatchDocument<Agendamento> patchDocument)
        {
            try
            {
                bool sucesso = _agendamentoService.AtualizarAgendamento(id, patchDocument);

                if (!sucesso)
                {
                    return NotFound("Agendamento não encontrado.");
                }

                return Ok("Agendamento atualizado com sucesso.");
            }
            catch (ServiceException ex)
            {
                return StatusCode(500, $"Erro no servidor: {ex.Message}");
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

        private IActionResult HandleException(Exception ex)
        {
            if (ex is NotFoundException)
            {
                return NotFound(ex.Message);
            }
            else if (ex is ValidationException)
            {
                return BadRequest(ex.Message);
            }
            else
            {
                return StatusCode(500, $"Erro no servidor: {ex.Message}");
            }
        }

    }
}
