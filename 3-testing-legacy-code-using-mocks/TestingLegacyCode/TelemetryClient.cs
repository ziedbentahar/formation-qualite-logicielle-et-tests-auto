
using System;
using System.IO;
using System.Timers;

namespace TestingLegacyCode
{
    public class TelemetryClient
    {
        private readonly TelemetryCollector _collector = new TelemetryCollector();
        private Timer _timer;
        public event EventHandler<EventArgs> ErrorDetected;

        public TelemetryClient()
        {
            _collector = new TelemetryCollector();
        }

        private void GetDataFromCollector()
        {
            var telemetries = _collector.Collect();

            foreach (var item in telemetries)
            {
                if(item.Kind == "Pressure")
                {
                    // Write the telemetry + date time to pressure file when pressure > 30 psi
                    if(int.Parse(item.Value.Split(' ')[0]) > 30)
                    {
                        using (StreamWriter writer = new StreamWriter("pressures.txt", true))
                        {
                            writer.Write($"[{DateTime.Now}] {item.Value}");
                        }
                    }

                }
                else if(item.Kind == "Temperature")
                {
                    // temparature should be converted to Degree when in fahrenheit
                    var valueInDegree = int.Parse(item.Value.Split(' ')[0]) - 32  * 5/9;
                    // Write the temparature + date time to temparature file
                    using (StreamWriter writer = new StreamWriter("temparatures.txt", true))
                    {
                        writer.Write($"[{DateTime.Now}] {valueInDegree} °C");
                    }
                }
                else
                {
                    // Raise error event to be consumed by consumers of TelemetryClient
                    ErrorDetected?.Invoke(this, new ErrorEventArgs(item.Value));
                }
            }
                

        }

        public void Start()
        {
            _timer = new Timer(5000);
            _timer.AutoReset = true;
            _timer.Elapsed += Timer_Elapsed;
            _timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            GetDataFromCollector();
        }

        public void Stop()
        {
            _timer.Stop();
        }
    }
}
