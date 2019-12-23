using System;
using System.Collections.Generic;
using System.Text;

namespace Logging.Providers
{
    public interface ICorrelationIdAccessor
    {
        string Get();
        void Set(string correlationId);
    }
}
