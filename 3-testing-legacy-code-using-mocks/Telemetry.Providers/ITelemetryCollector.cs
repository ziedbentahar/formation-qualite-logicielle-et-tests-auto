using System.Collections.Generic;

namespace Telemetry.Services
{
    public interface ITelemetryCollector
    {
        IEnumerable<TelemetryData> Collect();
    }
}