using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.WindowItems;

namespace UITests.White
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void Calculator_should_calculate_two_operands_correctly_when_two_integers_are_provided()
        {
            //Arrange
            using (var application = Application.Launch(@"C:\Work\MySuperDuperWinFormApplication.exe"))
            {
                var windows = application.GetWindows();
            
                var window = windows.Find(x => x.Id == "frmCalculator");
                var operand1 = window.Get<TextBox>(SearchCriteria.ByAutomationId("txtOperand1"));
                operand1.SetValue("6");

                var operand2 = window.Get<TextBox>(SearchCriteria.ByAutomationId("txtOperand2"));
                operand2.SetValue("36");

                var operation = window.Get<ComboBox>(SearchCriteria.ByAutomationId("comboOperation"));

                operation.Select("+");

                //Act
                var calcButton = window.Get<Button>(SearchCriteria.ByAutomationId("btnCalc"));
                calcButton.Click();

                //Assert
                var result = window.Get<TextBox>(SearchCriteria.ByAutomationId("txtResult"));
                var resultText = result.Text;

                window.Close();

                Assert.AreEqual("42", resultText);
            }
            
        }
    }
}
