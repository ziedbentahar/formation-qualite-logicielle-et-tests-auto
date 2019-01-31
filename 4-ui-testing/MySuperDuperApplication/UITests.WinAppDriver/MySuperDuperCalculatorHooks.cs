using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace UITests.WinAppDriver
{
    [Binding]
    public sealed class MySuperDuperCalculatorHooks
    {

        [BeforeScenario]
        public void BeforeScenario()
        {
            DesiredCapabilities appCapabilities = new DesiredCapabilities();
            appCapabilities.SetCapability("app", @"C:\Work\MySuperDuperWinFormApplication.exe");
            var superDuperCalculatorSession = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), appCapabilities);
            ScenarioContext.Current.Add("calculatorSession", superDuperCalculatorSession);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            var superDuperCalcultorSession = ScenarioContext.Current.Get<WindowsDriver<WindowsElement>>("calculatorSession");
            superDuperCalcultorSession.Close();
        }
    }
}
