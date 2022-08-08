using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WpfNetFramework
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        Views.MainWindow _mainView;

        override protected void OnStartup(StartupEventArgs e)
        {
            _mainView = new Views.MainWindow();
            _mainView.DataContext = this;
            MainWindow = _mainView;
            _mainView.Show();
        }
        override protected void OnExit(ExitEventArgs e)
        {

        }
    }
}
