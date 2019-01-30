using System;
using System.Collections.Generic;
using System.Text;
using Telemetry.Services;

namespace TestingLegacyCode.Refactoring.Tests.Fakes
{
    class FakeTelemetryProcessor : ITelemetryProcessor
    {
        public List<TelemetryData> ReceivedTelemetryData { get; private set; } = new List<TelemetryData>();

        public void Reset()
        {
            ReceivedTelemetryData.Clear();
        }

        public void Process(TelemetryData telemetry)
        {
            ReceivedTelemetryData.Add(telemetry);
        }
    }
}
