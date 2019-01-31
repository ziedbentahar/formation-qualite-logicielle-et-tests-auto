using NUnit.Framework;
using System;
using System.Linq;
using TechTalk.SpecFlow;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.WindowItems;


namespace MySuperDuperWpfApplication.UITests.White
{
    [Binding]
    public class PerformOperationSteps
    {
        private Application GetApplication()
        {
            return ScenarioContext.Current.Get<Application>("application");
        }

        private Window OperationWindow
        {
            get => GetApplication().GetWindows().Find(x => x.Title == "Ultimate calc 2000");
        }

        private Window ResultWindow
        {
            get => GetApplication().GetWindows().Find(x => x.Id == "Result");
        }

        [Given(@"I have entered (.*) and (.*) into the operands")]
        public void GivenIHaveEnteredAndIntoTheOperands(string operand1Value, string operand2Value)
        {
            var operand1 = OperationWindow.Get<TextBox>(SearchCriteria.ByAutomationId("txtOperand1"));
            operand1.SetValue(operand1Value);

            var operand2 = OperationWindow.Get<TextBox>(SearchCriteria.ByAutomationId("txtOperand2"));
            operand2.SetValue(operand2Value);
        }
        
        [Given(@"I have selected \+ operation")]
        public void GivenIHaveSelectedOperation()
        {
            var operation = OperationWindow.Get<ComboBox>(SearchCriteria.ByAutomationId("cmbOperation"));
            operation.Select("+");
        }
        
        [When(@"I press calc button")]
        public void WhenIPressCalcButton()
        {
            var button = OperationWindow.Get<Button>(SearchCriteria.ByAutomationId("btnCalc"));
            button.Click();
        }
        
        [Then(@"I should see the (.*) on a new window")]
        public void ThenIShouldSeeTheOnANewWindow(string expectedResult)
        {
            var resultLabel = ResultWindow.Get<Label>(SearchCriteria.ByAutomationId("txtResult"));
            var resultText = resultLabel.Text;

            Assert.AreEqual(expectedResult, resultText);

        }
    }
}
