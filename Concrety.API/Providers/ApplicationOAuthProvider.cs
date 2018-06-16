using Concrety.Data.Context;
using Concrety.Identity;
using Concrety.Identity.Models;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Concrety.API.Providers
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        public ApplicationOAuthProvider()
        {
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            return Task.FromResult<object>(null);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            //TODO: Pegar do IoC
            var userManager = IdentityFactory.CreateUserManager(GetContext());

            ApplicationIdentityUser user = await userManager.FindAsync(context.UserName, context.Password).ConfigureAwait(false);

            if (user == null)
            {
                context.SetError("invalid_grant", "Usuário ou senha incorretos.");
                return;
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim(ClaimsIdentity.DefaultNameClaimType, user.UserName));
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            identity.AddClaim(new Claim(ClaimTypes.Role, String.Join(",", user.Roles.Select(r => r.RoleId))));
            //identity.AddClaim(new Claim("sub", context.UserName));

            context.Validated(identity);
        }

        private DbContext GetContext()
        {
            var useAWS = Convert.ToBoolean(ConfigurationManager.AppSettings["UseAWS"]);

            string nameOrConnectionString;

            if (useAWS)
                nameOrConnectionString = "name=ConcretyAWS";
            else
                nameOrConnectionString = "name=ConcretyAzure";

            return new ConcretyContext(nameOrConnectionString);
        }
    }
}