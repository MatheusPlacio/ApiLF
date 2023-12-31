﻿using AutoMapper;
using Domain.DTOs.FuncionariosDTO;
using Domain.DTOs.PacientesDTO;
using Domain.Models;

namespace ApiLF.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<PacienteRegisterDTO, Paciente>().ReverseMap();
            CreateMap<PacienteUpdateDTO, Paciente>().ReverseMap();
            CreateMap<PacienteDTO, Paciente>().ReverseMap();


            CreateMap<FuncionarioDTO, Funcionario>().ReverseMap();
        }
    }
}
