using System.Diagnostics;
using System.Windows;

namespace ChildApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            lblMyID.Text = $"Мой Process ID: {Process.GetCurrentProcess().Id}";
        }
    }
}
