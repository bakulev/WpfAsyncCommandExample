using System;
using System.Threading;
using System.Threading.Tasks;

namespace WpfNetFramework.Models
{
    internal class TestResult
    {
        public string Res { get; }
        public string Error { get; }

        public TestResult(string res, string error)
        {
            Res = res ?? throw new ArgumentNullException(nameof(res));
            Error = error ?? throw new ArgumentNullException(nameof(error));
        }

        override public string ToString()
        {
            return "Res: " + Res + "; Err: " + Error + ".";
        }
    }

    internal class MainModel
    {
        public async Task<TestResult> TestMethod(CancellationToken token, IProgress<int> progress)
        {
            try
            {
                for (int i = 0; i < 100; i++)
                {
                    await Task.Delay(30, token);
                    // See notes about Progress: 
                    // https://stackoverflow.com/questions/68652535/using-iprogress-when-reporting-progress-for-async-await-code-vs-progress-bar-con
                    progress.Report(i);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return new TestResult("tststs", "errr");
        }
    }
}
