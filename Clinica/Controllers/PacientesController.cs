using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Clinica.Models;
using System.Threading.Tasks;

namespace Clinica.Controllers
{
    public class PacientesController : ApiController
    {
        public PacientesController()
        {
            Repository = new PacienteRepository();
        }

        public IEnumerable<Paciente> GetPacientes() {
            return Repository.Pacientes;
        }

        public IHttpActionResult GetPaciente(int id) {
            Paciente resultado = Repository.Pacientes.Where(p => p.Id == id).FirstOrDefault();
            if (resultado == null)
            {
                return (IHttpActionResult)BadRequest("no product found");
                //throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            else
            {
                return Ok(resultado);
            }
        }

        public async Task PostPaciente(Paciente paciente) {
            await Repository.SavePacienteAsync(paciente);
        }

        [Authorize(Roles = "Administrators")]
        public async Task DeletePaciente(int id) {
            await Repository.DeletePacienteAsync(id);
        }

        private IRepository Repository { get; set; }
    }
}
