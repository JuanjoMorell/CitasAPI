using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CitasApi.Models
{
    public class Cita
    {
        [Key]
        public long Id { get; set; }
        public DateTime FechaHora { get; set; }
        public string Motivo_Cita { get; set; }
        public int Attribute11 { get; set; }

        public Medico Medico { get; set; }
        public Paciente Paciente { get; set; }
        public Diagnostico Diagnostico { get; set; }
    }
}
