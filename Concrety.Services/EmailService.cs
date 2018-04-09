using Concrety.Core.Entities;
using Concrety.Core.Entities.Results;
using Concrety.Core.Interfaces.Identity;
using Concrety.Core.Interfaces.Repositories;
using Concrety.Core.Interfaces.Services;
using System;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Concrety.Services
{
    public class EmailService : IEmailService
    {

        private string destinatarios = "contato@concrety.com.br,gustavo.carpaneses@concrety.com.br,bruno.rocha@concrety.com.br,rodrigo@concrety.com.br,william.taniguchi@concrety.com.br";

        private IEmailRepository _emailRepository;
        private IApplicationUserManager _userManager;

        public EmailService(IEmailRepository emailRepository, IApplicationUserManager userManager)
        {
            _emailRepository = emailRepository;
            _userManager = userManager;
        }

        public async Task<EntityResultBase> EnviarEmailFeedback(EmailFeedback emailFeedback)
        {

            var usuario = await _userManager.FindByIdAsync(emailFeedback.IdUsuario).ConfigureAwait(false);

            var mensagem = new MailMessage();

            mensagem.From = new MailAddress(usuario.Email, usuario.UserName);
            mensagem.To.Add(destinatarios);

            mensagem.Subject = "Feedback - Concrety";
            mensagem.Body = emailFeedback.Mensagem;
            mensagem.IsBodyHtml = true;

            await _emailRepository.EnviarAsync(mensagem).ConfigureAwait(false);

            return new EntityResultBase(null, true);
        }

        public async Task<EntityResultBase> EnviarEmailContato(EmailContato emailContato)
        {

            var mensagem = new MailMessage();

            mensagem.From = new MailAddress(emailContato.Email, emailContato.Nome);
            mensagem.To.Add(destinatarios);

            mensagem.Subject = "Contato - Concrety";
            mensagem.Body = String.Format(
                "Nome: {0} - Telefone {1} - E-mail {2} - Mensagem: {3}{4}", 
                emailContato.Nome,
                emailContato.Telefone,
                emailContato.Email,
                Environment.NewLine,
                emailContato.Mensagem);

            mensagem.IsBodyHtml = true;

            await _emailRepository.EnviarAsync(mensagem).ConfigureAwait(false);

            return new EntityResultBase(null, true);
        }
    }
}
