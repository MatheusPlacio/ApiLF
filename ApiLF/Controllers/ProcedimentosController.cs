using Domain.Interfaces.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Services;

namespace ApiLF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcedimentosController : ControllerBase
    {
        private readonly IProcedimentoService _procedimentoService;

        public ProcedimentosController(IProcedimentoService procedimentoService)
        {
            _procedimentoService = procedimentoService;
        }

        [HttpGet]
        public IActionResult ObterTodosProcedimentos()
        {
            var procedimentos = _procedimentoService.ObterTodosProcedimentos();

            if (procedimentos == null)
                return NotFound("Nenhum paciente encontrado");

            return Ok(procedimentos);
        }

        [HttpGet("ProcedimentosAgendamentos")]
        public IActionResult ObterTodosProcedimentosAgendamentos()
        {
            var procedimentos = _procedimentoService.ObterTodosProcedimentosAgendamentos();

            if (procedimentos == null)
                return NotFound("Nenhum paciente encontrado");

            return Ok(procedimentos);
        }
    }
}
