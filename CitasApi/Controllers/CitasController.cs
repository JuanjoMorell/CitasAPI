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
        public IActionResult GetCita(long id)
        {
            Cita c = CService.FindById(id);

            if (c is not null)
            {
                return Ok(new MensajeDTO(200, Mapper.Map<CitaDTO>(c)));
            }

            return Ok(new MensajeDTO(404, "ERROR > No se ha encontrado la cita."));
        }

        // POST: api/Citas
        [HttpPost]
        public IActionResult PostCita(CitaDTO citaDTO)
        {
            bool alm = CService.Save(Mapper.Map<Cita>(citaDTO));
            if (!alm) return Ok(new MensajeDTO(412, "ERROR > La cita ya existe."));
            else return Ok(new MensajeDTO(200, "Cita registrada con exito."));
        }

        // DELETE: api/Citas/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCita(long id)
        {
            CService.DeleteById(id);
            return Ok(new MensajeDTO(200, "Cita eliminado con exito."));
        }
    }
}
