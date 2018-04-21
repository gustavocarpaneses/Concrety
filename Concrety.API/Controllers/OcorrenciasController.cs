using AutoMapper;
using Concrety.API.ViewModels;
using Concrety.Core.Entities;
using Concrety.Core.Entities.Enumerators;
using Concrety.Core.Extensions;
using Concrety.Core.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace Concrety.API.Controllers
{
    [Authorize]
    [RoutePrefix("api/Ocorrencias")]
    public class OcorrenciasController : ApiControllerBase
    {
        private readonly IOcorrenciaService _ocorrenciaService;
        private readonly IPatologiaService _patologiaService;

        public OcorrenciasController(
            IOcorrenciaService ocorrenciaService,
            IPatologiaService patologiaService)
        {
            _ocorrenciaService = ocorrenciaService;
            _patologiaService = patologiaService;
        }

        [Route("GetPossiveisStatus")]
        [HttpGet]
        public async Task<IEnumerable<StatusOcorrenciaViewModel>> ObterPossiveisStatus()
        {
            return await Task.Factory.StartNew(() =>
            {
                return new List<StatusOcorrenciaViewModel>
                {
                    new StatusOcorrenciaViewModel
                    {
                        Id = (int)StatusOcorrencia.Pendente,
                        Nome = StatusOcorrencia.Pendente.GetDescription()
                    },
                    new StatusOcorrenciaViewModel
                    {
                        Id = (int)StatusOcorrencia.Concluida,
                        Nome = StatusOcorrencia.Concluida.GetDescription()
                    }
                };
            });
        }

        [Route("")]
        [HttpPost]
        public async Task<IHttpActionResult> Criar(OcorrenciaViewModel ocorrenciaViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await AssociarNovaPatologiaAsync(ocorrenciaViewModel).ConfigureAwait(false);

            var ocorrencia = Mapper.Map<OcorrenciaViewModel, Ocorrencia>(ocorrenciaViewModel);

            var resultado = await _ocorrenciaService.CriarAsync(ocorrencia).ConfigureAwait(false);

            IHttpActionResult errorResult = GetErrorResult(resultado);

            if (errorResult != null)
            {
                return errorResult;
            }

            return Ok();
        }

        [Route("")]
        [HttpPut]
        public async Task<IHttpActionResult> Atualizar(OcorrenciaViewModel ocorrenciaViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await AssociarNovaPatologiaAsync(ocorrenciaViewModel).ConfigureAwait(false);

            var ocorrencia = Mapper.Map<OcorrenciaViewModel, Ocorrencia>(ocorrenciaViewModel);

            var resultado = await _ocorrenciaService.AtualizarAsync(ocorrencia).ConfigureAwait(false);

            IHttpActionResult errorResult = GetErrorResult(resultado);

            if (errorResult != null)
            {
                return errorResult;
            }

            return Ok();
        }

        [Route("")]
        [HttpDelete]
        public async Task<IHttpActionResult> Excluir(int id)
        {
            var resultado = await _ocorrenciaService.RemoverAsync(id).ConfigureAwait(false);

            IHttpActionResult errorResult = GetErrorResult(resultado);

            if (errorResult != null)
            {
                return errorResult;
            }

            return Ok();
        }

        [Route("GetByServicoUnidade")]
        [HttpGet]
        public async Task<IEnumerable<OcorrenciaViewModel>> ObterDoServicoUnidade(int idServicoUnidade)
        {
            var ocorrencias = await _ocorrenciaService.ObterDoServicoUnidadeAsync(idServicoUnidade).ConfigureAwait(false);
            return Mapper.Map<IEnumerable<Ocorrencia>, IEnumerable<OcorrenciaViewModel>>(ocorrencias);
        }

        [Route("GetPendentes")]
        [HttpGet]
        public async Task<IEnumerable<OcorrenciaViewModel>> ObterPendentes(int idMacroServico)
        {
            var ocorrencias = await _ocorrenciaService.ObterPendentesAsync(idMacroServico).ConfigureAwait(false);
            return Mapper.Map<IEnumerable<Ocorrencia>, IEnumerable<OcorrenciaViewModel>>(ocorrencias);
        }

        private async Task AssociarNovaPatologiaAsync(OcorrenciaViewModel ocorrenciaViewModel)
        {
            if (ocorrenciaViewModel.IdPatologia == 0)
            {
                var patologia = new Patologia
                {
                    Nome = ocorrenciaViewModel.NomePatologia,
                    IdItemVerificacaoServico = ocorrenciaViewModel.ItemVerificacao.IdItemVerificacaoServico
                };
                await _patologiaService.CriarAsync(patologia).ConfigureAwait(false);
                ocorrenciaViewModel.IdPatologia = patologia.Id;
            }
        }
    }
}