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
    [RoutePrefix("api/Fornecedores")]
    public class FornecedoresController : ApiControllerBase
    {

        private IFornecedorService _fornecedorService;

        public FornecedoresController(IFornecedorService fornecedorService)
        {
            _fornecedorService = fornecedorService;
        }

        [Route("Get")]
        public async Task<IEnumerable<FornecedorViewModel>> Get()
        {
            var fornecedores = await _fornecedorService.Obter();
            return Mapper.Map<IEnumerable<Fornecedor>, IEnumerable<FornecedorViewModel>>(fornecedores);
        }
    }
}
