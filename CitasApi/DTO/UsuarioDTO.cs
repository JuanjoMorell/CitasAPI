using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitasApi.DTO
{
    public class UsuarioDTO
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Username { get; set; }
        public string Clave { get; set; }
    }
}
