using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Clinica.Models
{
    public class PacienteDbContext : DbContext  
    {
          public PacienteDbContext() : base("ClinicaDb") {
              Database.SetInitializer<PacienteDbContext>(new PacienteDbInitializer());
        }

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Cita> Citas { get; set; }
        public DbSet<CitaLinea> CitaLineas { get; set; }
    }
}