using Autofac;
using Concrety.Core.Interfaces.Services;
using Concrety.Services.Base;

namespace Concrety.Bootstrapper.API
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(ServiceBase<>)).As(typeof(IServiceBase<>)).InstancePerRequest();
        }
    }
}
