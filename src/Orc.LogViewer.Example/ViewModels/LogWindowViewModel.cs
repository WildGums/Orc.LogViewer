namespace Orc.LogViewer.Examples.ViewModels;

using System;
using Catel.Services;
using Catel.MVVM;
using Microsoft.Extensions.DependencyInjection;

public class LogWindowViewModel : ViewModelBase
{
    private readonly ILanguageService _languageService;

    /// <summary>
    /// Initializes a new instance of the <see cref="LogWindowViewModel"/> class.
    /// </summary>
    /// <param name="serviceProvider">The service provider.</param>
    public LogWindowViewModel(IServiceProvider serviceProvider)
        : this(serviceProvider, serviceProvider.GetRequiredService<ILanguageService>())
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="LogWindowViewModel"/> class.
    /// </summary>
    /// <param name="serviceProvider">The service provider.</param>
    /// <param name="languageService">The language service.</param>
    public LogWindowViewModel(IServiceProvider serviceProvider, ILanguageService languageService)
        : base(serviceProvider)
    {
        _languageService = languageService;
    }

    public override string Title => _languageService.GetRequiredString("LogViewerExample_LogWindow_Title");
}
