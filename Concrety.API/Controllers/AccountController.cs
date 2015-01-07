using AutoMapper;
using Concrety.API.ViewModels;
using Concrety.Core.Entities;
using Concrety.Core.Entities.Identity;
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
    public class AccountController : ApiController
    {

        private IApplicationUserManager _userManager;

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
            var result = await _userManager.CreateAsync(user, model.Password);

            IHttpActionResult errorResult = GetErrorResult(result);

            if (errorResult != null)
            {
                return errorResult;
            }

            return Ok();
        }

        [Authorize]
        [Route("Empreendimentos")]
        public async Task<IEnumerable<EmpreendimentoViewModel>> GetEmpreendimentos()
        {
            var user = await _userManager.FindByIdAsync(User.Identity.GetUserId());
            return Mapper.Map<IEnumerable<Empreendimento>, IEnumerable<EmpreendimentoViewModel>>(user.Empreendimentos);
        }
        
        private IHttpActionResult GetErrorResult(ApplicationIdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }

    }
}
