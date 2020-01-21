using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Clinica.Models;
using System.Threading.Tasks;
using Clinica.Infrastructure.Identity;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Security.Claims;

namespace Clinica.Controllers
{
    public class PrepController : Controller
    {
        IRepository repo;

        public PrepController()
        {
            repo = new PacienteRepository();
        }
        // GET: Prep
        public ActionResult Index()
        {
            return View(repo.Pacientes);
        }

        [Authorize(Roles = "Administrators")]
        public async Task<ActionResult> DeletePaciente(int id)
        {
            await repo.DeletePacienteAsync(id);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Administrators")]
        public async Task<ActionResult> SavePaciente(Paciente paciente)
        {
            await repo.SavePacienteAsync(paciente);
            return RedirectToAction("Index");
        }

        public ActionResult Citas()
        {
            return View(repo.Citas);
        }

        public async Task<ActionResult> DeleteCita(int id)
        {
            await repo.DeleteCitaAsync(id);
            return RedirectToAction("Citas");
        }

        public async Task<ActionResult> SaveCita(Cita cita)
        {
            await repo.SaveCitaAsync(cita);
            return RedirectToAction("Citas");
        }

        public async Task<ActionResult> SignIn()
        {
            IAuthenticationManager authMgr = HttpContext.GetOwinContext().Authentication;
            ClinicaUserManager userMrg = HttpContext.GetOwinContext().GetUserManager<ClinicaUserManager>();

            ClinicaUser user = await userMrg.FindAsync("Admin", "secret");
            authMgr.SignIn(await userMrg.CreateIdentityAsync(user,
                DefaultAuthenticationTypes.ApplicationCookie));
            return RedirectToAction("Index");
        }

        public ActionResult SignOut()
        {
            HttpContext.GetOwinContext().Authentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}