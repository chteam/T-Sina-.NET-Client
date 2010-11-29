using System.Windows.Controls;

namespace TSinaApi.Client
{
    /// <summary>
    /// TimelineBox.xaml 的交互逻辑
    /// </summary>
    public partial class TimelineBox : UserControl
    {
        public MainWindow MainWindow { get; set; }
        public TimelineBox(MainWindow mainWindow)
        {
            InitializeComponent();
            MainWindow = mainWindow;
        }

        private void RefushEvent(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}
