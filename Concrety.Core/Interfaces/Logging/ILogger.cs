using System;

namespace Concrety.Core.Interfaces.Logging
{
    public interface ILogger
    {
        void Log(string message);
        void Log(Exception ex);
    }
}
