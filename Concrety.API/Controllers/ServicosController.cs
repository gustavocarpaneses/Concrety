using AutoMapper;
using Concrety.API.ViewModels;
using Concrety.Core.Entities;
using Concrety.Core.Entities.Enumerators;
using Concrety.Core.Extensions;
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

        [Route("GetByUnidade")]
        [HttpGet]
        public async Task<IEnumerable<ServicoViewModel>> ObterDaUnidade(int idUnidade, int idNivel)
        {
            var servicos = await _servicoService.ObterDaUnidadeAsync(idUnidade, idNivel);
            return Mapper.Map<IEnumerable<Servico>, IEnumerable<ServicoViewModel>>(servicos);
        }

        [Route("GetPossiveisStatus")]
        [HttpGet]
        public async Task<IEnumerable<StatusServicoViewModel>> ObterPossiveisStatus()
        {
            return await Task.Factory.StartNew(() =>
            {
                return new List<StatusServicoViewModel>
                {
                    new StatusServicoViewModel
                    {
                        Id = (int)StatusServicoUnidade.NaoIniciada,
                        Nome = StatusServicoUnidade.NaoIniciada.GetDescription()
                    },
                    new StatusServicoViewModel
                    {
                        Id = (int)StatusServicoUnidade.EmAndamento,
                        Nome = StatusServicoUnidade.EmAndamento.GetDescription()
                    },
                    new StatusServicoViewModel
                    {
                        Id = (int)StatusServicoUnidade.Concluida,
                        Nome = StatusServicoUnidade.Concluida.GetDescription()
                    }
                };
            });
        }

        [Route("GetPossiveisResultados")]
        [HttpGet]
        public async Task<IEnumerable<StatusResultadoViewModel>> ObterPossiveisResultados()
        {
            return await Task.Factory.StartNew(() =>
            {
                return new List<StatusResultadoViewModel>
                {
                    new StatusResultadoViewModel
                    {
                        Id = (int)ResultadoServicoUnidade.Aprovado,
                        Nome = ResultadoServicoUnidade.Aprovado.GetDescription()
                    },
                    new StatusResultadoViewModel
                    {
                        Id = (int)ResultadoServicoUnidade.Reprovado,
                        Nome = ResultadoServicoUnidade.Reprovado.GetDescription()
                    },
                    new StatusResultadoViewModel
                    {
                        Id = (int)ResultadoServicoUnidade.ReinspecionadoAprovado,
                        Nome = ResultadoServicoUnidade.ReinspecionadoAprovado.GetDescription()
                    }
                };
            });
        }

    }
}
