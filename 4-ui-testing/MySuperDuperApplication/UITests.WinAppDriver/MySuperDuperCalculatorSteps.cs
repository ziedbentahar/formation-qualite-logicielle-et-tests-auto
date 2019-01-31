using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using TechTalk.SpecFlow;

namespace UITests.WinAppDriver
{
    [Binding]
    public class MySuperDuperCalculatorSteps
    {
        private WindowsDriver<WindowsElement> GetCalculatorSession()
        {
            return ScenarioContext.Current.Get<WindowsDriver<WindowsElement>>("calculatorSession");
        }

        [Given(@"I have entered (.*) into the first operand text box")]
        public void GivenIHaveEnteredTheFirstOperand(int firstOperand)
        {
            var session = GetCalculatorSession();
            var windowElement = session.FindElementByAccessibilityId("txtOperand1");
            windowElement.SendKeys(Keys.Shift+ firstOperand);
        }

        [Given(@"I have entered (.*) into the second operand text box")]
        public void GivenIHaveEnteredTheSecondOperand(int secondOperand)
        {
            var session = GetCalculatorSession();
            var windowElement = session.FindElementByAccessibilityId("txtOperand2");
            windowElement.SendKeys(Keys.Shift + secondOperand);
        }

        [Given(@"I have entered \+ sign into the operation combo")]
        public void GivenIHaveEnteredSignIntoTheOperationCombo()
        {
            var session = GetCalculatorSession();
            var windowElement = session.FindElementByAccessibilityId("comboOperation");
            windowElement.SendKeys("+");
        }

        [When(@"I click calc button")]
        public void WhenIClickCalcButton()
        {
            var session = GetCalculatorSession();
            var windowElement = session.FindElementByAccessibilityId("btnCalc");
            windowElement.Click();
        }
     
        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int expectedResult)
        {
            var session = GetCalculatorSession();
            var windowElement = session.FindElementByAccessibilityId("txtResult");
            var result = int.Parse(windowElement.Text);
            Assert.AreEqual(expectedResult, result);
        }
    }
}
