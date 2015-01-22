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
    [RoutePrefix("api/DiariosObra")]
    public class DiariosObraController : ApiControllerBase
    {

        private IEmpreendimentoDiarioService _empreendimentoDiarioService;

        public DiariosObraController(IEmpreendimentoDiarioService empreendimentoDiarioService)
        {
            _empreendimentoDiarioService = empreendimentoDiarioService;
        }

        [Route("Get")]
        public async Task<IEnumerable<EmpreendimentoDiarioViewModel>> Get(int idEmpreendimento)
        {
            var diarios = await _empreendimentoDiarioService.ObterDoEmpreendimento(idEmpreendimento);
            return Mapper.Map<IEnumerable<EmpreendimentoDiario>, IEnumerable<EmpreendimentoDiarioViewModel>>(diarios);
        }
        
    }
}
