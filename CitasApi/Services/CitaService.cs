using CitasApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CitasApi.DTO;
using CitasApi.Data;

namespace CitasApi.Services
{
    public class CitaService : ICitaService
    {
        // Base de datos
        private CitasMedicasContext CMContext;

        public CitaService(CitasMedicasContext cmcontext)
        {
            CMContext = cmcontext;
        }

        public void DeleteById(long id)
        {
            Cita aux = FindById(id);
            if (aux != null)
            {
                CMContext.Citas.Remove(aux);
                CMContext.SaveChanges();
            }
        }

        public ICollection<Cita> FindAll()
        {
            return CMContext.Citas.ToList<Cita>();
        }

        public Cita FindById(long id)
        {
            return CMContext.Citas.Find(id);
        }

        public Cita FindByMedico(string username)
        {
            return CMContext.Citas.Where(c => c.Medico.Username == username).FirstOrDefault();
        }

        public Cita FindByPaciente(string username)
        {
            return CMContext.Citas.Where(c => c.Paciente.Username == username).FirstOrDefault();
        }

        public bool Save(Cita cita)
        {
            if(cita is not null)
            {
                CMContext.Citas.Add(cita);
                CMContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
