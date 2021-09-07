using CitasApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CitasApi.DTO;
using CitasApi.Data;
using Microsoft.EntityFrameworkCore;

namespace CitasApi.Services
{
    public class CitaService : ICitaService
    {
        // Base de datos
        private CitasMedicasContext CMContext;
        private IMedicoService MService;
        private IPacienteService PService;
        private IDiagnosticoService DService;

        public CitaService(CitasMedicasContext cmcontext, IMedicoService mService, IPacienteService pService, IDiagnosticoService dService)
        {
            CMContext = cmcontext;
            MService = mService;
            PService = pService;
            DService = dService;
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
            return CMContext.Citas
                            .Include(c => c.Paciente)
                            .Include(c => c.Medico)
                            .Include(c => c.Diagnostico)
                            .ToList();
        }

        public Cita FindById(long id)
        {
            return CMContext.Citas
                            .Where(c => c.Id == id)
                            .Include(c => c.Paciente)
                            .Include(c => c.Medico)
                            .Include(c => c.Diagnostico)
                            .FirstOrDefault();
        }

        public ICollection<Cita> FindByMedico(long medicoID)
        {
            return CMContext.Citas
                            .Where(c => c.Medico.Id == medicoID)
                            .Include(c => c.Paciente)
                            .Include(c => c.Medico)
                            .Include(c => c.Diagnostico)
                            .ToList();
        }

        public ICollection<Cita> FindByPaciente(long pacienteID)
        {
            return CMContext.Citas
                            .Where(c => c.Paciente.Id == pacienteID)
                            .Include(c => c.Paciente)
                            .Include(c => c.Medico)
                            .Include(c => c.Diagnostico)
                            .ToList();
        }

        public bool Save(Cita cita, long pacienteID, long medicoID)
        {
            if(cita is not null)
            {
                Medico m = MService.FindById(medicoID);
                Paciente p = PService.FindById(pacienteID);

                if (m is null || p is null) return false;

                // Comprobar que tienen relacion paciente-medico
                bool t = relacion(m, p);

                if (!t) return false;

                cita.Paciente = p;
                cita.Medico = m;
                cita.Diagnostico = null; // Cita sin diagnostico
                CMContext.Citas.Add(cita);
                CMContext.SaveChanges();
                return true;
            } else return false;
        }

        public bool AddDiagnostico(long citaID, Diagnostico diag)
        {
            Cita c = FindById(citaID);
            if (c is not null && diag is not null)
            {
                CMContext.Diagnosticos.Add(diag);
                c.Diagnostico = diag;
                CMContext.SaveChanges();
                return true;
            }
            else return false;
        }

        public bool relacion(Medico m, Paciente p)
        {
            return (m.Pacientes.Contains(p)) && p.Medicos.Contains(m);
        }
    }
}
