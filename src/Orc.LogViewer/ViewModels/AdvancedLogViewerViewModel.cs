// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AdvancedLogViewerViewModel.cs" company="WildGums">
//   Copyright (c) 2008 - 2015 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.LogViewer.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Catel;
    using Catel.Logging;
    using Catel.MVVM;
    using Catel.Services;
    using Orc.Controls;

    public class AdvancedLogViewerViewModel : ViewModelBase
    {
        private readonly IUIVisualizerService _uiVisualizerService;
        private readonly IApplicationLogFilterGroupService _applicationLogFilterGroupService;
        private LogEvent _level;

        #region Constructors
        public AdvancedLogViewerViewModel(IUIVisualizerService uiVisualizerService, IApplicationLogFilterGroupService applicationLogFilterGroupService)
        {
            Argument.IsNotNull(() => uiVisualizerService);
            Argument.IsNotNull(() => applicationLogFilterGroupService);

            _uiVisualizerService = uiVisualizerService;
            _applicationLogFilterGroupService = applicationLogFilterGroupService;

            _level = LogEvent.Error | LogEvent.Warning | LogEvent.Info;

            EditFilterGroups = new TaskCommand(OnEditFilterGroupsExecuteAsync);
        }
        #endregion

        #region Properties
        public bool EnableThreadId { get; set; }

        public Type LogListenerType { get; set; }

        public bool IgnoreCatelLogging { get; set; }

        public bool ShowFilterGroups { get; set; }

        public bool ShowFilterBox { get; set; }

        public List<LogFilterGroup> LogFilterGroups { get; private set; }

        public LogFilterGroup SelectedLogFilterGroup { get; set; }

        public LogEvent Level
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
            get { return Level.HasFlag(LogEvent.Error); }
            set
            {
                if (value)
                {
                    Level |= LogEvent.Error;
                }
                else
                {
                    Level &= ~LogEvent.Error;
                }

                RaisePropertyChanged(nameof(Level));
                RaisePropertyChanged(nameof(ErrorChecked));
            }
        }

        public bool WarningChecked
        {
            get { return Level.HasFlag(LogEvent.Warning); }
            set
            {
                if (value)
                {
                    Level |= LogEvent.Warning;
                }
                else
                {
                    Level &= ~LogEvent.Warning;
                }

                RaisePropertyChanged(nameof(Level));
                RaisePropertyChanged(nameof(WarningChecked));
            }
        }

        public bool InfoChecked
        {
            get { return Level.HasFlag(LogEvent.Info); }
            set
            {
                if (value)
                {
                    Level |= LogEvent.Info;
                }
                else
                {
                    Level &= ~LogEvent.Info;
                }

                RaisePropertyChanged(nameof(Level));
                RaisePropertyChanged(nameof(InfoChecked));
            }
        }

        public bool DebugChecked
        {
            get { return Level.HasFlag(LogEvent.Debug); }
            set
            {
                if (value)
                {
                    Level |= LogEvent.Debug;
                }
                else
                {
                    Level &= ~LogEvent.Debug;
                }

                RaisePropertyChanged(nameof(Level));
                RaisePropertyChanged(nameof(DebugChecked));
            }
        }
        #endregion

        #region Commands
        public TaskCommand EditFilterGroups { get; private set; }

        private async Task OnEditFilterGroupsExecuteAsync()
        {
            await _uiVisualizerService.ShowDialogAsync<LogFilterGroupEditorViewModel>();

            await UpdateAsync();
        }
        #endregion

        #region Methods
        protected override async Task InitializeAsync()
        {
            await base.InitializeAsync();

            await UpdateAsync();
        }

        private async Task UpdateAsync()
        {
            var filterGroups = new List<LogFilterGroup>();

            filterGroups.Add(new LogFilterGroup
            {
                Name = LanguageHelper.GetString("LogViewer_AdvancedLogViewerControl_None")
            });

            var loadedFilterGroups = await _applicationLogFilterGroupService.LoadAsync();
            filterGroups.AddRange(loadedFilterGroups.OrderBy(x => x.Name));

            LogFilterGroups = filterGroups;
            SelectedLogFilterGroup = filterGroups.FirstOrDefault();
        }
        #endregion
    }
}
