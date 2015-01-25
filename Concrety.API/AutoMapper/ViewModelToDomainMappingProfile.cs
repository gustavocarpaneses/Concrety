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
            Mapper.CreateMap<EmpreendimentoDiarioViewModel, EmpreendimentoDiario>();
            Mapper.CreateMap<MacroServicoViewModel, MacroServico>();
            Mapper.CreateMap<NivelViewModel, Nivel>();
            Mapper.CreateMap<UnidadeViewModel, Unidade>();
            Mapper.CreateMap<ServicoViewModel, Servico>();
            Mapper.CreateMap<ServicoUnidadeViewModel, ServicoUnidade>();
            Mapper.CreateMap<FichaVerificacaoServicoViewModel, FichaVerificacaoServico>();
            Mapper.CreateMap<FichaVerificacaoServicoUnidadeViewModel, FichaVerificacaoServicoUnidade>();
            Mapper.CreateMap<ItemVerificacaoServicoViewModel, ItemVerificacaoServico>();
            Mapper.CreateMap<ItemVerificacaoServicoUnidadeViewModel, ItemVerificacaoServicoUnidade>();
            Mapper.CreateMap<FichaVerificacaoMaterialViewModel, FichaVerificacaoMaterial>();
            Mapper.CreateMap<FichaVerificacaoMaterialUnidadeViewModel, FichaVerificacaoMaterialUnidade>();
            Mapper.CreateMap<FornecedorViewModel, Fornecedor>();
        }
    }
}