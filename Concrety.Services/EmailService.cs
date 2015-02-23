using Concrety.Core.Entities;
using Concrety.Core.Entities.Results;
using Concrety.Core.Interfaces.Identity;
using Concrety.Core.Interfaces.Repositories;
using Concrety.Core.Interfaces.Services;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Concrety.Services
{
    public class EmailService : IEmailService
    {

        private IEmailRepository _emailRepository;
        private IApplicationUserManager _userManager;

        public EmailService(IEmailRepository emailRepository, IApplicationUserManager userManager)
        {
            _emailRepository = emailRepository;
            _userManager = userManager;
        }

        public async Task<EntityResultBase> EnviarEmailFeedback(EmailFeedback emailFeedback)
        {

            var usuario = await _userManager.FindByIdAsync(emailFeedback.IdUsuario);

            var mensagem = new MailMessage();

            mensagem.From = new MailAddress(usuario.Email, usuario.UserName);
            mensagem.To.Add("gcarpane@gmail.com,brnrocha@gmail.com,wilkiyoshi@hotmail.com,rodrigo@matconsupply.com.br");

            mensagem.Subject = "Feedback - Concrety";
            mensagem.Body = emailFeedback.Mensagem;
            mensagem.IsBodyHtml = true;

            await _emailRepository.EnviarAsync(mensagem);

            return new EntityResultBase(null, true);
        }
    }
}
