
using System;

namespace Telemetry
{
    public interface IScheduler
    {
        void Start();
        void Stop();
        event EventHandler Elapsed;
    }
}
