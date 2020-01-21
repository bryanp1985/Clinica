using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace Clinica.Models
{
    public class PacienteRepository : IRepository
    {
        private PacienteDbContext context = new PacienteDbContext();

        public IEnumerable<Paciente> Pacientes
        {
            get { return context.Pacientes; }
        }

        public Task<int> SavePacienteAsync(Paciente paciente)
        {
            if (paciente.Id == 0)
            {
                context.Pacientes.Add(paciente);
            }
            else
            {
                Paciente dbEntry = context.Pacientes.Find(paciente.Id);
                if (dbEntry != null)
                {
                    dbEntry.Nombre = paciente.Nombre;
                    dbEntry.Descripcion = paciente.Descripcion;
                    dbEntry.Edad = paciente.Edad;
                    dbEntry.Categoria = paciente.Categoria;
                }
            }
            return context.SaveChangesAsync();
        }

        public async Task<Paciente> DeletePacienteAsync(int pacienteID)
        {
            Paciente dbEntry = context.Pacientes.Find(pacienteID);
            if (dbEntry != null)
            {
                context.Pacientes.Remove(dbEntry);
            }
            await context.SaveChangesAsync();
            return dbEntry;
        }

        public IEnumerable<Cita> Citas
        {
            get { return context.Citas.Include("Citas").Include("Citas.Paciente"); }
        }

        public async Task<int> SaveCitaAsync(Cita cita)
        {
            if (cita.Id == 0)
            {
                context.Citas.Add(cita);
            }
            return await context.SaveChangesAsync();
        }

        public async Task<Cita> DeleteCitaAsync(int citaID)
        {
            Cita dbEntry = context.Citas.Find(citaID);
            if (dbEntry != null)
            {
                context.Citas.Remove(dbEntry);
            }
            await context.SaveChangesAsync();
            return dbEntry;
        }
    }
}