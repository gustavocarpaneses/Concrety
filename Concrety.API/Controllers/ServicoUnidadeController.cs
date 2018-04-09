using AutoMapper;
using Concrety.API.ViewModels;
using Concrety.Core.Entities;
using Concrety.Core.Interfaces.Services;
using Concrety.Core.Messages;
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
    public class ServicoUnidadeController : ApiControllerBase
    {

        private IServicoUnidadeService _servicoUnidadeService;

        public ServicoUnidadeController(IServicoUnidadeService servicoUnidadeService)
        {
            _servicoUnidadeService = servicoUnidadeService;
        }

        [Route("GetByUnidadeServico")]
        [HttpGet]
        public async Task<ServicoUnidadeViewModel> ObterDaUnidadeServico(int idUnidade, int idServico)
        {
            var servicoUnidade = await _servicoUnidadeService.ObterAsync(idUnidade, idServico).ConfigureAwait(false);
            return Mapper.Map<ServicoUnidade, ServicoUnidadeViewModel>(servicoUnidade);
        }

        [Route("")]
        [HttpPut]
        public async Task<IHttpActionResult> Atualizar(ServicoUnidadeViewModel servicoUnidadeViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var servicoUnidade = Mapper.Map<ServicoUnidadeViewModel, ServicoUnidade>(servicoUnidadeViewModel);

            var resultado = await _servicoUnidadeService.Salvar(servicoUnidade).ConfigureAwait(false);

            IHttpActionResult errorResult = GetErrorResult(resultado);

            if (errorResult != null)
            {
                return errorResult;
            }

            return Ok(new
            {
                resultado.ServicoConcluido
            });
        }

    }
}
