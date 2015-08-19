using Concrety.Core.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace Concrety.API.Controllers
{
    [Authorize]
    [RoutePrefix("api/Relatorios")]
    public class RelatoriosController : ApiController
    {

        private IRelatorioService _relatorioService;

        public RelatoriosController(IRelatorioService relatorioService)
        {
            _relatorioService = relatorioService;
        }

        [Route("GetById")]
        [HttpGet]
        public async Task<IEnumerable<object[]>> Obter(int id, [FromUri] params object[] p)
        {
            return await _relatorioService.ObterAsync(id, p);
        }
                
    }
}
