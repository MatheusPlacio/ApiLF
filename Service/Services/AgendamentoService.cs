using Domain.DTOs.AgendamentosDTO;
using Domain.DTOs.FuncionariosDTO;
using Domain.DTOs.NewFolder;
using Domain.DTOs.PacientesDTO;
using Domain.DTOs.ProcedimentosDTO;
using Domain.Interfaces.IRepository;
using Domain.Interfaces.IService;
using Domain.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Serilog;
using Serilog.Core;

namespace Service.Services
{
    public class AgendamentoService : IAgendamentoService
    {
        private readonly IAgendamentoRepository _agendamentoRepository;
        private readonly IProcedimentoRepository _procedimentoRepository;
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly IProcedimentoAgendamentosRepository _procedimentoAgendamentosRepository;
        private readonly IAgendamentosPacientesRepository _agendamentosPacientesRepository;
        private readonly ILogger<AgendamentoService> _logger;

        public AgendamentoService(IAgendamentoRepository agendamentoRepository,
                                 IProcedimentoRepository procedimentoRepository,
                                 IPacienteRepository pacienteRepository,
                                 IFuncionarioRepository funcionarioRepository,
                                 IProcedimentoAgendamentosRepository procedimentoAgendamentosRepository,
                                 IAgendamentosPacientesRepository agendamentosPacientesRepository,
                                 ILogger<AgendamentoService> logger)
        {
            _agendamentoRepository = agendamentoRepository;
            _procedimentoRepository = procedimentoRepository;
            _pacienteRepository = pacienteRepository;
            _funcionarioRepository = funcionarioRepository;
            _procedimentoAgendamentosRepository = procedimentoAgendamentosRepository;
            _agendamentosPacientesRepository = agendamentosPacientesRepository;
            _logger = logger;
        }

        public IList<AgendamentoDTO> ObterAgendamentos()
        {
            IList<Agendamento> agendamentos = _agendamentoRepository.Get();
            IList<AgendamentoDTO> agendamentosDTO = agendamentos.Select(p => new AgendamentoDTO
            {
                AgendamentoId = p.AgendamentoId,
                DataHoraMarcada = p.DataHoraMarcada,
                Sessoes = p.Sessoes,
                Observacao = p.Observacao
            }).ToList();

            return agendamentosDTO;
        }

        public IList<AgendamentoFuncionProcedimentosDTO> ObterTodosAgendamentosFuncionariosProcedimentos()
        {
            IList<ProcedimentoAgendamento> procedimentoAgendamentos = _agendamentoRepository.GetTodosAgendamentos();
            var dataDeNascimento = procedimentoAgendamentos.FirstOrDefault()?.Agendamento.AgendamentosPacientes.FirstOrDefault()?.Paciente.DataDeNascimento;

            var agendamentoFuncionProcedimentosDTO = procedimentoAgendamentos.Select(p => new AgendamentoFuncionProcedimentosDTO
            {
                ProcedimentoAgendamento = new ProcedimentoAgendamentoDTO
                {
                    ProcedimentoAgendamentoId = p.ProcedimentoAgendamentoId,
                    ProcedimentoId = p.ProcedimentoId,
                    NomeProcedimento = p.Procedimento.NomeProcedimento,
                    AgendamentoId = p.AgendamentoId,
                    DataHoraMarcada = p.Agendamento.DataHoraMarcada,
                    Sessoes = p.Agendamento.Sessoes,
                    Observacao = p.Agendamento.Observacao,
                },
                Paciente = new PacienteDTO
                {
                    PacienteId = p.Agendamento.AgendamentosPacientes.FirstOrDefault()?.Paciente.PacienteId ?? 0,
                    Nome = p.Agendamento.AgendamentosPacientes.FirstOrDefault()?.Paciente.Nome ?? "Nome não informado",
                    SobreNome = p.Agendamento.AgendamentosPacientes.FirstOrDefault()?.Paciente.SobreNome ?? "SobreNome não informado",
                    DataDeNascimento = p.Agendamento.AgendamentosPacientes.FirstOrDefault()?.Paciente.DataDeNascimento.ToString("dd/MM/yyyy") ?? "Data de Nascimento não informada",
                    Genero = p.Agendamento.AgendamentosPacientes.FirstOrDefault()?.Paciente.Genero ?? "Genero não informado",
                    CPF = p.Agendamento.AgendamentosPacientes.FirstOrDefault()?.Paciente.CPF ?? "CPF não informado",
                    Celular = p.Agendamento.AgendamentosPacientes.FirstOrDefault()?.Paciente.Celular ?? "Celular não informado",
                    Email = p.Agendamento.AgendamentosPacientes.FirstOrDefault()?.Paciente.Email ?? "Email não informado",
                    Profissao = p.Agendamento.AgendamentosPacientes.FirstOrDefault()?.Paciente.Profissao ?? "Profissão não informado",
                },
                Funcionario = new FuncionarioDTO
                {
                    FuncionarioId = p.Agendamento.Funcionario.FuncionarioId,
                    Nome = p.Agendamento.Funcionario.Nome,
                    SobreNome = p.Agendamento.Funcionario.SobreNome,
                    Idade = p.Agendamento.Funcionario.Idade,
                    Especialidade = p.Agendamento.Funcionario.Especialidade
                },
            }).ToList();

            _logger.LogInformation($"Informações do agendamentoFuncionProcedimentosDTO: {JsonConvert.SerializeObject(agendamentoFuncionProcedimentosDTO)}");

            return agendamentoFuncionProcedimentosDTO;
        }

        public Agendamento CriarAgendamento(AgendamentoFuncionProcedimentosRegisterDTO agendamentoDTO)
        {
            // Verifique se o procedimento, paciente e funcionário existem no banco
            var procedimentoExistente = _procedimentoRepository.GetById(agendamentoDTO.ProcedimentoId);
            var pacienteExistente = _pacienteRepository.GetById(agendamentoDTO.PacienteId);
            var funcionarioExistente = _funcionarioRepository.GetById(agendamentoDTO.FuncionarioId);

            if (procedimentoExistente == null || pacienteExistente == null || funcionarioExistente == null)
                return null;

            var novoAgendamento = new Agendamento
            {
                DataHoraMarcada = agendamentoDTO.AgendamentoProcedimentoRegisterDTO.DataHoraMarcada,
                Sessoes = agendamentoDTO.AgendamentoProcedimentoRegisterDTO.Sessoes,
                Observacao = agendamentoDTO.AgendamentoProcedimentoRegisterDTO.Observacao,
                Funcionario = funcionarioExistente,
            };

            var novoAgendamentosPacientes = new AgendamentosPacientes
            {
                Paciente = pacienteExistente,
                Agendamento = novoAgendamento,
                DataHoraMarcada = agendamentoDTO.AgendamentoProcedimentoRegisterDTO.DataHoraMarcada,
            };

            var novoProcedimentosAgendamentos = new ProcedimentoAgendamento
            {
                Procedimento = procedimentoExistente,
                Agendamento = novoAgendamento,
                DataHoraMarcada = agendamentoDTO.AgendamentoProcedimentoRegisterDTO.DataHoraMarcada,
            };

            _agendamentoRepository.Add(novoAgendamento);
            _agendamentosPacientesRepository.Add(novoAgendamentosPacientes);
            _procedimentoAgendamentosRepository.Add(novoProcedimentosAgendamentos);

            return novoAgendamento;
        }


    }
}
