using Autofac;
using Concrety.Core.Interfaces.Services;
using Concrety.Services;
using Concrety.Services.Base;

namespace Concrety.Bootstrapper
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(ServiceBase<>)).As(typeof(IServiceBase<>)).InstancePerRequest();
            builder.RegisterType(typeof(NivelService)).As(typeof(INivelService)).InstancePerRequest();
            builder.RegisterType(typeof(UnidadeService)).As(typeof(IUnidadeService)).InstancePerRequest();
            builder.RegisterType(typeof(ServicoService)).As(typeof(IServicoService)).InstancePerRequest();
            builder.RegisterType(typeof(ServicoUnidadeService)).As(typeof(IServicoUnidadeService)).InstancePerRequest();
            builder.RegisterType(typeof(EmpreendimentoDiarioService)).As(typeof(IEmpreendimentoDiarioService)).InstancePerRequest();
            builder.RegisterType(typeof(CondicaoClimaticaService)).As(typeof(ICondicaoClimaticaService)).InstancePerRequest();
            builder.RegisterType(typeof(FichaVerificacaoMaterialService)).As(typeof(IFichaVerificacaoMaterialService)).InstancePerRequest();
            builder.RegisterType(typeof(FichaVerificacaoMaterialUnidadeService)).As(typeof(IFichaVerificacaoMaterialUnidadeService)).InstancePerRequest();
            builder.RegisterType(typeof(FornecedorService)).As(typeof(IFornecedorService)).InstancePerRequest();
        }
    }
}
