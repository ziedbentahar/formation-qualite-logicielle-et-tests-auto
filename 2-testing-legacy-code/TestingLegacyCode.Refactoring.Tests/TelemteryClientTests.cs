using NUnit.Framework;
using System;
using System.Linq;
using Telemetry.Services;
using TestingLegacyCode.Refactoring.Tests.Fakes;

namespace TestingLegacyCode.Refactoring.Tests
{
    [TestFixture]
    public class TelemteryClientTests 
    {
        [Test]
        public void Should_start_scheduler_when_started()
        {
            //Arrange
            var fakeTelemetryProcessor = new FakeTelemetryProcessor();
            var fakeTelemetryCollector = new FakeTelemetryCollector();
            Func<string, ITelemetryProcessor> processorFactory = (string telemetryType) =>
            {
                return fakeTelemetryProcessor;
            };

            var fakeScheduler = new FakeScheduler();

            //Act
            var telemetryClient = new TelemetryClient(fakeTelemetryCollector, fakeScheduler, processorFactory);
            telemetryClient.Start();

            //Assert
            Assert.True(fakeScheduler.Started);
        }


        [Test]
        public void Should_collect_data_from_telemetry_collector_on_each_scheduler_tick()
        {
            //Arrange
            var fakeTelemetryProcessor = new FakeTelemetryProcessor();
            var fakeTelemetryCollector = new FakeTelemetryCollector();
            fakeTelemetryCollector.ExptectedTelemetryData = Enumerable.Empty<TelemetryData>();
            Func<string, ITelemetryProcessor> processorFactory = (string telemetryType) =>
            {
                return fakeTelemetryProcessor;
            };

            var fakeScheduler = new FakeScheduler();

            //Act
            var telemetryClient = new TelemetryClient(fakeTelemetryCollector, fakeScheduler, processorFactory);
            telemetryClient.Start();
            fakeScheduler.RaiseElaspedEvent();

            //Assert
            Assert.IsTrue(fakeTelemetryCollector.CollectWasInvoked);
        }

        [Test]
        public void Should_collect_and_process_data_from_telemetry_collector_on_each_scheduler_tick()
        {
            //Arrange
            var fakeTelemetryProcessor = new FakeTelemetryProcessor();
            var fakeTelemetryCollector = new FakeTelemetryCollector();

            fakeTelemetryCollector.ExptectedTelemetryData = new[]
            {
                new TelemetryData { Kind = "Pressure", Value = "10 psi"},
                new TelemetryData { Kind = "Temperature", Value = "70 °F"},
            };
            Func<string, ITelemetryProcessor> processorFactory = (string telemetryType) =>
            {
                return fakeTelemetryProcessor;
            };

            var fakeScheduler = new FakeScheduler();
            

            //Act
            var telemetryClient = new TelemetryClient(fakeTelemetryCollector, fakeScheduler, processorFactory);
            telemetryClient.Start();
            fakeScheduler.RaiseElaspedEvent();

            //Assert
            Assert.That(() => fakeTelemetryProcessor.ReceivedTelemetryData.Count(data => data.Kind == "Pressure" && data.Value == "10 psi") == 1);
            Assert.That(() => fakeTelemetryProcessor.ReceivedTelemetryData.Count(data => data.Kind == "Temperature" && data.Value == "70 °F") == 1);
        }
    }
}
