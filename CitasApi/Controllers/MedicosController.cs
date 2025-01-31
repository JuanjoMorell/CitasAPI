﻿using System;
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
    public class MedicosController : ControllerBase
    {
        private IMedicoService MService;
        private IMapper Mapper;

        public MedicosController(IMedicoService service, IMapper mapper)
        {
            MService = service;
            Mapper = mapper;
        }

        // GET: api/Medicos
        [HttpGet]
        public IActionResult GetMedicos()
        {
            IList<MedicoDTO> medicosDTO = new List<MedicoDTO>();
            foreach(Medico m in MService.FindAll())
            {
                medicosDTO.Add(Mapper.Map<MedicoDTO>(m));
            }
            return Ok(new MensajeDTO(200, medicosDTO));
        }

        // GET: api/Medicos/5
        [HttpGet("{id}")]
        public IActionResult GetMedicoById(long id)
        {
            Medico m = MService.FindById(id);

            if (m is not null)
            {
                return Ok(new MensajeDTO(200, Mapper.Map<MedicoDTO>(m)));
            }

            return Ok(new MensajeDTO(404, "ERROR > No se ha encontrado al medico."));
        }

        // GET: api/Medicos/5
        [HttpGet("medico/{username}")]
        public IActionResult GetMedicoByUsername(string username)
        {
            Medico m = MService.FindByUsername(username);

            if (m is not null)
            {
                return Ok(new MensajeDTO(200, Mapper.Map<MedicoDTO>(m)));
            }

            return Ok(new MensajeDTO(404, "ERROR > No se ha encontrado al medico."));
        }

        // POST: api/Medicos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostMedico(MedicoDTO medicoDTO)
        {
            bool alm = MService.Save(Mapper.Map<Medico>(medicoDTO));
            if (!alm) return Ok(new MensajeDTO(412, "ERROR > El medico ya existe."));
            else return Ok(new MensajeDTO(200, "Medico registrado con exito."));
        }

        // DELETE: api/Medicos/5
        [HttpDelete("{id}")]
        public IActionResult DeleteMedico(long id)
        {
            MService.DeleteById(id);
            return Ok(new MensajeDTO(200, "Medico eliminado con exito"));
        }

        [HttpPut]
        public IActionResult AddPaciente(MedicoPacienteDTO mpDTO)
        {
            bool alm = MService.AddPaciente(mpDTO.MedicoID, mpDTO.PacienteID);
            if (!alm) return Ok(new MensajeDTO(412, "El paciente o medico ya existe."));
            return Ok(new MensajeDTO(200, "El paciente se ha registrado con exito."));
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginDTO login)
        {
            Medico m = MService.Login(login.Username, login.Clave);
            if (m is not null) return Ok(new MensajeDTO(200, Mapper.Map<MedicoDTO>(m)));
            else return Ok(new MensajeDTO(404, "ERROR > Login incorrecto"));
        }
    }
}
