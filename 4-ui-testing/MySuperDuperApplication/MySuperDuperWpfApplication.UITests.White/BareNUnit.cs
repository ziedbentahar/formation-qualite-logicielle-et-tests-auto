using NUnit.Framework;
using System.Linq;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.ListBoxItems;

namespace MySuperDuperWpfApplication.UITests.White
{
    public class BareNUnit
    {
        [Test]
        public void Calculator_should_calculate_two_operands_correctly_when_two_integers_are_provided()
        {
            using (var application = Application.Launch($@"{TestContext.CurrentContext.TestDirectory}\MySuperDuperWpfApplication.exe"))
            {
                var operationWindow = application.GetWindows().Find(x => x.Title == "Ultimate calc 2000");

                var operand1 = operationWindow.Get<TextBox>(SearchCriteria.ByAutomationId("txtOperand1"));
                operand1.SetValue("6");

                var operand2 = operationWindow.Get<TextBox>(SearchCriteria.ByAutomationId("txtOperand2"));
                operand2.SetValue("36");

                var operation = operationWindow.Get<ComboBox>(SearchCriteria.ByAutomationId("cmbOperation"));

                operation.Select("+");

                var calcButton = operationWindow.Get<Button>(SearchCriteria.ByAutomationId("btnCalc"));
                calcButton.Click();

                var resultWindow = application.GetWindows().Find(x => x.Id == "Result");
                var result = resultWindow.Get<Label>(SearchCriteria.ByAutomationId("txtResult"));
                var resultText = result.Text;
                
                Assert.AreEqual("42", resultText);

                var btnSaveResult = resultWindow.Get<Button>(SearchCriteria.ByAutomationId("btnSaveResult"));
                btnSaveResult.Click();


                var lstSavedResult = resultWindow.Get<ListBox>(SearchCriteria.ByAutomationId("lstSavedResult"));
                Assert.That(() => lstSavedResult.Items.Count(item => item.Text == "42") == 1);

                resultWindow.Dispose();
                operationWindow.Dispose();
            }

        }
    }
}
