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
        public Cita FindByPaciente(string username);
        public Cita FindByMedico(string username);
        public bool Save(Cita cita);
        public void DeleteById(long id);
    }
}
