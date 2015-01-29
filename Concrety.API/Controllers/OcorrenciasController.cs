using AutoMapper;
using Concrety.API.ViewModels;
using Concrety.Core.Entities;
using Concrety.Core.Entities.Enumerators;
using Concrety.Core.Extensions;
using Concrety.Core.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace Concrety.API.Controllers
{
    [Authorize]
    [RoutePrefix("api/Ocorrencias")]
    public class OcorrenciasController : ApiController
    {

        private IOcorrenciaService _ocorrenciaService;

        public OcorrenciasController(IOcorrenciaService ocorrenciaService)
        {
            _ocorrenciaService = ocorrenciaService;
        }

        [Route("PossiveisStatus")]
        public async Task<IEnumerable<StatusOcorrenciaViewModel>> GetPossiveisStatus()
        {
            return await Task.Factory.StartNew(() =>
            {
                return new List<StatusOcorrenciaViewModel>
                {
                    new StatusOcorrenciaViewModel
                    {
                        Id = (int)StatusOcorrencia.Pendente,
                        Nome = StatusOcorrencia.Pendente.GetDescription()
                    },
                    new StatusOcorrenciaViewModel
                    {
                        Id = (int)StatusOcorrencia.Concluida,
                        Nome = StatusOcorrencia.Concluida.GetDescription()
                    }
                };
            });
        }
        
    }
}
