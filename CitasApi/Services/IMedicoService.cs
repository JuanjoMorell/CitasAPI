using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CitasApi.Models;

namespace CitasApi.Services
{
    public interface IMedicoService
    {
        public ICollection<Medico> FindAll();
        public Medico FindById(long id);
        public Medico FindByUsername(string username);
        public bool Save(Medico medico);
        public void DeleteById(long id);
    }
}
