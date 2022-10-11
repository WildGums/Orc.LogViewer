namespace Orc.LogViewer.Examples.ViewModels
{
    using System.Threading.Tasks;
    using Catel;
    using Catel.MVVM;
    using Catel.Services;

    public class LogViewerSeparateWindowExampleViewModel : ViewModelBase
    {
        private readonly IUIVisualizerService _uiVisualizerService;

        public LogViewerSeparateWindowExampleViewModel(IUIVisualizerService uiVisualizerService)
        {
            Argument.IsNotNull(() => uiVisualizerService);

            _uiVisualizerService = uiVisualizerService;

            ShowLogWindow = new TaskCommand(OnShowLogWindowExecuteAsync);
        }
        
        public TaskCommand ShowLogWindow { get; private set; }

        private async Task OnShowLogWindowExecuteAsync()
        {
#pragma warning disable 4014
            _uiVisualizerService.ShowAsync<LogWindowViewModel>();
#pragma warning restore 4014
        }
    }
}
