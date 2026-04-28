namespace Orc.LogViewer.ViewModels;

using System;
using Catel;
using Catel.MVVM;

public class LogFilterGroupEditorViewModel : ViewModelBase
{
    public LogFilterGroupEditorViewModel(IServiceProvider serviceProvider)
        : base(serviceProvider)
    {
        Title = LanguageHelper.GetRequiredString("LogViewer_AdvancedLogViewerControl_Editor_Title");
    }
}
