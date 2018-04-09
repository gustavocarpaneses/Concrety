using Autofac;
using Autofac.Integration.WebApi;
using Concrety.Core.Interfaces.Blob;
using Concrety.Core.Interfaces.Logging;
using Concrety.Core.Interfaces.UnitOfWork;
using Concrety.Crosscutting.Logging;
using Concrety.Data.Context;
using Concrety.Data.UnitOfWork;
using System;
using System.Configuration;
using System.Data.Entity;

namespace Concrety.API
{
    public class IocConfig
    {
        public static IContainer RegisterDependencies()
        {
            var useAWS = Convert.ToBoolean(ConfigurationManager.AppSettings["UseAWS"]);

            var builder = new ContainerBuilder();

            string nameOrConnectionString;

            if (useAWS) 
                nameOrConnectionString = "name=ConcretyAWS";
            else
                nameOrConnectionString = "name=ConcretyAzure";

            builder.RegisterApiControllers(typeof(WebApiApplication).Assembly);
            builder.RegisterModule(new RepositoryModule());
            builder.RegisterModule(new ServiceModule());

            if (useAWS)
                builder.RegisterType(typeof(Data.AWS.BlobManager)).As(typeof(IBlobManager)).InstancePerRequest();
            else
                builder.RegisterType(typeof(Data.Azure.BlobManager)).As(typeof(IBlobManager)).InstancePerRequest();
            
            builder.RegisterType(typeof(UnitOfWork)).As(typeof(IUnitOfWork)).InstancePerRequest();

            builder.Register<IEntitiesContext>(b =>
            {
                var logger = b.Resolve<ILogger>();
                var context = new ConcretyContext(nameOrConnectionString, logger);
                return context;
            }).InstancePerRequest();

            builder.Register<DbContext>(b =>
            {
                var logger = b.Resolve<ILogger>();
                var context = new ConcretyContext(nameOrConnectionString, logger);
                return context;
            }).SingleInstance();

            builder.Register(b => NLogLogger.Instance).SingleInstance();
            builder.RegisterModule(new IdentityModule());

            return builder.Build();
        }
    }
}
