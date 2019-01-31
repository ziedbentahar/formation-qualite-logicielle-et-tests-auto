using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySuperDuperWinFormApplication
{
    public partial class frmCalculator : Form
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

        public frmCalculator()
        {
            InitializeComponent();
        }


        private void btnCalc_Click(object sender, EventArgs e)
        {
            var operation = comboOperation.Text;
            var operand1Text = txtOperand1.Text;
            var operand2Text = txtOperand2.Text;

            if(!int.TryParse(operand1Text, out var operand1) || !int.TryParse(operand2Text, out var operand2))
            {
                txtResult.Text = "Error";
                return;
            }

            var found = _operationToFuncMap.TryGetValue(operation, out var operationFunc);

            if(!found)
            {
                txtResult.Text = "Invalid Operation";
            }

            if(found)
            {
                txtResult.Text = operationFunc(operand1, operand2).ToString();
            }
               
        }

        private void frmCalculator_Load(object sender, EventArgs e)
        {

        }
    }
}
