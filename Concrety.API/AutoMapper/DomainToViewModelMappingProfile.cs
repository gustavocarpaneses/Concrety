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
            Mapper.CreateMap<EmpreendimentoDiario, EmpreendimentoDiarioViewModel>();
            Mapper.CreateMap<CondicaoClimatica, CondicaoClimaticaViewModel>();
            Mapper.CreateMap<MacroServico, MacroServicoViewModel>();
            Mapper.CreateMap<Nivel, NivelViewModel>();
            Mapper.CreateMap<Unidade, UnidadeViewModel>();
            Mapper.CreateMap<Servico, ServicoViewModel>();
            Mapper.CreateMap<ServicoUnidade, ServicoUnidadeViewModel>();
            Mapper.CreateMap<FichaVerificacaoServico, FichaVerificacaoServicoViewModel>();
            Mapper.CreateMap<FichaVerificacaoServicoUnidade, FichaVerificacaoServicoUnidadeViewModel>();
            Mapper.CreateMap<ItemVerificacaoServico, ItemVerificacaoServicoViewModel>();
            Mapper.CreateMap<ItemVerificacaoServicoUnidade, ItemVerificacaoServicoUnidadeViewModel>()
                .AfterMap(
                (model, viewModel) =>
                {
                    viewModel.QuantidadeOcorrencias = model.ObterQuantidadeOcorrencias();

                }
            );

            Mapper.CreateMap<FichaVerificacaoMaterial, FichaVerificacaoMaterialViewModel>();
            Mapper.CreateMap<FichaVerificacaoMaterialUnidade, FichaVerificacaoMaterialUnidadeViewModel>();
            Mapper.CreateMap<ItemVerificacaoMaterial, ItemVerificacaoMaterialViewModel>();
            Mapper.CreateMap<ItemVerificacaoMaterialUnidade, ItemVerificacaoMaterialUnidadeViewModel>();
            Mapper.CreateMap<Fornecedor, FornecedorViewModel>();

        }
    }
}