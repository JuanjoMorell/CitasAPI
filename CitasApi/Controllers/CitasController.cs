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
    public class CitasController : ControllerBase
    {
        private ICitaService CService;
        private IMapper Mapper;

        public CitasController(ICitaService service, IMapper mapper)
        {
            CService = service;
            Mapper = mapper;
        }

        // GET: api/Citas
        [HttpGet]
        public IActionResult GetCitas()
        {
            IList<CitaDTO> citasDTO = new List<CitaDTO>();
            foreach(Cita c in CService.FindAll())
            {
                citasDTO.Add(Mapper.Map<CitaDTO>(c));
            }
            return Ok(new MensajeDTO(200, citasDTO));
        }

        // GET: api/Citas/5
        [HttpGet("{id}")]
        public IActionResult GetCitaById(long id)
        {
            Cita c = CService.FindById(id);

            if (c is not null)
            {
                return Ok(new MensajeDTO(200, Mapper.Map<CitaDTO>(c)));
            }

            return Ok(new MensajeDTO(404, "ERROR > No se ha encontrado la cita."));
        }

        // GET: api/Citas/5
        [HttpGet("medico/{id}")]
        public IActionResult GetCitaByMedico(long id)
        {
            IList<CitaDTO> citasDTO = new List<CitaDTO>();
            foreach (Cita c in CService.FindByMedico(id))
            {
                citasDTO.Add(Mapper.Map<CitaDTO>(c));
            }

            return Ok(new MensajeDTO(200, citasDTO));
        }

        // GET: api/Citas/5
        [HttpGet("paciente/{id}")]
        public IActionResult GetCitaByPaciente(long id)
        {
            IList<CitaDTO> citasDTO = new List<CitaDTO>();
            foreach (Cita c in CService.FindByPaciente(id))
            {
                citasDTO.Add(Mapper.Map<CitaDTO>(c));
            }

            return Ok(new MensajeDTO(200, citasDTO));
        }

        // GET: api/Citas/5
        [HttpGet("diagnostico/{id}")]
        public IActionResult GetDiagnosticoByCita(long id)
        {
            Cita c = CService.FindById(id);

            if (c is not null)
            {
                if (c.Diagnostico is null) return Ok(new MensajeDTO(200, "La cita no dispone de diagnostico."));
                return Ok(new MensajeDTO(200, Mapper.Map<DiagnosticoDTO>(c.Diagnostico)));
            }

            return Ok(new MensajeDTO(404, "ERROR > No se ha encontrado la cita."));
        }

        // POST: api/Citas
        [HttpPost]
        public IActionResult PostCita(CitaDTO citaDTO)
        {
            bool alm = CService.Save(Mapper.Map<Cita>(citaDTO), citaDTO.Paciente, citaDTO.Medico);
            if (!alm) return Ok(new MensajeDTO(412, "ERROR > La cita ya existe o el medico no tiene asociado al paciente."));
            else return Ok(new MensajeDTO(200, "Cita registrada con exito."));
        }

        // DELETE: api/Citas/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCita(long id)
        {
            CService.DeleteById(id);
            return Ok(new MensajeDTO(200, "Cita eliminado con exito."));
        }

        [HttpPut]
        public IActionResult AddDiagnostico(long citaID, DiagnosticoDTO diagDTO)
        {
            bool alm = CService.AddDiagnostico(citaID, Mapper.Map<Diagnostico>(diagDTO));
            if (!alm) return Ok(new MensajeDTO(412, "ERROR > La cita ya dispone de diagnostico o no existe."));
            else return Ok(new MensajeDTO(200, "Diagnostico registrado con exito."));
        }
    }
}
