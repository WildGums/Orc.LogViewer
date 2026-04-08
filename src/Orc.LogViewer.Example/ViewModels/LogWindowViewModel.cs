namespace Orc.LogViewer.Examples.ViewModels;

using System;
using Catel.MVVM;

public class LogWindowViewModel : ViewModelBase
{
    public LogWindowViewModel(IServiceProvider serviceProvider) 
        : base(serviceProvider)
    {
    }

    public override string Title
    {
        get { return "Log window"; }
    }
}
