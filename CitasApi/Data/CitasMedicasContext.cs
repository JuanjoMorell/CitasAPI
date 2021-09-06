using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CitasApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CitasApi.Data
{
    public class CitasMedicasContext : DbContext
    {

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Diagnostico> Diagnosticos { get; set; }
        public DbSet<Cita> Citas { get; set; }

        public CitasMedicasContext(DbContextOptions<CitasMedicasContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().ToTable("Usuario");
            modelBuilder.Entity<Paciente>().ToTable("Paciente");
            modelBuilder.Entity<Medico>().ToTable("Medico");
            modelBuilder.Entity<Diagnostico>().ToTable("Diagnostico");
            modelBuilder.Entity<Cita>().ToTable("Cita");
        }
    }
}
