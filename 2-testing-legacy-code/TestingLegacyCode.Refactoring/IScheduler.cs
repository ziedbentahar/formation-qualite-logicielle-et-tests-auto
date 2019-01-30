
using System;

namespace Telemetry.Services
{
    public interface IScheduler
    {
        void Start();
        void Stop();
        event EventHandler Elapsed;
    }

   
}
