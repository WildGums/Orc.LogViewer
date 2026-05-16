namespace Orc.LogViewer.Examples.ViewModels;

using System;
using Catel.Services;
using Catel.MVVM;
using Microsoft.Extensions.DependencyInjection;

public class MainWindowViewModel : ViewModelBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
    /// </summary>
    /// <param name="serviceProvider">The service provider.</param>
    public MainWindowViewModel(IServiceProvider serviceProvider)
        : this(serviceProvider, serviceProvider.GetRequiredService<ILanguageService>())
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
    /// </summary>
    /// <param name="serviceProvider">The service provider.</param>
    /// <param name="languageService">The language service.</param>
    public MainWindowViewModel(IServiceProvider serviceProvider, ILanguageService languageService)
        : base(serviceProvider)
    {
        Title = languageService.GetRequiredString("LogViewerExample_MainWindow_Title");
    }
}
