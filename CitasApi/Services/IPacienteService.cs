using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CitasApi.Models;

namespace CitasApi.Services
{
    public interface IPacienteService
    {
        public ICollection<Paciente> FindAll();
        public Paciente FindById(long id);
        public Paciente FindByUsername(string username);
        public bool Save(Paciente usuario);
        public void DeleteById(long id);

        // Operaciones extra
        public bool AddMedico(long pacienteID, long medicoID);
        public Paciente Login(string username, string clave);
    }
}
