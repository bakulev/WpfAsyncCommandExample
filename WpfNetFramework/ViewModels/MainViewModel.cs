using System;
using System.Threading;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace WpfNetFramework.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private Models.MainModel _mainModel;

        public MainViewModel()
        {
            DownloadTextCommand = new AsyncRelayCommand(DownloadText, () => DownloadTextCanExecute());
            DownloadTextCancelCommand = new RelayCommand(DownloadTextCancel);

            _mainModel = new Models.MainModel();
        }

        public IAsyncRelayCommand DownloadTextCommand { get; }
        public IRelayCommand DownloadTextCancelCommand { get; }

        private async Task<Models.TestResult> DownloadText(CancellationToken token)
        {
            var progress = new Progress<int>(args => ProgressValue += 1);

            ProgressValue = 0;
            var result = await _mainModel.TestMethod(token, progress).ConfigureAwait(false);

            return result;
        }

        private int _progressValue = 0;
        public int ProgressValue
        {
            get { return _progressValue; }
            set { SetProperty<int>(ref _progressValue, value); }
        }

        private bool DownloadTextCanExecute()
        {
            return !DownloadTextCommand.IsRunning;
        }

        //[RelayCommand]
        private void DownloadTextCancel()
        {
            DownloadTextCommand.Cancel();
        }

    }
}
