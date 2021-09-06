using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitasApi.DTO
{
    public class MedicoDTO
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Username { get; set; }
        public string Clave { get; set; }
        public string Numero_Colegiado { get; set; }
        public ICollection<long> Pacientes { get; set; }
    }
}
