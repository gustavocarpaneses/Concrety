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
    [RoutePrefix("api/MaterialUnidade")]
    public class MaterialUnidadeController : ApiControllerBase
    {

        private IFichaVerificacaoMaterialUnidadeService _fvmUnidadeService;

        public MaterialUnidadeController(IFichaVerificacaoMaterialUnidadeService fvmUnidadeService)
        {
            _fvmUnidadeService = fvmUnidadeService;
        }

        [Route("Unidade")]
        public async Task<IEnumerable<FichaVerificacaoMaterialUnidadeViewModel>> GetDaUnidade(int idUnidade)
        {
            var fvms = await _fvmUnidadeService.ObterDaUnidade(idUnidade);
            return Mapper.Map<IEnumerable<FichaVerificacaoMaterialUnidade>, IEnumerable<FichaVerificacaoMaterialUnidadeViewModel>>(fvms);
        }

    }
}
