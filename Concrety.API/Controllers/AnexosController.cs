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
    [RoutePrefix("api/Anexos")]
    public class AnexosController : ApiControllerBase
    {

        private IAnexoService _anexoService;

        public AnexosController(IAnexoService anexoService)
        {
            _anexoService = anexoService;
        }

        [Route("Create")]
        [HttpPost]
        public async Task<IHttpActionResult> Create(AnexoViewModel anexoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var anexo = Mapper.Map<AnexoViewModel, Anexo>(anexoViewModel);

            var resultado = await _anexoService.Criar(anexo);

            IHttpActionResult errorResult = GetErrorResult(resultado);

            if (errorResult != null)
            {
                return errorResult;
            }

            anexo.Conteudo = null;

            anexoViewModel = Mapper.Map<Anexo, AnexoViewModel>(anexo);

            return Ok(anexoViewModel);
        }

        [Route("Delete")]
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(AnexoViewModel anexoViewModel)
        {
            var anexo = Mapper.Map<AnexoViewModel, Anexo>(anexoViewModel);

            await _anexoService.RemoveAsync(anexo);

            return Ok();
        }
        
    }
}
