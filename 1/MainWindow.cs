using System.Diagnostics;
using System.Windows;

namespace ParentApp
{
    public partial class MainWindow  Window
    {
        private Process _childProcess;

        public MainWindow()
        {
            InitializeComponent();
            lblParentID.Text = $ID родительского процесса {Process.GetCurrentProcess().Id};
        }

        private void StartChild_Click(object sender, RoutedEventArgs e)
        {
            if (_childProcess != null && !_childProcess.HasExited) return;  Предотвращение множественного запуска

            _childProcess = new Process();
            _childProcess.StartInfo.FileName = ChildApp.exe;  Укажите путь к .exe дочернего приложения
            _childProcess.EnableRaisingEvents = true;
            _childProcess.Exited += (s, args) = {
                Dispatcher.Invoke(() = lblChildID.Text = Дочерний процесс завершен.);
            };
            
            _childProcess.Start();
            lblChildID.Text = $ID дочернего процесса {_childProcess.Id};
        }

        private void StopChild_Click(object sender, RoutedEventArgs e)
        {
            if (_childProcess != null && !_childProcess.HasExited)
            {
                _childProcess.Kill();
            }
        }
    }
}
