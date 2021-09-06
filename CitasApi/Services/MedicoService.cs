using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CitasApi.Models;
using CitasApi.DTO;
using CitasApi.Data;

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
            return CMContext.Medicos.ToList<Medico>();
        }

        public Medico FindById(long id)
        {
            return CMContext.Medicos.Find(id);
        }

        public Medico FindByUsername(string username)
        {
            return CMContext.Medicos.Where(m => m.Username == username).FirstOrDefault();
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
    }
}
