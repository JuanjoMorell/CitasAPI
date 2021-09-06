using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CitasApi.Data;
using CitasApi.Models;
using CitasApi.Services;
using AutoMapper;
using CitasApi.DTO;

namespace CitasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiagnosticosController : ControllerBase
    {
        private IDiagnosticoService DService;
        private IMapper Mapper;

        public DiagnosticosController(IDiagnosticoService service, IMapper mapper)
        {
            DService = service;
            Mapper = mapper;
        }

        // GET: api/Diagnosticos
        [HttpGet]
        public IActionResult GetDiagnosticos()
        {
            IList<DiagnosticoDTO> diagsDTO = new List<DiagnosticoDTO>();
            foreach(Diagnostico d in DService.FindAll())
            {
                diagsDTO.Add(Mapper.Map<DiagnosticoDTO>(d));
            }
            return Ok(new MensajeDTO(200, diagsDTO));
        }

        // GET: api/Diagnosticos/5
        [HttpGet("{id}")]
        public IActionResult GetDiagnostico(long id)
        {
            Diagnostico d = DService.FindById(id);
            if(d is not null)
            {
                return Ok(new MensajeDTO(200, Mapper.Map<DiagnosticoDTO>(d)));
            }
            return Ok(new MensajeDTO(404, "ERROR > No se ha encontrado el diagnostico."));
        }

        // POST: api/Diagnosticos
        [HttpPost]
        public IActionResult PostDiagnostico(DiagnosticoDTO diagnosticoDTO)
        {
            bool alm = DService.Save(Mapper.Map<Diagnostico>(diagnosticoDTO));
            if (!alm) return Ok(new MensajeDTO(412, "ERROR > El diagnostico ya existe."));
            else return Ok(new MensajeDTO(200, "Diagnostico registrado con exito."));
        }

        // DELETE: api/Diagnosticos/5
        [HttpDelete("{id}")]
        public IActionResult DeleteDiagnostico(long id)
        {
            DService.DeleteById(id);
            return Ok(new MensajeDTO(200, "Diagnostico eliminado con exito."));
        }
    }
}
