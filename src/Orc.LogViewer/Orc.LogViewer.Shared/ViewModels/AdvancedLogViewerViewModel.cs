// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AdvancedLogViewerViewModel.cs" company="WildGums">
//   Copyright (c) 2008 - 2015 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.LogViewer.ViewModels
{
    using System;
    using Catel.Logging;
    using Catel.MVVM;

    public class AdvancedLogViewerViewModel : ViewModelBase
    {
        private LogEvent _level;

        #region Constructors
        public AdvancedLogViewerViewModel()
        {
            _level = LogEvent.Error | LogEvent.Warning | LogEvent.Info;
        }
        #endregion

        #region Properties
        public Type LogListenerType { get; set; }

        public bool IgnoreCatelLogging { get; set; }

        public bool ShowTypeNames { get; set; }

        public bool ShowFilterBox { get; set; }

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

                RaisePropertyChanged("ErrorChecked");
                RaisePropertyChanged("WarningChecked");
                RaisePropertyChanged("DebugChecked");
                RaisePropertyChanged("InfoChecked");
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

                RaisePropertyChanged("Level");
                RaisePropertyChanged("ErrorChecked");
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

                RaisePropertyChanged("Level");
                RaisePropertyChanged("WarningChecked");
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

                RaisePropertyChanged("Level");
                RaisePropertyChanged("InfoChecked");
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

                RaisePropertyChanged("Level");
                RaisePropertyChanged("DebugChecked");
            }
        }

        #endregion
    }
}