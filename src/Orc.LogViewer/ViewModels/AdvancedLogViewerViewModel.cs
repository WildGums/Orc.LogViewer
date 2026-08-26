namespace Orc.LogViewer.ViewModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catel;
using Catel.Configuration;
using Catel.Logging;
using Catel.MVVM;
using Catel.Services;
using Microsoft.Extensions.Logging;
using Orc.Controls;

public class AdvancedLogViewerViewModel : ViewModelBase
{
    private readonly IUIVisualizerService _uiVisualizerService;
    private readonly IApplicationLogFilterGroupService _applicationLogFilterGroupService;
    private readonly IConfigurationService _configurationService;
    private readonly IInMemoryLoggingContainer _inMemoryLoggingContainer;
    private readonly ILanguageService _languageService;

    // Log level is not a flags enum, so we need to use a dictionary to store the checked state of each log level.
    private readonly Dictionary<LogLevel, bool> _level = new Dictionary<LogLevel, bool>();

    public AdvancedLogViewerViewModel(IServiceProvider serviceProvider, IUIVisualizerService uiVisualizerService,
        IApplicationLogFilterGroupService applicationLogFilterGroupService, IConfigurationService configurationService,
        IInMemoryLoggingContainer inMemoryLoggingContainer)
        : this(serviceProvider, uiVisualizerService, applicationLogFilterGroupService, configurationService,
               inMemoryLoggingContainer, (ILanguageService)serviceProvider.GetService(typeof(ILanguageService))!)
    {
    }

    public AdvancedLogViewerViewModel(IServiceProvider serviceProvider, IUIVisualizerService uiVisualizerService,
        IApplicationLogFilterGroupService applicationLogFilterGroupService, IConfigurationService configurationService,
        IInMemoryLoggingContainer inMemoryLoggingContainer, ILanguageService languageService)
        : base(serviceProvider)
    {
        _uiVisualizerService = uiVisualizerService;
        _applicationLogFilterGroupService = applicationLogFilterGroupService;
        _configurationService = configurationService;
        _inMemoryLoggingContainer = inMemoryLoggingContainer;
        _languageService = languageService;

        foreach (var enumValue in Enum<LogLevel>.GetValues())
        {
            _level[enumValue] = enumValue == LogLevel.Error ||
                enumValue == LogLevel.Warning ||
                enumValue == LogLevel.Information;
        }

        LogFilterGroups = new List<LogFilterGroup>();
        EditFilterGroups = new TaskCommand(serviceProvider, OnEditFilterGroupsExecuteAsync);
    }

    public bool EnableThreadId { get; set; }

    public bool IgnoreCatelLogging { get; set; }

    public bool ShowFilterGroups { get; set; }

    public bool ShowFilterBox { get; set; }

    public List<LogFilterGroup> LogFilterGroups { get; private set; }

    public LogFilterGroup? SelectedLogFilterGroup { get; set; }

    public bool ErrorChecked
    {
        get { return _level[LogLevel.Error] || _level[LogLevel.Critical]; }
        set
        {
            if (value)
            {
                _level[LogLevel.Error] = true;
            }
            else
            {
                _level[LogLevel.Error] = false;
            }

            RaisePropertyChanged(nameof(ErrorChecked));
        }
    }

    public bool WarningChecked
    {
        get { return _level[LogLevel.Warning]; }
        set
        {
            if (value)
            {
                _level[LogLevel.Warning] = true;
            }
            else
            {
                _level[LogLevel.Warning] = false;
            }

            RaisePropertyChanged(nameof(WarningChecked));
        }
    }

    public bool InfoChecked
    {
        get { return _level[LogLevel.Information]; }
        set
        {
            if (value)
            {
                _level[LogLevel.Information] = true;
            }
            else
            {
                _level[LogLevel.Information] = false;
            }

            RaisePropertyChanged(nameof(InfoChecked));
        }
    }

    public bool DebugChecked
    {
        get { return _level[LogLevel.Debug]; }
        set
        {
            if (value)
            {
                _level[LogLevel.Debug] = true;
            }
            else
            {
                _level[LogLevel.Debug] = false;
            }

            RaisePropertyChanged(nameof(DebugChecked));
        }
    }

    public TaskCommand EditFilterGroups { get; private set; }

    private async Task OnEditFilterGroupsExecuteAsync()
    {
        await _uiVisualizerService.ShowDialogAsync<LogFilterGroupEditorViewModel>();

        await UpdateAsync();
    }

    protected override async Task InitializeAsync()
    {
        await base.InitializeAsync();

        await UpdateAsync();
    }

    private async Task UpdateAsync()
    {
        var filterGroups = new List<LogFilterGroup>
        {
            new LogFilterGroup
            {
                Name = _languageService.GetRequiredString("LogViewer_AdvancedLogViewerControl_None")
            }
        };

        var loadedFilterGroups = await _applicationLogFilterGroupService.LoadAsync();
        filterGroups.AddRange(loadedFilterGroups.OrderBy(x => x.Name));

        LogFilterGroups = filterGroups;

        var filterGroupName = _configurationService.GetRoamingValue(LogViewerSettings.LogFilterGroup, LogViewerSettings.LogFilterGroupDefaultValue);
        var filterGroupToSelect = (from x in filterGroups
                                   where x.Name.EqualsIgnoreCase(filterGroupName)
                                   select x).FirstOrDefault();
        if (filterGroupToSelect is null)
        {
            filterGroupToSelect = filterGroups.FirstOrDefault();
        }

        SelectedLogFilterGroup = filterGroupToSelect;
    }

    private void OnSelectedLogFilterGroupChanged()
    {
        if (IsInitialized)
        {
            _configurationService.SetRoamingValue(LogViewerSettings.LogFilterGroup, SelectedLogFilterGroup?.Name ?? string.Empty);
        }
    }
}
