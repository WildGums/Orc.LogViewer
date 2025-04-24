namespace Orc.LogViewer.Examples.ViewModels;

using System;
using System.Threading.Tasks;
using Catel.MVVM;
using Catel.Services;

public class LogViewerSeparateWindowExampleViewModel : ViewModelBase
{
    private readonly IUIVisualizerService _uiVisualizerService;

    public LogViewerSeparateWindowExampleViewModel(IUIVisualizerService uiVisualizerService)
    {
        ArgumentNullException.ThrowIfNull(uiVisualizerService);

        _uiVisualizerService = uiVisualizerService;

        ShowLogWindow = new TaskCommand(OnShowLogWindowExecuteAsync);
    }
        
    public TaskCommand ShowLogWindow { get; }

    private async Task OnShowLogWindowExecuteAsync()
    {
        await _uiVisualizerService.ShowAsync<LogWindowViewModel>();
    }
}
