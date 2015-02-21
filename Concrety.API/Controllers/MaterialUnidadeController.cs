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
        private IFornecedorService _fornecedorService;

        public MaterialUnidadeController(IFichaVerificacaoMaterialUnidadeService fvmUnidadeService, IFornecedorService fornecedorService)
        {
            _fvmUnidadeService = fvmUnidadeService;
            _fornecedorService = fornecedorService;
        }

        [Route("Unidade")]
        public async Task<IEnumerable<FichaVerificacaoMaterialUnidadeViewModel>> GetDaUnidade(int idUnidade)
        {
            var fvms = await _fvmUnidadeService.ObterDaUnidade(idUnidade);
            return Mapper.Map<IEnumerable<FichaVerificacaoMaterialUnidade>, IEnumerable<FichaVerificacaoMaterialUnidadeViewModel>>(fvms);
        }

        [Route("CriarItens")]
        [HttpGet]
        public async Task<IEnumerable<ItemVerificacaoMaterialUnidadeViewModel>> CriarItens(int idFichaVerificacaoMaterial)
        {
            var itens = await _fvmUnidadeService.CriarItens(idFichaVerificacaoMaterial);
            return Mapper.Map<IEnumerable<ItemVerificacaoMaterialUnidade>, IEnumerable<ItemVerificacaoMaterialUnidadeViewModel>>(itens);
        }

        [Route("Itens")]
        public async Task<IEnumerable<ItemVerificacaoMaterialUnidadeViewModel>> GetItens(int idFichaVerificacaoMaterialUnidade)
        {
            var itens = await _fvmUnidadeService.ObterItens(idFichaVerificacaoMaterialUnidade);
            return Mapper.Map<IEnumerable<ItemVerificacaoMaterialUnidade>, IEnumerable<ItemVerificacaoMaterialUnidadeViewModel>>(itens);
        }

        [Route("Create")]
        [HttpPost]
        public async Task<IHttpActionResult> Create(FichaVerificacaoMaterialUnidadeViewModel fvmViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await AssociarNovoFornecedor(fvmViewModel);

            var fvm = Mapper.Map<FichaVerificacaoMaterialUnidadeViewModel, FichaVerificacaoMaterialUnidade>(fvmViewModel);

            var resultado = await _fvmUnidadeService.Criar(fvm);

            IHttpActionResult errorResult = GetErrorResult(resultado);

            if (errorResult != null)
            {
                return errorResult;
            }

            fvmViewModel = Mapper.Map<FichaVerificacaoMaterialUnidade, FichaVerificacaoMaterialUnidadeViewModel>(fvm);

            return Ok(fvmViewModel);
        }

        [Route("Update")]
        [HttpPost]
        public async Task<IHttpActionResult> Update(FichaVerificacaoMaterialUnidadeViewModel fvmViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await AssociarNovoFornecedor(fvmViewModel);

            var fvm = Mapper.Map<FichaVerificacaoMaterialUnidadeViewModel, FichaVerificacaoMaterialUnidade>(fvmViewModel);

            var resultado = await _fvmUnidadeService.Atualizar(fvm);

            IHttpActionResult errorResult = GetErrorResult(resultado);

            if (errorResult != null)
            {
                return errorResult;
            }

            return Ok();
        }
        
        private async Task AssociarNovoFornecedor(FichaVerificacaoMaterialUnidadeViewModel fvmViewModel)
        {
            if (fvmViewModel.IdFornecedor == 0)
            {
                var fornecedor = new Fornecedor
                {
                    Nome = fvmViewModel.NomeNovoFornecedor
                };
                await _fornecedorService.AddAsync(fornecedor);
                fvmViewModel.IdFornecedor = fornecedor.Id;
            }
        }

    }
}
