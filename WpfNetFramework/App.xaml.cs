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
        ViewModels.MainViewModel _mainViewModel;

        override protected void OnStartup(StartupEventArgs e)
        {
            _mainView = new Views.MainWindow();
            MainWindow = _mainView;
            _mainViewModel = new ViewModels.MainViewModel();
            _mainView.DataContext = _mainViewModel;
            _mainView.Show();
        }
        override protected void OnExit(ExitEventArgs e)
        {

        }
    }
}
