using Data.Context;
using Domain.Interfaces.IRepository;
using Domain.Models;

namespace Data.Repository
{
    public class AgendamentosPacientesRepository : Repository<AgendamentosPacientes>, IAgendamentosPacientesRepository
    {
        private readonly MyContext _context;
        public AgendamentosPacientesRepository(MyContext context) : base(context)
        {
            _context = context;
        }
    }
}
