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
    public class ClinicaRoleManager : RoleManager<ClinicaRole>
    {
        public ClinicaRoleManager(RoleStore<ClinicaRole> store) : base(store) { }

        public static ClinicaRoleManager Create(
                IdentityFactoryOptions<ClinicaRoleManager> options, 
                IOwinContext context) {
                    return new ClinicaRoleManager(new
                RoleStore<ClinicaRole>(context.Get<ClinicaIdentityDbContext>()));
        }
    }
}