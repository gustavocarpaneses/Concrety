using System.Net.Mail;
using System.Threading.Tasks;
namespace Concrety.Core.Interfaces.Repositories
{
    public interface IEmailRepository
    {
        Task EnviarAsync(MailMessage mensagem);
    }
}
