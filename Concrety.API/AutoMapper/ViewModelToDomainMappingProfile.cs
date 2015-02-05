using AutoMapper;
using Concrety.API.ViewModels;
using Concrety.Core.Entities;
using System;

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
            Mapper.CreateMap<CondicaoClimaticaViewModel, CondicaoClimatica>();
            Mapper.CreateMap<EmpreendimentoViewModel, Empreendimento>();
            Mapper.CreateMap<EmpreendimentoDiarioViewModel, EmpreendimentoDiario>()
                .AfterMap(
                (viewModel, model) =>
                {
                    model.Data = viewModel.DataDiario;
                }); 
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
            Mapper.CreateMap<FichaVerificacaoMaterialUnidadeViewModel, FichaVerificacaoMaterialUnidade>()
                .AfterMap(
                (viewModel, model) =>
                {
                    model.Data = viewModel.DataFicha;
                }); 
            Mapper.CreateMap<ItemVerificacaoMaterialViewModel, ItemVerificacaoMaterial>();
            Mapper.CreateMap<ItemVerificacaoMaterialUnidadeViewModel, ItemVerificacaoMaterialUnidade>();
            Mapper.CreateMap<FornecedorViewModel, Fornecedor>();
            Mapper.CreateMap<OcorrenciaViewModel, Ocorrencia>();
            Mapper.CreateMap<PatologiaViewModel, Patologia>();
            Mapper.CreateMap<SolucaoViewModel, Solucao>();
            Mapper.CreateMap<AnexoViewModel, Anexo>()
                .AfterMap(
                (viewModel, model) =>
                {
                    var indiceInicioExtensao = viewModel.Tipo.IndexOf("/") + 1;
                    var indiceInicioConteudo = viewModel.ConteudoDataURL.IndexOf(",") + 1;

                    model.Extensao = viewModel.Tipo.Substring(indiceInicioExtensao);
                    model.Conteudo = Convert.FromBase64String(viewModel.ConteudoDataURL.Substring(indiceInicioConteudo));
                });
        }
    }
}