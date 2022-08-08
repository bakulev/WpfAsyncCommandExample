using System;
using System.Windows;
using System.Windows.Data;
using System.Globalization;
using System.Threading.Tasks;
using CommunityToolkit.Common;

namespace WpfNetFramework.Converters
{
    // From https://github.com/CommunityToolkit/WindowsCommunityToolkit/blob/main/Microsoft.Toolkit.Uwp.UI/Converters/TaskResultConverter.cs
    /// <summary>
    /// A converter that can be used to safely retrieve results from <see cref="Task{T}"/> instances.
    /// This is needed because accessing <see cref="Task{TResult}.Result"/> when the task has not
    /// completed yet will block the current thread and might cause a deadlock (eg. if the task was
    /// scheduled on the same synchronization context where the result is being retrieved from).
    /// The methods in this converter will safely return <see langword="default"/> if the input
    /// task is still running, or if it has faulted or has been canceled.
    /// </summary>
    [ValueConversion(typeof(Task), typeof(string))]
    public sealed class TaskResultConverter : IValueConverter
    {
        #region IValueConverter Members
        
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Task task)
            {
                return task.GetResultOrDefault();
                /*
                string result = "unknown";
                if (task.Status == TaskStatus.RanToCompletion)
                    result = task.Result;
                return result;
                */
            }

            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
