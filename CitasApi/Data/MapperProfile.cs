using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Threading.Tasks;
using CitasApi.Models;
using CitasApi.DTO;
using CitasApi.Services;
using AutoMapper;

namespace CitasApi.Data
{
    public class MapperProfile : Profile
    {

        public MapperProfile()
        {
            // Map Usuario -> UsuarioDTO
            CreateMap<Usuario, UsuarioDTO>();

            // Map Paciente -> PacienteDTO
            CreateMap<Paciente, PacienteDTO>()
                .ForMember(dto => dto.Medicos, o => o.MapFrom(pac => pac.Medicos.Select(m => m.Id).ToList()))
                .ForMember(dto => dto.Username, o => o.MapFrom(pac => pac.Username));

            // Map Medico -> MedicoDTO
            CreateMap<Medico, MedicoDTO>()
                .ForMember(dto => dto.Pacientes, o => o.MapFrom(med => med.Pacientes.Select(p => p.Id).ToList()))
                .ForMember(dto => dto.Username, o => o.MapFrom(med => med.Username));

            // Map Diagnostico -> DiagnosticoDTO
            CreateMap<Diagnostico, DiagnosticoDTO>();

            // Map Cita -> CitaDTO
            CreateMap<Cita, CitaDTO>()
                .ForMember(dto => dto.FechaHora, o => o.MapFrom(cita => cita.FechaHora))
                .ForMember(dto => dto.Medico, o => o.MapFrom(cita => cita.Medico.Id))
                .ForMember(dto => dto.Paciente, o => o.MapFrom(cita => cita.Paciente.Id))
                .ForMember(dto => dto.Diagnostico, o => o.MapFrom(cita => cita.Diagnostico.Id));

            // Map UsuarioDTO -> Usuario
            CreateMap<UsuarioDTO, Usuario>();

            // Map PacienteDTO -> Paciente
            CreateMap<PacienteDTO, Paciente>()
                .ForMember(p => p.Medicos, o => o.MapFrom(dto => new List<Medico>()))
                .ForMember(p => p.Username, o => o.MapFrom(dto => dto.Username));

            // Map MedicoDTO -> Medico
            CreateMap<MedicoDTO, Medico>()
                .ForMember(m => m.Pacientes, o => o.MapFrom(dto => new List<Paciente>()))
                .ForMember(m => m.Username, o => o.MapFrom(dto => dto.Username));

            // Map DiagnosticoDTO -> Diagnostico
            CreateMap<DiagnosticoDTO, Diagnostico>();

            // Map CitaDTO -> Cita
            CreateMap<CitaDTO, Cita>()
                .ForMember(cita => cita.FechaHora, o => o.MapFrom(dto => dto.FechaHora))
                .ForMember(cita => cita.Medico, o => o.Ignore())
                .ForMember(cita => cita.Paciente, o => o.Ignore())
                .ForMember(cita => cita.Diagnostico, o => o.Ignore());
        }

    }
}
