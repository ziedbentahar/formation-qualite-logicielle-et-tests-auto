using System.Collections.Generic;
using Telemetry.Services;

namespace TestingLegacyCode.Refactoring.Tests.Fakes
{
    public class FakeTelemetryCollector : ITelemetryCollector
    {
        public IEnumerable<TelemetryData> ExptectedTelemetryData { get; set; }
        public bool CollectWasInvoked { get; set; }

        public void SetExpectations (IEnumerable<TelemetryData> data)
        {
            ExptectedTelemetryData = data;
        }

        public IEnumerable<TelemetryData> Collect()
        {
            CollectWasInvoked = true;
            return ExptectedTelemetryData;
        }

    }

}
