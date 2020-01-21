using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Clinica.Infrastructure.Identity
{
    public class ClinicaIdentityDbContext : IdentityDbContext<ClinicaUser>
    {
        public ClinicaIdentityDbContext() : base("ClinicaIdentityDb")
        {
            Database.SetInitializer<ClinicaIdentityDbContext>(new
               ClinicaIdentityDbInitializer());
        }

        public static ClinicaIdentityDbContext Create()
        {
            return new ClinicaIdentityDbContext();
        }
    }
}