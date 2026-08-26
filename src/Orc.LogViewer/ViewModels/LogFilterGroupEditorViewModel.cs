namespace Orc.LogViewer.ViewModels;

using System;
using Catel.MVVM;
using Catel.Services;

public class LogFilterGroupEditorViewModel : ViewModelBase
{
    public LogFilterGroupEditorViewModel(IServiceProvider serviceProvider, ILanguageService languageService)
        : base(serviceProvider)
    {
        Title = languageService.GetRequiredString("LogViewer_AdvancedLogViewerControl_Editor_Title");
    }
}
