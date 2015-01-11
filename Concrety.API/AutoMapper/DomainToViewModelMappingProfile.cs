using AutoMapper;
using Concrety.API.ViewModels;
using Concrety.Core.Entities;

namespace Concrety.API.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Empreendimento, EmpreendimentoViewModel>();
            Mapper.CreateMap<MacroServico, MacroServicoViewModel>();
            Mapper.CreateMap<Nivel, NivelViewModel>();
        }
    }
}