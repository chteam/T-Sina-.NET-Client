using System.Windows.Controls;

namespace TSinaApi.Client
{
    /// <summary>
    /// StatusBox.xaml 的交互逻辑
    /// </summary>
    public partial class StatusBox : UserControl
    {
        public MainWindow MainWindow { get; set; }
        public Status Status { get; set; }
        public StatusBox(MainWindow mainWindow,Status status)
        {
            InitializeComponent();
            MainWindow = mainWindow;
            Status = status;
        }
    }
}
