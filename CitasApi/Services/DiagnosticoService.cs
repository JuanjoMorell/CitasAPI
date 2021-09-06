using CitasApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CitasApi.Services;
using CitasApi.Data;
using CitasApi.DTO;

namespace CitasApi.Services
{
    public class DiagnosticoService : IDiagnosticoService
    {
        // Base de datos
        private CitasMedicasContext CMContext;

        public DiagnosticoService(CitasMedicasContext cmcontext)
        {
            CMContext = cmcontext;
        }

        public void DeleteById(long id)
        {
            Diagnostico aux = FindById(id);
            if (aux != null)
            {
                CMContext.Diagnosticos.Remove(aux);
                CMContext.SaveChanges();
            }
        }

        public ICollection<Diagnostico> FindAll()
        {
            return CMContext.Diagnosticos.ToList<Diagnostico>();
        }

        public Diagnostico FindById(long id)
        {
            return CMContext.Diagnosticos.Find(id);
        }

        public bool Save(Diagnostico diag)
        {
            if (diag is not null)
            {
                CMContext.Diagnosticos.Add(diag);
                CMContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
