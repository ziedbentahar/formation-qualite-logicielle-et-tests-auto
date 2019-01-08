namespace Telemetry.Services
{
    public interface ITelemetryProcessor
    {
        void Process(TelemetryData telemetry);
    }
}
