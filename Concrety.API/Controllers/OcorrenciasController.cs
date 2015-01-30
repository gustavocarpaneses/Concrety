using AutoMapper;
using Concrety.API.ViewModels;
using Concrety.Core.Entities;
using Concrety.Core.Entities.Enumerators;
using Concrety.Core.Extensions;
using Concrety.Core.Interfaces.Services;
using System.Collections.Generic;
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

        [Route("PossiveisStatus")]
        public async Task<IEnumerable<StatusOcorrenciaViewModel>> GetPossiveisStatus()
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

        [Route("Create")]
        [HttpPost]
        public async Task<IHttpActionResult> Create(OcorrenciaViewModel ocorrenciaViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ocorrencia = Mapper.Map<OcorrenciaViewModel, Ocorrencia>(ocorrenciaViewModel);

            var resultado = await _ocorrenciaService.Criar(ocorrencia);

            IHttpActionResult errorResult = GetErrorResult(resultado);

            if (errorResult != null)
            {
                return errorResult;
            }

            return Ok();
        }

        [Route("Update")]
        [HttpPost]
        public async Task<IHttpActionResult> Update(OcorrenciaViewModel ocorrenciaViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ocorrencia = Mapper.Map<OcorrenciaViewModel, Ocorrencia>(ocorrenciaViewModel);

            var resultado = await _ocorrenciaService.Atualizar(ocorrencia);

            IHttpActionResult errorResult = GetErrorResult(resultado);

            if (errorResult != null)
            {
                return errorResult;
            }

            return Ok();
        }

        [Route("ObterDoServicoUnidade")]
        public async Task<IEnumerable<OcorrenciaViewModel>> GetDoServicoUnidade(int idServicoUnidade)
        {
            var ocorrencias = await _ocorrenciaService.ObterDoServicoUnidade(idServicoUnidade);
            return Mapper.Map<IEnumerable<Ocorrencia>, IEnumerable<OcorrenciaViewModel>>(ocorrencias);
        }
        
    }
}
