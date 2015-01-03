using Concrety.Core.Interfaces.UnitOfWork;
using System;

namespace Concrety.Core.Interfaces.Services
{
    public interface IServiceBase : IDisposable
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
