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
    public class PerformOperationAndSaveResultSteps
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


        [Given(@"I have entered (.*) into the first operand")]
        public void GivenIHaveEnteredIntoTheFirstOperand(int operand1Value)
        {
            var operand1 = OperationWindow.Get<TextBox>(SearchCriteria.ByAutomationId("txtOperand1"));
            operand1.SetValue(operand1Value);
        }
        
        [Given(@"I have entered (.*) into the second operand")]
        public void GivenIHaveEnteredIntoTheSecondOperand(int operand2Value)
        {
            var operand1 = OperationWindow.Get<TextBox>(SearchCriteria.ByAutomationId("txtOperand2"));
            operand1.SetValue(operand2Value);
        }

        [Given(@"I have selected add operation")]
        public void GivenIHaveEnteredAddOperation()
        {
            var operation = OperationWindow.Get<ComboBox>(SearchCriteria.ByAutomationId("cmbOperation"));
            operation.Select("+");
        }
        
        [Given(@"I have clicked calc button")]
        public void GivenIHaveClickedCalcButton()
        {
            var button = OperationWindow.Get<Button>(SearchCriteria.ByAutomationId("btnCalc"));
            button.Click();
        }
        
        [When(@"I press save result on result window")]
        public void WhenIPressSaveResultOnResultWindow()
        {
            var button = ResultWindow.Get<Button>(SearchCriteria.ByAutomationId("btnSaveResult"));
            button.Click();
        }
        
        [Then(@"(.*) should be added to the result list")]
        public void ThenShouldBeAddedToTheResultList(int p0)
        {
            var lstSavedResult = ResultWindow.Get<ListBox>(SearchCriteria.ByAutomationId("lstSavedResult"));
            Assert.That(() => lstSavedResult.Items.Count(item => item.Text == "120") == 1);

        }
    }
}
