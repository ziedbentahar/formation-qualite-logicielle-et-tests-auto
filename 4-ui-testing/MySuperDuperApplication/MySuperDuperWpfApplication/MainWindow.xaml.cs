using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MySuperDuperWpfApplication
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Dictionary<string, Func<int, int, int>> _operationToFuncMap = new Dictionary<string, Func<int, int, int>>()
        {
            {
                "+", (operand1, operand2) => operand1 + operand2
            },
            {
                "-", (operand1, operand2) => operand1 - operand2
            },
            {
                "/", (operand1, operand2) => operand1 / operand2
            },
            {
                "*", (operand1, operand2) => operand1 * operand2
            },
            {
                "%", (operand1, operand2) => operand1 % operand2
            }
        };


        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var operation = cmbOperation.Text;
            var operand1Text = txtOperand1.Text;
            var operand2Text = txtOperand2.Text;

            var result = ComputeResult(operand1Text, operand2Text, operation);
          
            var resultWindow = new ResultWindow(result);
            resultWindow.ShowDialog();
        }

        private string ComputeResult(string operand1Text, string operand2Text, string operation)
        {
            if (!int.TryParse(operand1Text, out var operand1) || !int.TryParse(operand2Text, out var operand2))
            {
                return "Error";
            }

            var operationFound = _operationToFuncMap.TryGetValue(operation, out var operationFunc);

            if (!operationFound)
            {
                return "Invalid Operation";
            }
            else
            {
                return operationFunc(operand1, operand2).ToString();
            }
        }
    }
}
