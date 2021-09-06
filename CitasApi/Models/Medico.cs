using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace CitasApi.Models
{
    [Table("Medico")]
    public class Medico : Usuario
    {
        public string Numero_Colegiado { get; set; }

        public ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();
    }
}
