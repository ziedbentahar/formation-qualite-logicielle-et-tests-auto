using System;
using System.Collections.Generic;
using System.Linq;

namespace Telemetry
{
    public class TelemetryCollector : ITelemetryCollector
    {
        Random _random = new Random((int)DateTime.UtcNow.Ticks);

        private IEnumerable<Telemetry> GenerateTelemetries()
        {
            const int numberOfTelemetries = 10;

            return Enumerable.Range(0, numberOfTelemetries)
                .Select(item =>
                {
                    var random = _random.Next(3);
                    if(item == 0)
                    {
                        return new Telemetry
                        {
                            Kind = "Pressure",
                            Value = $"{_random.Next(50)} psi"
                        };
                    } else if(item == 1)
                    {
                        return new Telemetry
                        {
                            Kind = "Temperature",
                            Value = $"{_random.Next(80)} °F"
                        };
                    } else
                    {
                        return new Telemetry
                        {
                            Kind = "Error",
                        };
                    }
                });

        }

        public IEnumerable<Telemetry> Collect() => GenerateTelemetries();
        
    }
}
