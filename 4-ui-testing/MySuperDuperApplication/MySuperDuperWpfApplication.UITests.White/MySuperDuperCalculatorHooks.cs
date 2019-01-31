using NUnit.Framework;
using TechTalk.SpecFlow;
using TestStack.White;

namespace UITests.WinAppDriver
{
    [Binding]
    public sealed class MySuperDuperCalculatorHooks
    {

        [BeforeScenario]
        public void BeforeScenario()
        {
            var application = Application.Launch($@"{TestContext.CurrentContext.TestDirectory}\MySuperDuperWpfApplication.exe");
            ScenarioContext.Current.Add("application", application);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            var application = ScenarioContext.Current.Get<Application>("application");
            application.Dispose();
        }
    }
}
