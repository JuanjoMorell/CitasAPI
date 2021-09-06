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
    public class UsuariosController : ControllerBase
    {
        private IUsuarioService UService;
        private IMapper Mapper;

        public UsuariosController(IUsuarioService service, IMapper mapper)
        {
            UService = service;
            Mapper = mapper;
        }

        // GET: api/Usuarios
        [HttpGet]
        public IActionResult GetUsuarios()
        {
            IList<UsuarioDTO> usuariosDTO = new List<UsuarioDTO>();
            foreach (Usuario u in UService.FindAll())
            {
                usuariosDTO.Add(Mapper.Map<UsuarioDTO>(u));
            }
            return Ok(new MensajeDTO(200, usuariosDTO));
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public IActionResult GetUsuario(long id)
        {
            Usuario u = UService.FindById(id);
            if (u is not null)
            {
                return Ok(new MensajeDTO(200,Mapper.Map<UsuarioDTO>(u)));
            }
            return Ok(new MensajeDTO(404, "ERROR > No se ha encontrado a ningun usuario con esa id."));  
        }

        // POST: api/Usuarios
        [HttpPost]
        public IActionResult PostUsuario(UsuarioDTO usuarioDTO)
        {
            bool alm = UService.Save(Mapper.Map<Usuario>(usuarioDTO));
            if (!alm) return Ok(new MensajeDTO(412, "ERROR > El usuario ya existe."));
            else return Ok(new MensajeDTO(200, "Usuario registrado con exito."));
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUsuario(long id)
        {
            UService.DeleteById(id);
            return Ok(new MensajeDTO(200, "Usuario eliminado con exito."));
        }

    }
}
