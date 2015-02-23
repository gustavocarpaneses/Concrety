using AutoMapper;
using Concrety.API.ViewModels;
using Concrety.Core.Entities;
using Concrety.Core.Extensions;
using Concrety.Core.Messages;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

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
            Mapper.CreateMap<EmpreendimentoDiario, EmpreendimentoDiarioViewModel>()
                .AfterMap(
                (model, viewModel) =>
                {
                    viewModel.DataDiario = model.Data;
                });
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
            Mapper.CreateMap<FichaVerificacaoMaterialUnidade, FichaVerificacaoMaterialUnidadeViewModel>()
                .AfterMap(
                (model, viewModel) =>
                {
                    viewModel.DataFicha = model.Data;
                });
            Mapper.CreateMap<ItemVerificacaoMaterial, ItemVerificacaoMaterialViewModel>();
            Mapper.CreateMap<ItemVerificacaoMaterialUnidade, ItemVerificacaoMaterialUnidadeViewModel>();
            Mapper.CreateMap<Fornecedor, FornecedorViewModel>();
            Mapper.CreateMap<Ocorrencia, OcorrenciaViewModel>()
                .AfterMap((model, viewModel) =>
                    {
                        viewModel.NomeFichaVerificacaoServico = model.ItemVerificacao.FichaVerificacaoUnidade.FichaVerificacaoServico.Nome;
                        viewModel.NomeItemVerificacaoServico = model.ItemVerificacao.ItemVerificacao.Nome;
                        viewModel.NomePatologia = model.Patologia.Nome;

                        var nomesUnidades = new List<string>();
                        var unidadeAtual = model.ItemVerificacao.FichaVerificacaoUnidade.Servico.Unidade;
                        
                        do
                        {
                            nomesUnidades.Add(unidadeAtual.Nome);
                            unidadeAtual = unidadeAtual.UnidadePai;
                        } while (unidadeAtual != null);

                        nomesUnidades.Reverse();

                        viewModel.NomeUnidade = String.Join(" - ", nomesUnidades);
                    });
            Mapper.CreateMap<Patologia, PatologiaViewModel>();
            Mapper.CreateMap<Solucao, SolucaoViewModel>();
            Mapper.CreateMap<Anexo, AnexoViewModel>();
            Mapper.CreateMap<OcorrenciaAnexo, OcorrenciaAnexoViewModel>();
            Mapper.CreateMap<EmailFeedback, EmailFeedbackViewModel>();
        }
    }
}