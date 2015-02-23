using Concrety.Core.Interfaces.Repositories;
using Concrety.Data.API;
using System.Net.Mail;
using System.Threading.Tasks;
namespace Concrety.Data.Repositories
{
    public class EmailRepository : IEmailRepository
    {
        public async Task EnviarAsync(MailMessage mensagem)
        {
            await new SendGrid().EnviarEmailAsync(mensagem);
            return;
        }
    }
}
