using NFluent;
using System;
using System.Collections.Generic;
using System.Text;
using Telemetry.Services;

namespace Telemetry.Tests
{
    class NFluentExamples
    {
        //credit: some examples taken from : http://www.n-fluent.net/
        void Some_nfluent_examples()
        {
            var integers = new int[] { 1, 2, 3, 4, 5, 666 };
            Check.That(integers).Contains(3, 5, 666);

            integers = new int[] { 1, 2, 3 };
            Check.That(integers).IsOnlyMadeOf(3, 2, 1);

            var guitarHeroes = new[] { "Hendrix", "Paco de Lucia", "Django Reinhardt", "Baden Powell" };
            Check.That(guitarHeroes).ContainsExactly("Hendrix", "Paco de Lucia", "Django Reinhardt", "Baden Powell");

            var pressureData = new TelemetryData { Kind = "pressure", Value = "42 psi" };
            var tempData = new TelemetryData { Kind = "temperature", Value = "10 °F" };
            Check.That(pressureData).IsNotEqualTo(tempData).And.IsInstanceOf<TelemetryData>();
            Check.That(tempData).IsNotInstanceOf<int>();

            var heroes = "Batman and Robin";
            Check.That(heroes).Not.Contains("Joker").And.StartsWith("Bat").And.Contains("Robin");
            
        }
    }
}
