﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LogViewerViewModel.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.LogViewer.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Catel;
    using Catel.IoC;
    using Catel.Logging;
    using Catel.MVVM;
    using Controls.Logging;

    public class AdvancedLogViewerViewModel : ViewModelBase
    {
        private readonly ITypeFactory _typeFactory;

        #region Fields
        private ILogListener _logListener;

        private bool _isViewModelActive;

        private readonly List<LogEntry> _logEntries = new List<LogEntry>();
        #endregion

        #region Constructors
        public AdvancedLogViewerViewModel(ITypeFactory typeFactory)
        {
            Argument.IsNotNull(() => typeFactory);

            _typeFactory = typeFactory;

            LogListenerType = typeof(LogViewerLogListener);
            ShowDebug = true;
            ShowInfo = true;
            ShowWarning = true;
            ShowError = true;

            ResetEntriesCount();
        }
        #endregion

        #region Properties
        public List<LogEntry> LogEntries { get { return _logEntries; } }

        public Type LogListenerType { get; set; }

        public string LogFilter { get; set; }

        public bool ShowDebug { get; set; }
        public bool ShowInfo { get; set; }
        public bool ShowWarning { get; set; }
        public bool ShowError { get; set; }

        public int DebugEntriesCount { get; private set; }
        public int InfoEntriesCount { get; private set; }
        public int WarningEntriesCount { get; private set; }
        public int ErrorEntriesCount { get; private set; }
        #endregion

        #region Events
        public event EventHandler<LogMessageEventArgs> LogMessage;
        #endregion

        #region Methods
        protected override async Task Initialize()
        {
            await base.Initialize();

            _isViewModelActive = true;

            SubscribeLogListener();
        }

        protected override async Task Close()
        {
            UnsubscribeLogListener();

            _isViewModelActive = false;

            await base.Close();
        }

        private void OnLogListenerTypeChanged()
        {
            UnsubscribeLogListener();

            ClearEntries();

            SubscribeLogListener();
        }

        private void SubscribeLogListener()
        {
            if (!_isViewModelActive)
            {
                return;
            }

            var logListenerType = LogListenerType;
            if (logListenerType == null)
            {
                return;
            }

            _logListener = _typeFactory.CreateInstance(logListenerType) as ILogListener;
            if (_logListener != null)
            {
                _logListener.LogMessage += OnLogMessage;

                LogManager.AddListener(_logListener);
            }
        }

        private void UnsubscribeLogListener()
        {
            if (_logListener == null)
            {
                return;
            }

            _logListener.LogMessage -= OnLogMessage;

            LogManager.RemoveListener(_logListener);

            _logListener = null;
        }

        public IEnumerable<LogEntry> GetFilteredLogEntries()
        {
            var entries = new List<LogEntry>();

            lock (_logEntries)
            {
                foreach (var entry in _logEntries)
                {
                    if (IsValidLogEntry(entry))
                    {
                        entries.Add(entry);
                    }
                }
            }

            return entries;
        }

        public bool IsValidLogEntry(LogEntry logEntry)
        {
            if (!PassFilter(logEntry))
            {
                return false;
            }

            if (!IsAcceptable(logEntry.LogEvent))
            {
                return false;
            }

            return true;
        }

        private bool IsAcceptable(LogEvent logEvent)
        {
            switch (logEvent)
            {
                case LogEvent.Debug:
                    return ShowDebug;

                case LogEvent.Info:
                    return ShowInfo;

                case LogEvent.Warning:
                    return ShowWarning;

                case LogEvent.Error:
                    return ShowError;
            }

            return false;
        }

        private bool PassFilter(LogEntry logEntry)
        {
            if (string.IsNullOrEmpty(LogFilter))
            {
                return true;
            }

            var contains = logEntry.Message.IndexOf(LogFilter, StringComparison.OrdinalIgnoreCase) >= 0;

            if (contains)
            {
                return true;
            }

            return false;
        }

        private void OnLogMessage(object sender, LogMessageEventArgs e)
        {
            var logEntry = new LogEntry(e);

            logEntry.Data["ThreadId"] = ThreadHelper.GetCurrentThreadId();

            lock (_logEntries)
            {
                _logEntries.Add(logEntry);
            }

            UpdateEntriesCount(logEntry);

            LogMessage.SafeInvoke(this, e);
        }

        private void UpdateEntriesCount(LogEntry logEvent)
        {
            switch (logEvent.LogEvent)
            {
                case LogEvent.Debug:
                    DebugEntriesCount++;
                    break;
                case LogEvent.Info:
                    InfoEntriesCount++;
                    break;
                case LogEvent.Warning:
                    WarningEntriesCount++;
                    break;
                case LogEvent.Error:
                    ErrorEntriesCount++;
                    break;
            }
        }

        public void ClearEntries()
        {
            lock (_logEntries)
            {
                _logEntries.Clear();
            }

            ResetEntriesCount();
        }

        private void ResetEntriesCount()
        {
            DebugEntriesCount = 0;
            InfoEntriesCount = 0;
            WarningEntriesCount = 0;
            ErrorEntriesCount = 0;
        }
        #endregion
    }
}