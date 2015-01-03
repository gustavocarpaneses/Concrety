using Concrety.Domain.Interfaces.UnitOfWork;
using System;

namespace Concrety.Domain.Interfaces.Services
{
    public interface IServiceBase : IDisposable
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
