using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinica.Models
{
    public class Cita
    {
        public int Id { get; set; }
        public string Clinica { get; set; }
        public string Tipo { get; set; }
        public ICollection<CitaLinea> Citas { get; set; }
            
        

       
    }

    public class CitaLinea
    {
        public int Id { get; set; }
        public int Count { get; set; }

        public int PacienteId { get; set; }
        public int CitaId { get; set; }

        public Paciente Paciente { get; set; }
        public Cita Cita { get; set; }
    }

    enum TipoDeCita
    {
        MedicinaGeneral = 1,
        Odontología = 2,
        Pediatría = 3,
        Neurología = 4
    }
}