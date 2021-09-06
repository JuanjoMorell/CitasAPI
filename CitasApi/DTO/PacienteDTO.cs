using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitasApi.DTO
{
    public class PacienteDTO
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Username { get; set; }
        public string Clave { get; set; }
        public string NSS { get; set; }
        public string Numero_Tarjeta { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public ICollection<long> Medicos { get; set; }
    }
}
