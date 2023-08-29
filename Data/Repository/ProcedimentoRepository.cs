using Data.Context;
using Domain.Interfaces.IRepository;
using Domain.Models;

namespace Data.Repository
{
    public class ProcedimentoRepository : Repository<Procedimento>, IProcedimentoRepository
    {
        public ProcedimentoRepository(MyContext context) : base(context)
        {
            
        }
    }
}
