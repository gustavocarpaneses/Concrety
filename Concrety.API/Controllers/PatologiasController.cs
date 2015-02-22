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
    [RoutePrefix("api/Patologias")]
    public class PatologiasController : ApiController
    {

        private IPatologiaService _patologiaService;

        public PatologiasController(IPatologiaService patologiaService)
        {
            _patologiaService = patologiaService;
        }

        [Route("GetByItemVerificacaoServico")]
        [HttpGet]
        public async Task<IEnumerable<PatologiaViewModel>> ObterDoItemVerificacaoServico(int idItemVerificacaoServico)
        {
            var patologias = await _patologiaService.ObterDoItemVerificacao(idItemVerificacaoServico);
            return Mapper.Map<IEnumerable<Patologia>, IEnumerable<PatologiaViewModel>>(patologias);
        }
                
    }
}
