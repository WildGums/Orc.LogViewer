namespace Orc.LogViewer.Examples.ViewModels;

using System;
using Catel.MVVM;

public class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel(IServiceProvider serviceProvider)
        : base(serviceProvider)
    {
        Title = "Orc.LogViewer example";
    }
}
