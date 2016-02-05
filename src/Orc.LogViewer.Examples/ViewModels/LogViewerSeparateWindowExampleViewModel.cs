// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LogViewerSeparateWindowExampleViewModel.cs" company="WildGums">
//   Copyright (c) 2008 - 2015 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.LogViewer.Examples.ViewModels
{
    using Catel;
    using Catel.MVVM;
    using Catel.Services;

    public class LogViewerSeparateWindowExampleViewModel : ViewModelBase
    {
        private readonly IUIVisualizerService _uiVisualizerService;

        #region Constructors
        public LogViewerSeparateWindowExampleViewModel(IUIVisualizerService uiVisualizerService)
        {
            Argument.IsNotNull(() => uiVisualizerService);

            _uiVisualizerService = uiVisualizerService;

            ShowLogWindow = new Command(OnShowLogWindowExecute);
        }
        #endregion

        public Command ShowLogWindow { get; private set; }

        private void OnShowLogWindowExecute()
        {
            _uiVisualizerService.Show<LogWindowViewModel>();
        }
    }
}