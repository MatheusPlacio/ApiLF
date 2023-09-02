using Data.Context;
using Domain.Interfaces.IRepository;
using Domain.Models;

namespace Data.Repository
{
    public class ProcedimentoAgendamentosRepository : Repository<ProcedimentoAgendamento>, IProcedimentoAgendamentosRepository
    {
        private readonly MyContext _context;
        public ProcedimentoAgendamentosRepository(MyContext context) : base(context)
        {
            _context = context;
        }
    }
}
