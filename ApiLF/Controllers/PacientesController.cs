using AutoMapper;
using Domain.DTOs.PacientesDTO;
using Domain.Interfaces.IService;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Services;

namespace ApiLF.Controllers
{
    [Route("api/pacientes")]
    [ApiController]
    public class PacientesController : ControllerBase
    {
        private readonly IPacienteService _pacienteService;
        private readonly IMapper _mapper;

        public PacientesController(IPacienteService pacienteService, IMapper mapper)
        {
            _pacienteService = pacienteService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ObterTodosPacientes()
        {
            var pacientes =  _pacienteService.ObterTodosPacientes();

            if (pacientes == null)
                return NotFound("Nenhum paciente encontrado");

            return Ok(pacientes);
        }

        [HttpGet("{id}")]
        public IActionResult ObterPacientePorId(int id)
        {
            var paciente =  _pacienteService.ObterPacientePorId(id);
            if (paciente == null)
            {
                return NotFound();
            }
            return Ok(paciente);
        }

        [HttpGet("PacientesEnderecos")]
        public IActionResult ObterTodosPacientesEnderecos()
        {
            var enderecos = _pacienteService.GetTodosPacientesEnderecos();
            return Ok(enderecos);
        }

        [HttpPost]
        public IActionResult CriarPaciente(PacienteRegisterDTO pacienteDTO)
        {
            try
            {
               _pacienteService.CriarPaciente(_mapper.Map<Paciente>(pacienteDTO));
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return CreatedAtAction(nameof(CriarPaciente), new { id = pacienteDTO.PacienteId }, null);
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarPaciente(PacienteUpdateDTO pacienteDTO)
        {
            try
            {
                var result = _pacienteService.AtualizarPaciente(pacienteDTO);
                if (!result)
                    return BadRequest("Paciente não encontrado");

                return Ok(pacienteDTO);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarPaciente(int id)
        {
            try
            {
                var result = _pacienteService.DeletarPaciente(id);
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
