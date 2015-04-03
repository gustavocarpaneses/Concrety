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

        private IOcorrenciaService _ocorrenciaService;

        public OcorrenciasController(IOcorrenciaService ocorrenciaService)
        {
            _ocorrenciaService = ocorrenciaService;
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

            var ocorrencia = Mapper.Map<OcorrenciaViewModel, Ocorrencia>(ocorrenciaViewModel);

            var resultado = await _ocorrenciaService.CriarAsync(ocorrencia);

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

            var ocorrencia = Mapper.Map<OcorrenciaViewModel, Ocorrencia>(ocorrenciaViewModel);

            var resultado = await _ocorrenciaService.AtualizarAsync(ocorrencia);

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
            var resultado = await _ocorrenciaService.RemoverAsync(id);

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
            var ocorrencias = await _ocorrenciaService.ObterDoServicoUnidadeAsync(idServicoUnidade);
            return Mapper.Map<IEnumerable<Ocorrencia>, IEnumerable<OcorrenciaViewModel>>(ocorrencias);
        }

        [Route("GetPendentes")]
        [HttpGet]
        public async Task<IEnumerable<OcorrenciaViewModel>> ObterPendentes(int idMacroServico)
        {
            var ocorrencias = await _ocorrenciaService.ObterPendentesAsync(idMacroServico);
            return Mapper.Map<IEnumerable<Ocorrencia>, IEnumerable<OcorrenciaViewModel>>(ocorrencias);
        }
        
    }
}
