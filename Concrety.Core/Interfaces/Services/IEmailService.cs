using Concrety.Core.Entities;
using Concrety.Core.Entities.Results;
using System.Threading.Tasks;

namespace Concrety.Core.Interfaces.Services
{
    public interface IEmailService
    {
        Task<EntityResultBase> EnviarEmailFeedback(EmailFeedback emailFeedback);
        Task<EntityResultBase> EnviarEmailContato(EmailContato emailContato);
    }
}
