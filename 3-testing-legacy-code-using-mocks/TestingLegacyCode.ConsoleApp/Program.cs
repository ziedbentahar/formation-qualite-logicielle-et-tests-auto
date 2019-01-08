using System;

namespace TestingLegacyCode.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var telemetryClient = new TelemetryClient();

            telemetryClient.ErrorDetected += TelemetryClient_ErrorDetected;
            telemetryClient.Start();
            Console.ReadKey();
            telemetryClient.Stop();
        }

        private static void TelemetryClient_ErrorDetected(object sender, EventArgs e)
        {
            Console.WriteLine($"[{DateTime.Now}] Error !");
        }
    }
}
