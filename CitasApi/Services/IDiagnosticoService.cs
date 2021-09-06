using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CitasApi.Models;

namespace CitasApi.Services
{
    public interface IDiagnosticoService
    {
        public ICollection<Diagnostico> FindAll();
        public Diagnostico FindById(long id);
        public bool Save(Diagnostico diag);
        public void DeleteById(long id);
    }
}
