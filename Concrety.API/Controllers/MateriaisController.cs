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
    [RoutePrefix("api/Materiais")]
    public class MateriaisController : ApiControllerBase
    {

        private IFichaVerificacaoMaterialService _fvmService;

        public MateriaisController(IFichaVerificacaoMaterialService fvmService)
        {
            _fvmService = fvmService;
        }

        [Route("Nivel")]
        public async Task<IEnumerable<FichaVerificacaoMaterialViewModel>> GetDoNivel(int idNivel)
        {
            var fvms = await _fvmService.ObterDoNivel(idNivel);
            return Mapper.Map<IEnumerable<FichaVerificacaoMaterial>, IEnumerable<FichaVerificacaoMaterialViewModel>>(fvms);
        }
    }
}
