using System;

namespace Portal.Common.Logging
{
    public interface ILogProvider
    {
        void Error(string message);
        void Error(string message, Exception exception);

        void Info(string message);
    }
}
