using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace Clinica.Infrastructure.Identity
{
    public class ClinicaUserManager : UserManager<ClinicaUser>
    {
        public ClinicaUserManager(IUserStore<ClinicaUser> clinica)
            : base(clinica) {}

        public static ClinicaUserManager Create(
                IdentityFactoryOptions<ClinicaUserManager> options,
                IOwinContext context) {

            ClinicaIdentityDbContext dbContext = context.Get<ClinicaIdentityDbContext>();
            ClinicaUserManager manager = 
                new ClinicaUserManager(new UserStore<ClinicaUser>(dbContext));
            return manager;
        }
    }
}