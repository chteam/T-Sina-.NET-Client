using System.Windows;

namespace TSinaApi.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public TSinaClient Client { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            ShowLogin();
        }

        private void ShowLogin()
        {
            ContentPanel.Children.Clear(); 
            ContentPanel.Children.Add(new LoginBox(this));
        }
        public void ShowMain()
        {
            ContentPanel.Children.Clear();
            ContentPanel.Children.Add(new TimelineBox(this));
        }
    }
}
