using Autofac;
using Concrety.Core.Interfaces.Identity;
using Concrety.Data.Context;
using Concrety.Identity;
using Concrety.Identity.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Concrety.Bootstrapper
{
    public class IdentityModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType(typeof(ApplicationUserManager)).As(typeof(IApplicationUserManager)).InstancePerRequest();
            builder.RegisterType(typeof(ApplicationRoleManager)).As(typeof(IApplicationRoleManager)).InstancePerRequest();
            builder.Register(b => b.Resolve<IEntitiesContext>() as DbContext).InstancePerRequest();
            builder.Register(b =>
            {
                var manager = IdentityFactory.CreateUserManager(b.Resolve<DbContext>());
                if (Startup.DataProtectionProvider != null)
                {
                    manager.UserTokenProvider =
                        new DataProtectorTokenProvider<ApplicationIdentityUser, int>(
                            Startup.DataProtectionProvider.Create("ASP.NET Identity"));
                }
                return manager;
            }).InstancePerRequest();
            builder.Register(b => IdentityFactory.CreateRoleManager(b.Resolve<DbContext>())).InstancePerRequest();
            builder.Register(b => HttpContext.Current.GetOwinContext().Authentication).InstancePerRequest();
            builder.Register<IUser<int>>(b =>
            {
                var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                var nameIdentifierClaim = authenticationManager.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

                if (nameIdentifierClaim == null)
                    return null;

                var idUsuario = Convert.ToInt32(nameIdentifierClaim.Value);

                return new ApplicationIdentityUser
                {
                    Id = idUsuario
                };
            }).InstancePerRequest();

        }
    }
}
