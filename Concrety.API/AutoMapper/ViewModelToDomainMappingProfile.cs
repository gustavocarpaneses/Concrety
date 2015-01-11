using AutoMapper;
using Concrety.API.ViewModels;
using Concrety.Core.Entities;

namespace Concrety.API.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<EmpreendimentoViewModel, Empreendimento>();
            Mapper.CreateMap<MacroServicoViewModel, MacroServico>();
            Mapper.CreateMap<NivelViewModel, Nivel>();
        }
    }
}