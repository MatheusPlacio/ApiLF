using Domain.Interfaces.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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


    }
}
