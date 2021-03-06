﻿using AutoMapper;
using Concrety.API.ViewModels;
using Concrety.Core.Entities;
using Concrety.Core.Interfaces.Services;
using System.Collections.Generic;
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

        [Route("GetByEmpreendimento")]
        [HttpGet]
        public async Task<IEnumerable<EmpreendimentoDiarioViewModel>> ObterDoEmpreendimento(int idEmpreendimento)
        {
            var diarios = await _empreendimentoDiarioService.ObterDoEmpreendimentoAsync(idEmpreendimento).ConfigureAwait(false);
            return Mapper.Map<IEnumerable<EmpreendimentoDiario>, IEnumerable<EmpreendimentoDiarioViewModel>>(diarios);
        }

        [Route("")]
        [HttpPost]
        public async Task<IHttpActionResult> Criar(EmpreendimentoDiarioViewModel diarioViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var diario = Mapper.Map<EmpreendimentoDiarioViewModel, EmpreendimentoDiario>(diarioViewModel);

            var resultado = await _empreendimentoDiarioService.CriarAsync(diario).ConfigureAwait(false);

            IHttpActionResult errorResult = GetErrorResult(resultado);

            if (errorResult != null)
            {
                return errorResult;
            }

            diarioViewModel = Mapper.Map<EmpreendimentoDiario, EmpreendimentoDiarioViewModel>(diario);
            
            return Ok(diarioViewModel);
        }

        [Route("")]
        [HttpPut]
        public async Task<IHttpActionResult> Atualizar(EmpreendimentoDiarioViewModel diarioViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var diario = Mapper.Map<EmpreendimentoDiarioViewModel, EmpreendimentoDiario>(diarioViewModel);

            var resultado = await _empreendimentoDiarioService.AtualizarAsync(diario).ConfigureAwait(false);

            IHttpActionResult errorResult = GetErrorResult(resultado);

            if (errorResult != null)
            {
                return errorResult;
            }

            return Ok();
        }

        [Route("")]
        [HttpDelete]
        public async Task<IHttpActionResult> Excluir(int id)
        {
            var resultado = await _empreendimentoDiarioService.RemoverAsync(id).ConfigureAwait(false);

            IHttpActionResult errorResult = GetErrorResult(resultado);

            if (errorResult != null)
            {
                return errorResult;
            }

            return Ok();
        }
    }
}
