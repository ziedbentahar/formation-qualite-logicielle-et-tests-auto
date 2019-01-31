using System.Windows;

namespace MySuperDuperWpfApplication
{
    /// <summary>
    /// Logique d'interaction pour ResultWindow.xaml
    /// </summary>
    public partial class ResultWindow : Window
    {
        private string ResultData { get;  }
        public ResultWindow(string result) : this()
        {
            txtResult.Text = result;
            ResultData = result;
        }

        public ResultWindow()
        {
            InitializeComponent();
        }

        private void BtnSaveResult_Click(object sender, RoutedEventArgs e)
        {
            lstSavedResult.Items.Add(ResultData);
        }
    }
}
