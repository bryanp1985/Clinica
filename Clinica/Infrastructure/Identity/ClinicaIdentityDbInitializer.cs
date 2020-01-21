using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace Clinica.Infrastructure.Identity
{
    public class ClinicaIdentityDbInitializer : CreateDatabaseIfNotExists<ClinicaIdentityDbContext>
    {
        protected override void Seed(ClinicaIdentityDbContext context)
        {

            ClinicaUserManager userMgr =
                new ClinicaUserManager(new UserStore<ClinicaUser>(context));
            ClinicaRoleManager roleMgr =
                new ClinicaRoleManager(new RoleStore<ClinicaRole>(context));

            string roleName = "Administrators";
            string userName = "Admin";
            string password = "secret";
            string email = "admin@example.com";

            if (!roleMgr.RoleExists(roleName))
            {
                roleMgr.Create(new ClinicaRole(roleName));
            }

            ClinicaUser user = userMgr.FindByName(userName);
            if (user == null)
            {
                userMgr.Create(new ClinicaUser
                {
                    UserName = userName,
                    Email = email
                }, password);
                user = userMgr.FindByName(userName);
            }

            if (!userMgr.IsInRole(user.Id, roleName))
            {
                userMgr.AddToRole(user.Id, roleName);
            }

            base.Seed(context);
        }
    }
}