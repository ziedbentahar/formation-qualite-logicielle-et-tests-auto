namespace Telemetry.Services
{
    public interface ITelemetryProcessor
    {
        void Process(TelemetryData telemetry);
    }

    public class TemperatureProcessor : ITelemetryProcessor
    {
        public void Process(TelemetryData telemetry)
        {
            // TO DO write in file
        }
    }

    public class PressureProcessor : ITelemetryProcessor
    {
        public void Process(TelemetryData telemetry)
        {
            // TO DO write in file
        }
    }

    public class ErrorProcessor : ITelemetryProcessor
    {
        public void Process(TelemetryData telemetry)
        {
            // TO DO write in file
        }
    }
}
