using AutoMapper;
using Concrety.API.ViewModels;
using Concrety.Core.Entities;
using Concrety.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Concrety.API.Controllers
{
    [Authorize]
    [RoutePrefix("api/CondicoesClimaticas")]
    public class CondicoesClimaticasController : ApiControllerBase
    {

        private ICondicaoClimaticaService _condicaoClimaticaService;

        public CondicoesClimaticasController(ICondicaoClimaticaService condicaoClimaticaService)
        {
            _condicaoClimaticaService = condicaoClimaticaService;
        }

        [Route("Get")]
        [HttpGet]
        public async Task<IEnumerable<CondicaoClimaticaViewModel>> ObterTodos()
        {
            var condicoes = await _condicaoClimaticaService.ObterTodosAsync();
            return Mapper.Map<IEnumerable<CondicaoClimatica>, IEnumerable<CondicaoClimaticaViewModel>>(condicoes);
        }
    }
}
