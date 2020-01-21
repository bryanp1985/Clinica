using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica.Models
{
    public interface IRepository
    {
        IEnumerable<Paciente> Pacientes { get; }
        Task<int> SavePacienteAsync(Paciente paciente);
        Task<Paciente> DeletePacienteAsync(int pacienteID);

        IEnumerable<Cita> Citas { get; }
        Task<int> SaveCitaAsync(Cita cita);
        Task<Cita> DeleteCitaAsync(int citaID);
    }
}
