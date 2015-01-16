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
    [RoutePrefix("api/ServicoUnidade")]
    public class ServicoUnidadeController : ApiController
    {

        private IServicoUnidadeService _servicoUnidadeService;

        public ServicoUnidadeController(IServicoUnidadeService servicoUnidadeService)
        {
            _servicoUnidadeService = servicoUnidadeService;
        }

        [Route("Get")]
        public async Task<ServicoUnidadeViewModel> Get(int idUnidade, int idServico)
        {
            var servicoUnidade = await _servicoUnidadeService.Obter(idUnidade, idServico);
            var teste = Mapper.Map<ServicoUnidade, ServicoUnidadeViewModel>(servicoUnidade);
            return teste;
        }

    }
}
