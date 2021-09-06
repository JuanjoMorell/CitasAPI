using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitasApi.DTO
{
    public class DiagnosticoDTO
    {
        public long Id { get; set; }
        public string Valoracion_Especialista { get; set; }
        public string Enfermedad { get; set; }
    }
}
