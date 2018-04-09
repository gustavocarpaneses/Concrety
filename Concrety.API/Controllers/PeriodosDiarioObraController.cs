using AutoMapper;
using Concrety.API.ViewModels;
using Concrety.Core.Entities;
using Concrety.Core.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace Concrety.API.Controllers
{
    [Authorize]
    [RoutePrefix("api/PeriodosDiarioObra")]
    public class PeriodosDiarioObraController : ApiControllerBase
    {
        private IEmpreendimentoDiarioPeriodoService _empreendimentoDiarioPeriodoService;

        public PeriodosDiarioObraController(IEmpreendimentoDiarioPeriodoService empreendimentoDiarioPeriodoService)
        {
            _empreendimentoDiarioPeriodoService = empreendimentoDiarioPeriodoService;
        }
        
        [Route("GetByEmpreendimento")]
        [HttpGet]
        public async Task<IEnumerable<EmpreendimentoDiarioPeriodoViewModel>> ObterPeriodosDoEmpreendimento(int idEmpreendimento)
        {
            var periodos = await _empreendimentoDiarioPeriodoService.ObterPeriodosDoEmpreendimentoAsync(idEmpreendimento).ConfigureAwait(false);
            return Mapper.Map<IEnumerable<EmpreendimentoDiarioPeriodo>, IEnumerable<EmpreendimentoDiarioPeriodoViewModel>>(periodos);
        }
    }
}
