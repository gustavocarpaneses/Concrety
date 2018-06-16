using AutoMapper;
using Concrety.API.ViewModels;
using Concrety.Core.Entities;
using Concrety.Core.Entities.Identity;
using Concrety.Core.Entities.Results;
using Concrety.Core.Interfaces.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Concrety.API.Controllers
{
    [RoutePrefix("api/Account")]
    public class AccountController : ApiControllerBase
    {

        private readonly IApplicationUserManager _userManager;

        public AccountController(IApplicationUserManager userManager)
        {
            _userManager = userManager;
        }

        // POST api/Account/Register
        [AllowAnonymous]
        [Route("Register")]
        public async Task<IHttpActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password).ConfigureAwait(false);

            IHttpActionResult errorResult = GetErrorResult(result);

            if (errorResult != null)
            {
                return errorResult;
            }

            return Ok();
        }

        [Authorize]
        [Route("GetEmpreendimentos")]
        [HttpGet]
        public async Task<IEnumerable<EmpreendimentoViewModel>> ObterEmpreendimentos()
        {
            var user = await _userManager.FindByIdAsync(User.Identity.GetUserId()).ConfigureAwait(false);
            return Mapper.Map<IEnumerable<Empreendimento>, IEnumerable<EmpreendimentoViewModel>>(user.Empreendimentos);
        }
        
    }
}
