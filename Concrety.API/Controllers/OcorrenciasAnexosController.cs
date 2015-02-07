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
    [RoutePrefix("api/OcorrenciasAnexos")]
    public class OcorrenciasAnexosController : ApiControllerBase
    {

        private IOcorrenciaAnexoService _ocorrenciaAnexoService;

        public OcorrenciasAnexosController(IOcorrenciaAnexoService ocorrenciaAnexoService)
        {
            _ocorrenciaAnexoService = ocorrenciaAnexoService;
        }

        [Route("Remover")]
        [HttpPost]
        public async Task<IHttpActionResult> Remover(OcorrenciaAnexoViewModel ocorrenciaAnexoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ocorrenciaAnexo = Mapper.Map<OcorrenciaAnexoViewModel, OcorrenciaAnexo>(ocorrenciaAnexoViewModel);

            var resultado = await _ocorrenciaAnexoService.RemoverAnexo(ocorrenciaAnexo);

            IHttpActionResult errorResult = GetErrorResult(resultado);

            if (errorResult != null)
            {
                return errorResult;
            }

            return Ok();
        }
                
    }
}
