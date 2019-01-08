using System.Collections.Generic;

namespace Telemetry
{
    public interface ITelemetryCollector
    {
        IEnumerable<Telemetry> Collect();
    }
}