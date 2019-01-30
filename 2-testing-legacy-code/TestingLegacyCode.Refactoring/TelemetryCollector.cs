using System;
using System.Collections.Generic;
using System.Linq;

namespace Telemetry.Services
{
    public class TelemetryCollector : ITelemetryCollector
    {
        Random _random = new Random((int)DateTime.UtcNow.Ticks);

        private IEnumerable<TelemetryData> GenerateTelemetries()
        {
            const int numberOfTelemetries = 10;

            return Enumerable.Range(0, numberOfTelemetries)
                .Select(item =>
                {
                    var random = _random.Next(3);
                    if(item == 0)
                    {
                        return new TelemetryData
                        {
                            Kind = "Pressure",
                            Value = $"{_random.Next(50)} psi"
                        };
                    } else if(item == 1)
                    {
                        return new TelemetryData
                        {
                            Kind = "Temperature",
                            Value = $"{_random.Next(80)} °F"
                        };
                    } else
                    {
                        return new TelemetryData
                        {
                            Kind = "Error",
                        };
                    }
                });

        }

        public IEnumerable<TelemetryData> Collect() => GenerateTelemetries();
        
    }
}
