using CitasApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CitasApi.Data;
using CitasApi.DTO;

namespace CitasApi.Services
{
    public class PacienteService : IPacienteService
    {
        // Base de datos
        private CitasMedicasContext CMContext;
        private IMedicoService MService;

        public PacienteService(CitasMedicasContext cmcontext, IMedicoService service)
        {
            CMContext = cmcontext;
            MService = service;
        }

        public void DeleteById(long id)
        {
            Paciente aux = FindById(id);
            if(aux != null)
            {
                CMContext.Pacientes.Remove(aux);
                CMContext.SaveChanges();
            }
        }

        public ICollection<Paciente> FindAll()
        {
            return CMContext.Pacientes.ToList<Paciente>();
        }

        public Paciente FindById(long id)
        {
            return CMContext.Pacientes.Find(id);
        }

        public Paciente FindByUsername(string username)
        {
            return CMContext.Pacientes.Where(p => p.Username == username).FirstOrDefault();
        }

        public bool Save(Paciente paciente)
        {
            if(paciente is not null)
            {
                CMContext.Pacientes.Add(paciente);
                CMContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool AddMedico(long pacienteID, long medicoID)
        {
            Paciente p = FindById(pacienteID);
            Medico m = MService.FindById(medicoID);
            if (p is null || m is null) return false;

            if (!p.Medicos.Contains(m)) p.Medicos.Add(m);
            if (!m.Pacientes.Contains(p)) m.Pacientes.Add(p);

            CMContext.SaveChanges();
            return true;
        }
    }
}
