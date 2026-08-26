namespace Orc.LogViewer.ViewModels;

using System;
using Catel.MVVM;
using Catel.Services;

public class LogFilterGroupEditorViewModel : ViewModelBase
{
    public LogFilterGroupEditorViewModel(IServiceProvider serviceProvider)
        : this(serviceProvider, serviceProvider.GetService(typeof(ILanguageService)) as ILanguageService
               ?? throw new InvalidOperationException($"Service of type '{nameof(ILanguageService)}' is not registered."))
    {
    }

    public LogFilterGroupEditorViewModel(IServiceProvider serviceProvider, ILanguageService languageService)
        : base(serviceProvider)
    {
        Title = languageService.GetRequiredString("LogViewer_AdvancedLogViewerControl_Editor_Title");
    }
}
