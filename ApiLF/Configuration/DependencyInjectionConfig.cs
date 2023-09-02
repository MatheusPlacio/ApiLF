using Data.Repository;
using Domain.Interfaces.IRepository;
using Domain.Interfaces.IService;
using Service.Services;

namespace ApiLF.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IAgendamentoRepository, AgendamentoRepository>();
            services.AddScoped<IPacienteRepository, PacienteRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
            services.AddScoped<IProcedimentoRepository, ProcedimentoRepository>();
            services.AddScoped<IProcedimentoAgendamentosRepository, ProcedimentoAgendamentosRepository>();
            services.AddScoped<IAgendamentosPacientesRepository, AgendamentosPacientesRepository>();

            services.AddScoped<IAgendamentoService, AgendamentoService>();
            services.AddScoped<IPacienteService, PacienteService>();
            services.AddScoped<IEnderecoService, EnderecoService>();
            services.AddScoped<IFuncionarioService, FuncionarioService>();
            services.AddScoped<IProcedimentoService, ProcedimentoService>();
        }
    }
}
