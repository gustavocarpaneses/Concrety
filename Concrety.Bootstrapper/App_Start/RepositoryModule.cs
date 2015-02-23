using Autofac;
using Concrety.Core.Interfaces.Repositories;
using Concrety.Data.Repositories;

namespace Concrety.Bootstrapper
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(RepositoryBase<>)).As(typeof(IRepositoryBase<>)).InstancePerRequest();
            builder.RegisterType(typeof(AnexoBlobRepository)).As(typeof(IAnexoBlobRepository)).InstancePerRequest();
            builder.RegisterType(typeof(EmailRepository)).As(typeof(IEmailRepository)).InstancePerRequest();
        }
    }
}
