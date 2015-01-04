using Autofac;
using Autofac.Integration.WebApi;
using Concrety.API.Controllers;
using Concrety.Core.Interfaces.UnitOfWork;
using Concrety.Data.Context;
using Concrety.Data.UnitOfWork;

namespace Concrety.Bootstrapper.API
{
    public class IocConfig
    {
        public static IContainer RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            const string nameOrConnectionString = "name=Concrety";

            builder.RegisterApiControllers(typeof(AccountController).Assembly);
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

            return builder.Build();
        }
    }
}
