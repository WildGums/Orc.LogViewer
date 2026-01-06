namespace Orc.LogViewer.Examples.ViewModels
{
    using System;
    using Catel.Logging;
    using Catel.MVVM;
    using Microsoft.Extensions.Logging;

    public class LogViewerExampleViewModel : ViewModelBase
    {
        private static readonly ILogger Logger = LogManager.GetLogger(typeof(LogViewerExampleViewModel));

        public LogViewerExampleViewModel(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
            AddLogRecords = new Command(serviceProvider, OnAddLogRecordsExecute);
        }
        
        public Command AddLogRecords { get; set; }

        private void OnAddLogRecordsExecute()
        {
            Logger.LogDebug("Debug");
            Logger.LogWarning("Warning");
            Logger.LogError("Error");
            Logger.LogInformation("Info");
        }
    }
}
