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
    [RoutePrefix("api/Servicos")]
    public class ServicosController : ApiController
    {

        private IServicoService _servicoService;

        public ServicosController(IServicoService servicoService)
        {
            _servicoService = servicoService;
        }

        [Route("Unidade")]
        public async Task<IEnumerable<ServicoViewModel>> GetDaUnidade(int idUnidade, int idNivel)
        {
            var servicos = await _servicoService.ObterDaUnidade(idUnidade, idNivel);
            return Mapper.Map<IEnumerable<Servico>, IEnumerable<ServicoViewModel>>(servicos);
        }

    }
}
