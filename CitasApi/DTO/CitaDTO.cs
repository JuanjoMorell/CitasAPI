using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitasApi.DTO
{
    public class CitaDTO
    {
        public long Id { get; set; }
        public DateTime FechaHora { get; set; }
        public string Motivo_Cita { get; set; }
        public int Attribute11 { get; set; }

        public long Medico { get; set; }
        public long Paciente { get; set; }
        public long Diagnostico { get; set; }
    }
}
