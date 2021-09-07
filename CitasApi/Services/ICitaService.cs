using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CitasApi.Models;

namespace CitasApi.Services
{
    public interface ICitaService
    {
        public ICollection<Cita> FindAll();
        public Cita FindById(long id);
        public ICollection<Cita> FindByPaciente(long pacienteID);
        public ICollection<Cita> FindByMedico(long medicoID);
        public bool Save(Cita cita, long pacienteID, long medicoID);
        public void DeleteById(long id);

        public bool AddDiagnostico(long citaID, Diagnostico diag);
    }
}
