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

        [Route("GetByUnidade")]
        [HttpGet]
        public async Task<IEnumerable<FichaVerificacaoMaterialUnidadeViewModel>> ObterDaUnidade(int idUnidade)
        {
            var fvms = await _fvmUnidadeService.ObterDaUnidadeAsync(idUnidade);
            return Mapper.Map<IEnumerable<FichaVerificacaoMaterialUnidade>, IEnumerable<FichaVerificacaoMaterialUnidadeViewModel>>(fvms);
        }

        [Route("GetNewItens")]
        [HttpGet]
        public async Task<IEnumerable<ItemVerificacaoMaterialUnidadeViewModel>> ObterNovosItens(int idFichaVerificacaoMaterial)
        {
            var itens = await _fvmUnidadeService.CriarItensAsync(idFichaVerificacaoMaterial);
            return Mapper.Map<IEnumerable<ItemVerificacaoMaterialUnidade>, IEnumerable<ItemVerificacaoMaterialUnidadeViewModel>>(itens);
        }

        [Route("GetItens")]
        [HttpGet]
        public async Task<IEnumerable<ItemVerificacaoMaterialUnidadeViewModel>> ObterItens(int idFichaVerificacaoMaterialUnidade)
        {
            var itens = await _fvmUnidadeService.ObterItensAsync(idFichaVerificacaoMaterialUnidade);
            return Mapper.Map<IEnumerable<ItemVerificacaoMaterialUnidade>, IEnumerable<ItemVerificacaoMaterialUnidadeViewModel>>(itens);
        }

        [Route("")]
        [HttpPost]
        public async Task<IHttpActionResult> Criar(FichaVerificacaoMaterialUnidadeViewModel fvmViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await AssociarNovoFornecedor(fvmViewModel);

            var fvm = Mapper.Map<FichaVerificacaoMaterialUnidadeViewModel, FichaVerificacaoMaterialUnidade>(fvmViewModel);

            var resultado = await _fvmUnidadeService.CriarAsync(fvm);

            IHttpActionResult errorResult = GetErrorResult(resultado);

            if (errorResult != null)
            {
                return errorResult;
            }

            fvmViewModel = Mapper.Map<FichaVerificacaoMaterialUnidade, FichaVerificacaoMaterialUnidadeViewModel>(fvm);

            return Ok(fvmViewModel);
        }

        [Route("")]
        [HttpPut]
        public async Task<IHttpActionResult> Atualizar(FichaVerificacaoMaterialUnidadeViewModel fvmViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await AssociarNovoFornecedor(fvmViewModel);

            var fvm = Mapper.Map<FichaVerificacaoMaterialUnidadeViewModel, FichaVerificacaoMaterialUnidade>(fvmViewModel);

            var resultado = await _fvmUnidadeService.AtualizarAsync(fvm);

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
                await _fornecedorService.CriarAsync(fornecedor);
                fvmViewModel.IdFornecedor = fornecedor.Id;
            }
        }

    }
}
