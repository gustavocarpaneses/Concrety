using Autofac;
using Autofac.Integration.Mvc;
using Concrety.Bootstrapper.App_Start;
using Concrety.Data.Context;
using Concrety.Data.Repositories;
using Concrety.Data.UnitOfWork;
using Concrety.Domain.Interfaces.Repositories;
using Concrety.Domain.Interfaces.Services;
using Concrety.Domain.Interfaces.UnitOfWork;
using Concrety.Services.Base;
using System.Web.Mvc;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(IocConfig), "RegisterDependencies")]

namespace Concrety.Bootstrapper.App_Start
{
    public class IocConfig
    {
        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();
            const string nameOrConnectionString = "name=Concrety";
            //TODO: Registrar Aplicação web
            //builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterModule<AutofacWebTypesModule>();
            //builder.RegisterGeneric(typeof(RepositoryBase<>)).As(typeof(IRepositoryBase<>)).InstancePerRequest();
            builder.RegisterGeneric(typeof(ServiceBase<>)).As(typeof(IServiceBase<>)).InstancePerRequest();
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
