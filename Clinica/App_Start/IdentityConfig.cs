using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Owin;
using Microsoft.Owin;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Cookies;
using Clinica.Infrastructure.Identity;

[assembly: OwinStartup(typeof(Clinica.IdentityConfig))]

namespace Clinica
{
    public class IdentityConfig
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<ClinicaIdentityDbContext>(
                ClinicaIdentityDbContext.Create);
            app.CreatePerOwinContext<ClinicaUserManager>(ClinicaUserManager.Create);
            app.CreatePerOwinContext<ClinicaRoleManager>(ClinicaRoleManager.Create);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie
            });
        }
    }
}