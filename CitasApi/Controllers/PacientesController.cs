using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CitasApi.Data;
using CitasApi.Models;
using CitasApi.DTO;
using CitasApi.Services;
using AutoMapper;

namespace CitasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacientesController : ControllerBase
    {
        private IPacienteService PService;
        private IMapper Mapper;

        public PacientesController(IPacienteService service, IMapper mapper)
        {
            PService = service;
            Mapper = mapper;
        }

        // GET: api/Pacientes
        [HttpGet]
        public IActionResult GetPacientes()
        {
            IList<PacienteDTO> pacientesDTO = new List<PacienteDTO>();
            foreach(Paciente p in PService.FindAll())
            {
                pacientesDTO.Add(Mapper.Map<PacienteDTO>(p));
            }
            return Ok(new MensajeDTO(200,pacientesDTO));
        }

        // GET: api/Pacientes/5
        [HttpGet("{id}")]
        public IActionResult GetPaciente(long id)
        {
            Paciente p = PService.FindById(id);

            if (p is not null)
            {
                return Ok(new MensajeDTO(200,Mapper.Map<PacienteDTO>(p)));
            }

            return Ok(new MensajeDTO(404, "ERROR > No se ha encontrado al paciente."));
        }

        // POST: api/Pacientes
        [HttpPost]
        public IActionResult PostPaciente(PacienteDTO pacienteDTO)
        {
            bool alm = PService.Save(Mapper.Map<Paciente>(pacienteDTO));
            if (!alm) return Ok(new MensajeDTO(412, "ERROR > El paciente ya existe."));
            else return Ok(new MensajeDTO(200, "Paciente registrado con exito."));
        }

        // DELETE: api/Pacientes/5
        [HttpDelete("{id}")]
        public IActionResult DeletePaciente(long id)
        {
            PService.DeleteById(id);
            return Ok(new MensajeDTO(200, "Paciente eliminado con exito."));
        }

        [HttpPut]
        public IActionResult AddMedico(PacienteMedicoDTO pmDTO)
        {
            bool alm = PService.AddMedico(pmDTO.PacienteID, pmDTO.MedicoID);
            if (alm) return Ok(new MensajeDTO(200, "Medico registrado con exito."));
            else return Ok(new MensajeDTO(402, "Medico o Paciente ya existe."));
        }

    }
}
