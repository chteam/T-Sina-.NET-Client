using System.Windows.Controls;

namespace TSinaApi.Client
{
    /// <summary>
    /// Interaction logic for SendBox.xaml
    /// </summary>
    public partial class SendBox : UserControl
    {
        public MainWindow MainWindow { get; set; }
        public SendBox(MainWindow mainWindow)
        {
            InitializeComponent();
            MainWindow = mainWindow;
        }

        private void SendEvent(object sender, System.Windows.RoutedEventArgs e)
        {
            MainWindow.Client.Statuses.Update(text.Text);
        }

    }
}
