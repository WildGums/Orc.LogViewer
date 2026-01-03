namespace Orc.LogViewer.ViewModels
{
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

        private LogLevel _level;

        public AdvancedLogViewerViewModel(IServiceProvider serviceProvider, IUIVisualizerService uiVisualizerService,
            IApplicationLogFilterGroupService applicationLogFilterGroupService, IConfigurationService configurationService,
            IInMemoryLoggingContainer inMemoryLoggingContainer)
            : base(serviceProvider)
        {
            _uiVisualizerService = uiVisualizerService;
            _applicationLogFilterGroupService = applicationLogFilterGroupService;
            _configurationService = configurationService;
            _inMemoryLoggingContainer = inMemoryLoggingContainer;

            _level = LogLevel.Critical | LogLevel.Error | LogLevel.Warning | LogLevel.Information;

            LogFilterGroups = new List<LogFilterGroup>();
            EditFilterGroups = new TaskCommand(serviceProvider, OnEditFilterGroupsExecuteAsync);
        }

        public bool EnableThreadId { get; set; }

        public bool IgnoreCatelLogging { get; set; }

        public bool ShowFilterGroups { get; set; }

        public bool ShowFilterBox { get; set; }

        public List<LogFilterGroup> LogFilterGroups { get; private set; }

        public LogFilterGroup? SelectedLogFilterGroup { get; set; }

        public LogLevel Level
        {
            get { return _level; }
            set
            {
                if (_level == value)
                {
                    return;
                }

                _level = value;

                RaisePropertyChanged(nameof(Level));
                RaisePropertyChanged(nameof(ErrorChecked));
                RaisePropertyChanged(nameof(WarningChecked));
                RaisePropertyChanged(nameof(InfoChecked));
                RaisePropertyChanged(nameof(DebugChecked));
            }
        }

        public bool ErrorChecked
        {
            get { return Level.HasFlag(LogLevel.Error); }
            set
            {
                if (value)
                {
                    Level |= LogLevel.Error;
                }
                else
                {
                    Level &= ~LogLevel.Error;
                }

                RaisePropertyChanged(nameof(Level));
                RaisePropertyChanged(nameof(ErrorChecked));
            }
        }

        public bool WarningChecked
        {
            get { return Level.HasFlag(LogLevel.Warning); }
            set
            {
                if (value)
                {
                    Level |= LogLevel.Warning;
                }
                else
                {
                    Level &= ~LogLevel.Warning;
                }

                RaisePropertyChanged(nameof(Level));
                RaisePropertyChanged(nameof(WarningChecked));
            }
        }

        public bool InfoChecked
        {
            get { return Level.HasFlag(LogLevel.Information); }
            set
            {
                if (value)
                {
                    Level |= LogLevel.Information;
                }
                else
                {
                    Level &= ~LogLevel.Information;
                }

                RaisePropertyChanged(nameof(Level));
                RaisePropertyChanged(nameof(InfoChecked));
            }
        }

        public bool DebugChecked
        {
            get { return Level.HasFlag(LogLevel.Debug); }
            set
            {
                if (value)
                {
                    Level |= LogLevel.Debug;
                }
                else
                {
                    Level &= ~LogLevel.Debug;
                }

                RaisePropertyChanged(nameof(Level));
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
                    Name = LanguageHelper.GetRequiredString("LogViewer_AdvancedLogViewerControl_None")
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
}
