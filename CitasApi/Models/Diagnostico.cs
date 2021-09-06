using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CitasApi.Models
{
    public class Diagnostico
    {
        [Key]
        public long Id { get; set; }
        public string Valoracion_Especialista { get; set; }
        public string Enfermedad { get; set; }
    }
}
