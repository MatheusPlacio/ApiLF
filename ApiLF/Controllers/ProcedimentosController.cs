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
                return NotFound("Nenhum procedimento encontrado");

            return Ok(procedimentos);
        }

        [HttpGet("{id}")]
        public IActionResult ObterTodosProcedimentosAgendamentos(int id)
        {
            var procedimentos = _procedimentoService.ObterProcedimentosPorId(id);

            if (procedimentos == null)
                return NotFound("Nenhum procedimento encontrado");

            return Ok(procedimentos);
        }
    }
}
