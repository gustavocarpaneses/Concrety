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
    [RoutePrefix("api/Niveis")]
    public class NiveisController : ApiController
    {

        private INivelService _nivelService;

        public NiveisController(INivelService nivelService)
        {
            _nivelService = nivelService;
        }

        [Route("GetAcima")]
        [HttpGet]
        public async Task<IEnumerable<NivelViewModel>> ObterAcima(int idNivel)
        {
            var niveis = await _nivelService.ObterNiveisSuperioresAsync(idNivel).ConfigureAwait(false);
            return Mapper.Map<IEnumerable<Nivel>, IEnumerable<NivelViewModel>>(niveis);
        }

        [Route("GetOfServico")]
        [HttpGet]
        public async Task<IEnumerable<NivelViewModel>> ObterDeServico(int idMacroServico)
        {
            var niveis = await _nivelService.ObterNiveisDeServicoAsync(idMacroServico).ConfigureAwait(false);
            return Mapper.Map<IEnumerable<Nivel>, IEnumerable<NivelViewModel>>(niveis);
        }

        [Route("GetOfMaterial")]
        [HttpGet]
        public async Task<IEnumerable<NivelViewModel>> ObterDeMaterial(int idMacroServico)
        {
            var niveis = await _nivelService.ObterNiveisDeVerificacaoDeMaterialAsync(idMacroServico).ConfigureAwait(false);
            return Mapper.Map<IEnumerable<Nivel>, IEnumerable<NivelViewModel>>(niveis);
        }

    }
}
