using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
[assembly: OwinStartup(typeof(AspNet.Angular.Web.App_Start.OwinStartup))]
namespace AspNet.Angular.Web.App_Start
{
    public class OwinStartup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/"),
                ExpireTimeSpan = TimeSpan.FromMinutes(42),
                Provider = new CookieAuthenticationProvider
                {
                    OnValidateIdentity = ValidateIdentity
                }
            });
            // Use a cookie to temporarily store information about a user logging in with a third party login provider
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

        }

        public Task ValidateIdentity(CookieValidateIdentityContext context)
        {
            var expireUtc = context.Properties.ExpiresUtc;

            var claimType = "CookieExpireTimeUtc";
            if (context.Identity.HasClaim(x => x.Type.Equals(claimType)))
            {
                var existingClaim = context.Identity.FindFirst(claimType);
                context.Identity.RemoveClaim(existingClaim);
            }

            var newClaim = new Claim(claimType, expireUtc.Value.UtcTicks.ToString());
            context.Identity.AddClaim(newClaim);
            return Task.FromResult(0);
        }
    }
}