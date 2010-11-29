using System.Windows;
using System.Windows.Controls;

namespace TSinaApi.Client
{
    /// <summary>
    /// Interaction logic for LoginBox.xaml
    /// </summary>
    public partial class LoginBox : UserControl
    {
        public MainWindow MainWindow { get; set; }
        public LoginBox(MainWindow mainWindow)
        {
            InitializeComponent();
            MainWindow = mainWindow;
        }

        private void LoginEvent(object sender, RoutedEventArgs e)
        {
            MainWindow.Client = new TSinaClient(ClientKey.AppKey, username.Text, password.Password);
            MainWindow.ShowMain();
        }
    }
}
