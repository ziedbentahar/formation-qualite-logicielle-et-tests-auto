using NSubstitute;
using NUnit.Framework;
using System;
using Telemetry.Services;

namespace Telemetry.Tests
{
    [TestFixture]
    public class TelemetryClientTests
    {
        [Test]
       public void Should_start_scheduler_when_started()
       {
            //Arrange
            var scheduler = Substitute.For<IScheduler>();
            var telemetryCollector = Substitute.For<ITelemetryCollector>();
            Func<string, ITelemetryProcessor> processorFactory = (string telemetryType) =>
            {
                return Substitute.For<ITelemetryProcessor>();
            };
            
            //Act
            var telemetryClient = new TelemetryClient(telemetryCollector, scheduler, processorFactory);
            telemetryClient.Start();

            //Assert
            scheduler.Received().Start();
       }


        [Test]
        public void Should_collect_data_from_telemetry_collector_on_each_scheduler_tick()
        {
            //Arrange
            var scheduler = Substitute.For<IScheduler>();
            var telemetryCollector = Substitute.For<ITelemetryCollector>();
            Func<string, ITelemetryProcessor> processorFactory = (string telemetryType) =>
            {
                return Substitute.For<ITelemetryProcessor>();
            };

            //Act
            var telemetryClient = new TelemetryClient(telemetryCollector, scheduler, processorFactory);
            telemetryClient.Start();
            scheduler.Elapsed += Raise.EventWith(scheduler, new EventArgs());

            //Assert
            telemetryCollector.Received(1).Collect();
        }

        [Test]
        public void Should_collect_and_process_data_from_telemetry_collector_on_each_scheduler_tick()
        {
            //Arrange
            var scheduler = Substitute.For<IScheduler>();
            var telemetryCollector = Substitute.For<ITelemetryCollector>();
            var telemetryProcessor = Substitute.For<ITelemetryProcessor>();

            telemetryCollector.Collect().Returns(new []
            {
                new TelemetryData { Kind = "Pressure", Value = "10 psi"},
                new TelemetryData { Kind = "Temperature", Value = "70 °F"},
            });

            Func<string, ITelemetryProcessor> processorFactory = (string telemetryType) => telemetryProcessor;

            //Act
            var telemetryClient = new TelemetryClient(telemetryCollector, scheduler, processorFactory);
            telemetryClient.Start();
            scheduler.Elapsed += Raise.EventWith(scheduler, new EventArgs());

            //Assert
            telemetryProcessor.Received(1).Process(Arg.Is<TelemetryData>(data => data.Kind == "Pressure" && data.Value == "10 psi"));
            telemetryProcessor.Received(1).Process(Arg.Is<TelemetryData>(data => data.Kind == "Temperature" && data.Value == "70 °F"));
        }
    }
}