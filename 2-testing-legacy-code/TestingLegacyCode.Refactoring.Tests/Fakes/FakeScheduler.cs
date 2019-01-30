using System;
using System.Text;
using Telemetry.Services;

namespace TestingLegacyCode.Refactoring.Tests.Fakes
{
    public class FakeScheduler : IScheduler
    {
        public bool Started { get; private set; }

        public event EventHandler Elapsed;

        public void RaiseElaspedEvent()
        {
            var handler = Elapsed;
            if (handler != null)
            {
                Elapsed(this, new EventArgs());
            }
        }

        public void Start()
        {
            Started = true;
        }

        public void Stop()
        {
            Started = false;
        }
    }

}
