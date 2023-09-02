using Data.Context;
using Domain.Interfaces.IRepository;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class AgendamentoRepository : Repository<Agendamento>, IAgendamentoRepository
    {
        private readonly MyContext _context;
        public AgendamentoRepository(MyContext context) : base(context)
        {
            _context = context;
        }

        public IList<ProcedimentoAgendamento> GetTodosAgendamentos()
        {
            var procedimentoAgendamento = _context.ProcedimentosAgendamentos.Include(x => x.Agendamento)
                                                                            .Include(x => x.Procedimento)
                                                                            .Include(x => x.Agendamento.ProcedimentoAgendamentos)
                                                                            .Include(x => x.Agendamento.AgendamentosPacientes)
                                                                            .Include(x => x.Agendamento.Funcionario)
                                                                            .Include(x => x.Agendamento.AgendamentosPacientes)
                                                                            .ThenInclude(x => x.Paciente)
                                                                            .ToList();

            return procedimentoAgendamento;
        }
    }
}
