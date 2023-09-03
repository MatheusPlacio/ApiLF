using AutoMapper;
using Domain.DTOs.FuncionariosDTO;
using Domain.DTOs.PacientesDTO;
using Domain.Interfaces.IService;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Services;

namespace ApiLF.Controllers
{
    [Route("api/funcionarios")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        private readonly IFuncionarioService _funcionarioService;
        private readonly IMapper _mapper;

        public FuncionariosController(IFuncionarioService funcionarioService, IMapper mapper)
        {
            _funcionarioService = funcionarioService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ObterTodosFuncionarios()
        {
            var funcionarios = _funcionarioService.ObterTodosFuncionarios();

            if (funcionarios == null)
                return NotFound("Nenhum funcionário encontrado");

            return Ok(funcionarios);
        }

        [HttpGet("BuscarFuncionarioId/{id}")]
        public IActionResult ObterFuncionarioPorId(int id)
        {
            var funcionario = _funcionarioService.ObterFuncionarioPorId(id);
            if (funcionario == null)
            {
                return NotFound();
            }
            return Ok(funcionario);
        }

        [HttpPost("CriarFuncionario")]
        public IActionResult CriarFuncionario(FuncionarioDTO funcionarioDTO)
        {
            try
            {
                _funcionarioService.CriarFuncionario(_mapper.Map<Funcionario>(funcionarioDTO));
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return CreatedAtAction(nameof(CriarFuncionario), new { id = funcionarioDTO.FuncionarioId }, null);
        }

        [HttpPut("AtualizarFuncionario")]
        public async Task<IActionResult> AtualizarFuncionario(FuncionarioDTO funcionarioDTO)
        {
            try
            {
                var result = _funcionarioService.AtualizarFuncionario(funcionarioDTO);
                if (!result)
                    return BadRequest("Paciente não encontrado");

                return Ok(funcionarioDTO);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpDelete("DeletarFuncionario/{id}")]
        public IActionResult DeletarPaciente(int id)
        {
            try
            {
                var result = _funcionarioService.DeletarFuncionario(id);
                if (!result)
                    return NotFound("Paciente não encontrado");

                return Ok("Paciente excluído com sucesso");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

