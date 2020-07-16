// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LogViewerExampleViewModel.cs" company="WildGums">
//   Copyright (c) 2008 - 2015 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.LogViewer.Examples.ViewModels
{
    using Catel.Logging;
    using Catel.MVVM;

    public class LogViewerExampleViewModel : ViewModelBase
    {
        #region Constants
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();
        #endregion

        #region Constructors
        public LogViewerExampleViewModel()
        {
            AddLogRecords = new Command(OnAddLogRecordsExecute);
        }
        #endregion

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