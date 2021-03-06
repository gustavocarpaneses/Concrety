﻿using AutoMapper;
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
            Mapper.CreateMap<CondicaoClimaticaViewModel, CondicaoClimatica>();
            Mapper.CreateMap<EmpreendimentoViewModel, Empreendimento>();
            Mapper.CreateMap<EmpreendimentoDiarioViewModel, EmpreendimentoDiario>()
                .AfterMap(
                (viewModel, model) =>
                {
                    model.Data = viewModel.DataDiario;
                    model.DiariosPeriodos.Each(p =>
                    {
                        if (p.CondicaoClimatica != null)
                        {
                            //por algum motivo desconhecido, o Kendo está perdendo essa propriedade do Model
                            p.IdCondicaoClimatica = p.CondicaoClimatica.Id;
                        }
                    });
                });
            Mapper.CreateMap<EmpreendimentoDiarioPeriodoViewModel, EmpreendimentoDiarioPeriodo>();
            Mapper.CreateMap<EmpreendimentoPeriodoViewModel, EmpreendimentoPeriodo>();
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
            Mapper.CreateMap<AnexoViewModel, Anexo>();
            Mapper.CreateMap<OcorrenciaAnexoViewModel, OcorrenciaAnexo>();
            Mapper.CreateMap<EmailFeedbackViewModel, EmailFeedback>();
            Mapper.CreateMap<EmailContatoViewModel, EmailContato>();
        }
    }
}