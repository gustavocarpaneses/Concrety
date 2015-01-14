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

        [Route("Acima")]
        public async Task<IEnumerable<NivelViewModel>> GetNiveisAcima(int idNivel)
        {
            var niveis = await _nivelService.ObterNiveisSuperiores(idNivel);
            return Mapper.Map<IEnumerable<Nivel>, IEnumerable<NivelViewModel>>(niveis);
        }

        [Route("Servico")]
        public async Task<IEnumerable<NivelViewModel>> GetNiveisServico(int idMacroServico)
        {
            var niveis = await _nivelService.ObterNiveisDeServico(idMacroServico);
            return Mapper.Map<IEnumerable<Nivel>, IEnumerable<NivelViewModel>>(niveis);
        }

        [Route("VerificacaoMaterial")]
        public async Task<IEnumerable<NivelViewModel>> GetNiveisVerificacaoMaterial(int idMacroServico)
        {
            var niveis = await _nivelService.ObterNiveisDeVerificacaoDeMaterial(idMacroServico);
            return Mapper.Map<IEnumerable<Nivel>, IEnumerable<NivelViewModel>>(niveis);
        }

    }
}
