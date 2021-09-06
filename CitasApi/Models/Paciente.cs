using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace CitasApi.Models
{
    [Table("Paciente")]
    public class Paciente : Usuario
    {
        public string NSS { get; set; }
        public string Numero_Tarjeta { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public ICollection<Medico> Medicos { get; set; } = new List<Medico>();
    }
}
