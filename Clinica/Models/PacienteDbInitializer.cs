using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Clinica.Models
{
    public class PacienteDbInitializer : DropCreateDatabaseAlways<PacienteDbContext> {

        protected override void Seed(PacienteDbContext context) {

            new List<Paciente> {
                new Paciente() { Nombre = "Kay", Descripcion = "Medicina General", 
                    Categoria = "Medicina General", Edad = 27 }, 
                new Paciente() { Nombre = "Kay", Descripcion = "Medicina General", 
                    Categoria = "Medicina General", Edad = 27 },
                new Paciente() { Nombre = "Kay", Descripcion = "Medicina General", 
                    Categoria = "Medicina General", Edad = 27 },
                new Paciente() { Nombre = "Kay", Descripcion = "Medicina General", 
                    Categoria = "Medicina General", Edad = 27 },
                new Paciente() { Nombre = "Kay", Descripcion = "Medicina General", 
                    Categoria = "Medicina General", Edad = 27 },
                new Paciente() { Nombre = "Kay", Descripcion = "Medicina General", 
                    Categoria = "Medicina General", Edad = 27 },
                new Paciente() { Nombre = "Kay", Descripcion = "Medicina General", 
                    Categoria = "Medicina General", Edad = 27 },
                new Paciente() { Nombre = "Kay", Descripcion = "Medicina General", 
                    Categoria = "Medicina General", Edad = 27 },
                new Paciente() { Nombre = "Kay", Descripcion = "Medicina General", 
                    Categoria = "Medicina General", Edad = 27 },
            }.ForEach(paciente => context.Pacientes.Add(paciente));

            context.SaveChanges();

            new List<Cita> {
                new Cita() { Clinica = "Alice Smith", Tipo = TipoDeCita.Neurología.ToString(), 
                    Citas = new List<CitaLinea> {
                        new CitaLinea() { PacienteId = 2, Count = 2},
                        new CitaLinea() { PacienteId = 3, Count = 1},
                    }},
                new Cita() { Clinica = "Alice Smith", Tipo = TipoDeCita.Odontología.ToString(), 
                    Citas = new List<CitaLinea> {
                        new CitaLinea() { PacienteId = 5, Count = 1},
                        new CitaLinea() { PacienteId = 6, Count = 3},
                        new CitaLinea() { PacienteId = 1, Count = 3},
                   }}
            }.ForEach(cita => context.Citas.Add(cita));

            context.SaveChanges();
        }
    
    }
}