using AutoMapper;
using Concrety.API.ViewModels;
using Concrety.Core.Entities;
using Concrety.Core.Interfaces.Services;
using System.Threading.Tasks;
using System.Web.Http;

namespace Concrety.API.Controllers
{

    [RoutePrefix("api/Email")]
    public class EmailController : ApiControllerBase
    {

        private IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [Authorize]
        [Route("PostFeedback")]
        [HttpPost]
        public async Task<IHttpActionResult> EnviarFeedback(EmailFeedbackViewModel emailFeedbackViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var emailFeedback = Mapper.Map<EmailFeedbackViewModel, EmailFeedback>(emailFeedbackViewModel);

            emailFeedback.IdUsuario = User.Identity.GetUserId();

            var resultado = await _emailService.EnviarEmailFeedback(emailFeedback).ConfigureAwait(false);

            IHttpActionResult errorResult = GetErrorResult(resultado);

            if (errorResult != null)
            {
                return errorResult;
            }

            return Ok();
        }

        [AllowAnonymous]
        [Route("PostContato")]
        [HttpPost]
        public async Task<IHttpActionResult> EnviarContato(EmailContatoViewModel emailContatoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var emailContato = Mapper.Map<EmailContatoViewModel, EmailContato>(emailContatoViewModel);
            
            var resultado = await _emailService.EnviarEmailContato(emailContato).ConfigureAwait(false);

            IHttpActionResult errorResult = GetErrorResult(resultado);

            if (errorResult != null)
            {
                return errorResult;
            }
            
            return Ok();
        }

    }
}
