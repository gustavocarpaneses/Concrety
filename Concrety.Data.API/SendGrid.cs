using SendGrid;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
namespace Concrety.Data.API
{
    public class SendGrid
    {
        public async Task EnviarEmailAsync(MailMessage mensagem)
        {
            var sendGridMessage = new SendGridMessage();

            sendGridMessage.To = mensagem.To.ToArray();
            sendGridMessage.From = mensagem.From;
            sendGridMessage.Subject = mensagem.Subject;
            sendGridMessage.Text = mensagem.Body;

            var credentials = new NetworkCredential(
                ConfigurationManager.AppSettings["SendGrid.Username"],
                ConfigurationManager.AppSettings["SendGrid.Password"]);

            var transportWeb = new Web(credentials);
            
            await transportWeb.DeliverAsync(sendGridMessage).ConfigureAwait(false);

            return;            
        }
    }
}
