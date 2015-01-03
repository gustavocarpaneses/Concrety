using Autofac;
using Autofac.Integration.Mvc;
using Concrety.Bootstrapper.App_Start;
using Concrety.Data.Context;
using Concrety.Data.Repositories;
using Concrety.Data.UnitOfWork;
using Concrety.Core.Interfaces.Repositories;
using Concrety.Core.Interfaces.Services;
using Concrety.Core.Interfaces.UnitOfWork;
using System.Web.Mvc;
using Concrety.Web;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(IocConfig), "RegisterDependencies")]

namespace Concrety.Bootstrapper.App_Start
{
    public class IocConfig
    {
        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();
            const string nameOrConnectionString = "name=Concrety";
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterModule<AutofacWebTypesModule>();
            //builder.RegisterGeneric(typeof(RepositoryBase<>)).As(typeof(IRepositoryBase<>)).InstancePerRequest();
            builder.RegisterModule(new ServiceModule());
            builder.RegisterType(typeof(UnitOfWork)).As(typeof(IUnitOfWork)).InstancePerRequest();
            builder.Register<IEntitiesContext>(b =>
            {
                //var logger = b.Resolve<ILogger>();
                var context = new ConcretyContext(nameOrConnectionString);//, logger);
                return context;
            }).InstancePerRequest();
            /*builder.Register(b => NLogLogger.Instance).SingleInstance();*/
            builder.RegisterModule(new IdentityModule());

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
