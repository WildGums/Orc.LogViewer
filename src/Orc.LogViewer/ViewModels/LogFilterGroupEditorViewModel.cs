﻿namespace Orc.LogViewer.ViewModels
{
    using Catel;
    using Catel.MVVM;

    public class LogFilterGroupEditorViewModel : ViewModelBase
    {
        public LogFilterGroupEditorViewModel()
        {
            Title = LanguageHelper.GetRequiredString("LogViewer_AdvancedLogViewerControl_Editor_Title");
        }
    }
}
