using Concrety.API.ViewModels;
using Concrety.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace Concrety.API.Controllers
{
    [Authorize]
    [RoutePrefix("api/Graficos")]
    public class GraficosController : ApiController
    {

        private IPatologiaService _patologiaService;

        public GraficosController(IPatologiaService patologiaService)
        {
            _patologiaService = patologiaService;
        }

        [Route("GetOfCondicoesClimaticas")]
        [HttpGet]
        public async Task<IEnumerable<PatologiaViewModel>> ObterDeCondicoesClimaticas(int idEmpreendimento)
        {
            throw new NotImplementedException();
            //var patologias = await _patologiaService.ObterDoItemVerificacaoAsync(idItemVerificacaoServico);
            //return Mapper.Map<IEnumerable<Patologia>, IEnumerable<PatologiaViewModel>>(patologias);
        }
                
    }
}
