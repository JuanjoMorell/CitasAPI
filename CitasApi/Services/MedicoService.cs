using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CitasApi.Models;
using CitasApi.DTO;
using CitasApi.Data;
using Microsoft.EntityFrameworkCore;

namespace CitasApi.Services
{
    public class MedicoService : IMedicoService
    {
        // Base de datos
        private CitasMedicasContext CMContext;

        public MedicoService(CitasMedicasContext cmcontext)
        {
            CMContext = cmcontext;
        }

        public void DeleteById(long id)
        {
            Medico aux = FindById(id);
            if (aux != null)
            {
                CMContext.Medicos.Remove(aux);
                CMContext.SaveChanges();
            }
        }

        public ICollection<Medico> FindAll()
        {
            return CMContext.Medicos.Include(m => m.Pacientes).ToList();
        }

        public Medico FindById(long id)
        {
            return CMContext.Medicos.Where(m => m.Id == id).Include(m => m.Pacientes).FirstOrDefault();
        }

        public Medico FindByUsername(string username)
        {
            return CMContext.Medicos.Where(m => m.Username == username).Include(m => m.Pacientes).FirstOrDefault();
        }

        public bool Save(Medico medico)
        {
            if (medico is not null)
            {
                CMContext.Medicos.Add(medico);
                CMContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool AddPaciente(long medicoID, long pacienteID)
        {
            Medico m = FindById(medicoID);
            Paciente p = CMContext.Pacientes.Find(pacienteID);
            if (m is null || p is null)
            {
                return false;
            }
            if (!m.Pacientes.Contains(p)) m.Pacientes.Add(p);
            if (!p.Medicos.Contains(m)) p.Medicos.Add(m);

            CMContext.SaveChanges();

            return true;
        }

        public Medico Login(string username, string clave)
        {
            Medico m = FindByUsername(username);
            if (m is not null && m.Clave == clave) return m;
            return null;
        }
    }
}
