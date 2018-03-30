using Autofac;
using Autofac.Integration.WebApi;
using Concrety.API;
using Concrety.Core.Interfaces.Blob;
using Concrety.Core.Interfaces.Logging;
using Concrety.Core.Interfaces.UnitOfWork;
using Concrety.Crosscutting.Logging;
using Concrety.Data.Azure;
using Concrety.Data.Context;
using Concrety.Data.UnitOfWork;

namespace Concrety.API
{
    public class IocConfig
    {
        public static IContainer RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            const string nameOrConnectionString = "name=Concrety";

            builder.RegisterApiControllers(typeof(WebApiApplication).Assembly);
            builder.RegisterModule(new RepositoryModule());
            builder.RegisterModule(new ServiceModule());
            builder.RegisterType(typeof(AzureBlobManager)).As(typeof(IBlobManager)).InstancePerRequest();
            builder.RegisterType(typeof(UnitOfWork)).As(typeof(IUnitOfWork)).InstancePerRequest();
            builder.Register<IEntitiesContext>(b =>
            {
                var logger = b.Resolve<ILogger>();
                var context = new ConcretyContext(nameOrConnectionString, logger);
                return context;
            }).InstancePerRequest();
            builder.Register(b => NLogLogger.Instance).SingleInstance();
            builder.RegisterModule(new IdentityModule());

            return builder.Build();
        }
    }
}
