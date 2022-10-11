namespace Orc.LogViewer.Examples.ViewModels
{
    using Catel.Logging;
    using Catel.MVVM;

    public class LogViewerExampleViewModel : ViewModelBase
    {
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();

        public LogViewerExampleViewModel()
        {
            AddLogRecords = new Command(OnAddLogRecordsExecute);
        }
        
        public Command AddLogRecords { get; set; }

        private void OnAddLogRecordsExecute()
        {
            Log.Debug("Debug");
            Log.Warning("Warning");
            Log.Error("Error");
            Log.Info("Info");
        }
    }
}
