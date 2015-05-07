﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AdvancedLogViewerControl.xaml.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.LogViewer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Threading;
    using Catel;
    using Catel.IO;
    using Catel.Logging;
    using Catel.MVVM.Views;
    using Controls;
    using Controls.Logging;
    using ViewModels;
    using Path = System.Windows.Shapes.Path;

    /// <summary>
    /// Interaction logic for AdvancedLogViewerControl.xaml.
    /// </summary>
    public partial class AdvancedLogViewerControl
    {
        #region Constants
        private static readonly Dictionary<LogEvent, Brush> ColorSets = new Dictionary<LogEvent, Brush>();
        #endregion

        #region Fields
        private AdvancedLogViewerViewModel _lastKnownViewModel;
        #endregion

        #region Constructors
        static AdvancedLogViewerControl()
        {
            typeof(AdvancedLogViewerControl).AutoDetectViewPropertiesToSubscribe();
        }

        public AdvancedLogViewerControl()
        {
            InitializeComponent();

            ColorSets[LogEvent.Debug] = Brushes.Gray;
            ColorSets[LogEvent.Info] = Brushes.Black;
            ColorSets[LogEvent.Warning] = Brushes.DarkOrange;
            ColorSets[LogEvent.Error] = Brushes.Red;

            Clear();
        }
        #endregion

        #region Properties
        public bool EnableTimestamp
        {
            get { return (bool)GetValue(EnableTimestampProperty); }
            set { SetValue(EnableTimestampProperty, value); }
        }

        public static readonly DependencyProperty EnableTimestampProperty = DependencyProperty.Register("EnableTimestamp", typeof(bool), 
            typeof(AdvancedLogViewerControl), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                (sender, e) => ((AdvancedLogViewerControl)sender).UpdateControl()));


        public bool EnableIcons
        {
            get { return (bool)GetValue(EnableIconsProperty); }
            set { SetValue(EnableIconsProperty, value); }
        }

        public static readonly DependencyProperty EnableIconsProperty = DependencyProperty.Register("EnableIcons", typeof(bool),
            typeof(AdvancedLogViewerControl), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                (sender, e) => ((AdvancedLogViewerControl)sender).UpdateControl()));


        public bool EnableTextColoring
        {
            get { return (bool)GetValue(EnableTextColoringProperty); }
            set { SetValue(EnableTextColoringProperty, value); }
        }

        public static readonly DependencyProperty EnableTextColoringProperty = DependencyProperty.Register("EnableTextColoring", typeof(bool),
            typeof(AdvancedLogViewerControl), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                (sender, e) => ((AdvancedLogViewerControl)sender).UpdateControl()));


        [ViewToViewModel(MappingType = ViewToViewModelMappingType.TwoWayViewWins)]
        public string LogFilter
        {
            get { return (string)GetValue(LogFilterProperty); }
            set { SetValue(LogFilterProperty, value); }
        }

        public static readonly DependencyProperty LogFilterProperty = DependencyProperty.Register("LogFilter", typeof(string),
            typeof(AdvancedLogViewerControl), new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                (sender, e) => ((AdvancedLogViewerControl)sender).UpdateControl()));

        [ViewToViewModel(MappingType = ViewToViewModelMappingType.TwoWayViewWins)]
        public Type LogListenerType
        {
            get { return (Type)GetValue(LogListenerTypeProperty); }
            set { SetValue(LogListenerTypeProperty, value); }
        }

        public static readonly DependencyProperty LogListenerTypeProperty = DependencyProperty.Register("LogListenerType", typeof(Type),
            typeof(AdvancedLogViewerControl), new FrameworkPropertyMetadata(typeof(LogViewerLogListener), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, 
                (sender, e) => ((AdvancedLogViewerControl)sender).UpdateControl()));


        [ViewToViewModel(MappingType = ViewToViewModelMappingType.TwoWayViewWins)]
        public bool ShowDebug
        {
            get { return (bool)GetValue(ShowDebugProperty); }
            set { SetValue(ShowDebugProperty, value); }
        }

        public static readonly DependencyProperty ShowDebugProperty = DependencyProperty.Register("ShowDebug", typeof(bool),
            typeof(AdvancedLogViewerControl), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                (sender, e) => ((AdvancedLogViewerControl)sender).UpdateControl()));


        [ViewToViewModel(MappingType = ViewToViewModelMappingType.TwoWayViewWins)]
        public bool ShowInfo
        {
            get { return (bool)GetValue(ShowInfoProperty); }
            set { SetValue(ShowInfoProperty, value); }
        }

        public static readonly DependencyProperty ShowInfoProperty = DependencyProperty.Register("ShowInfo", typeof(bool),
            typeof(AdvancedLogViewerControl), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                (sender, e) => ((AdvancedLogViewerControl)sender).UpdateControl()));


        [ViewToViewModel(MappingType = ViewToViewModelMappingType.TwoWayViewWins)]
        public bool ShowWarning
        {
            get { return (bool)GetValue(ShowWarningProperty); }
            set { SetValue(ShowWarningProperty, value); }
        }

        public static readonly DependencyProperty ShowWarningProperty = DependencyProperty.Register("ShowWarning", typeof(bool),
            typeof(AdvancedLogViewerControl), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                (sender, e) => ((AdvancedLogViewerControl)sender).UpdateControl()));


        [ViewToViewModel(MappingType = ViewToViewModelMappingType.TwoWayViewWins)]
        public bool ShowError
        {
            get { return (bool)GetValue(ShowErrorProperty); }
            set { SetValue(ShowErrorProperty, value); }
        }

        public static readonly DependencyProperty ShowErrorProperty = DependencyProperty.Register("ShowError", typeof(bool),
            typeof(AdvancedLogViewerControl), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                (sender, e) => ((AdvancedLogViewerControl)sender).UpdateControl()));
        #endregion

        #region Events
        public event EventHandler<LogEntryDoubleClickEventArgs> LogEntryDoubleClick;
        #endregion

        #region Methods
        protected override void OnViewModelChanged()
        {
            base.OnViewModelChanged();

            if (_lastKnownViewModel != null)
            {
                _lastKnownViewModel.LogMessage -= OnViewModelLogMessage;
                _lastKnownViewModel = null;
            }

            _lastKnownViewModel = ViewModel as AdvancedLogViewerViewModel;
            if (_lastKnownViewModel != null)
            {
                _lastKnownViewModel.LogMessage += OnViewModelLogMessage;
            }
        }

        protected override void OnViewModelPropertyChanged(PropertyChangedEventArgs e)
        {
            base.OnViewModelPropertyChanged(e);

            if (string.Equals(e.PropertyName, "LogListenerType"))
            {
                UpdateControl();
            }
        }

        private void OnViewModelLogMessage(object sender, LogMessageEventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                var vm = (AdvancedLogViewerViewModel) sender;

                var logEntry = new LogEntry(e);
                if (vm.IsValidLogEntry(logEntry))
                {

                    AddLogEntry(logEntry);

                    ScrollToEnd();
                }
            }));
        }

        private void UpdateControl()
        {
            // Using BeginInvoke in order to call properties mapping first. Otherwise filtering by buttons doesen't work.
            // UpdateControl will be called *before* the properties mapping,
            // but because we call BeginInvoke, it will be placed at the end of the execution stack

            Dispatcher.BeginInvoke(new Action(() =>
            {
                ClearScreen();

                var vm = ViewModel as AdvancedLogViewerViewModel;
                if (vm != null)
                {
                    IEnumerable<LogEntry> logEntries = vm.GetFilteredLogEntries();
                    foreach (LogEntry logEntry in logEntries)
                    {
                        AddLogEntry(logEntry);
                    }
                }

                ScrollToEnd();
            }));
        }

        private void AddLogEntry(LogEntry logEntry)
        {
            var vm = ViewModel as AdvancedLogViewerViewModel;
            if (vm == null)
            {
                return;
            }

            var paragraph = new RichTextBoxParagraph(logEntry);
            paragraph.MouseLeftButtonDown += (sender, args) =>
            {
                if (args.ClickCount == 2)
                {
                    LogEntryDoubleClick.SafeInvoke(this, new LogEntryDoubleClickEventArgs(logEntry));
                }
            };

            if (EnableIcons)
            {
                var icon = new Label() { DataContext = logEntry };
                paragraph.Inlines.Add(icon);
            }

            if (EnableTextColoring)
            {
                paragraph.Foreground = ColorSets[logEntry.LogEvent];
            }

            paragraph.SetData(EnableTimestamp);

            LogRecordsRichTextBox.Document.Blocks.Add(paragraph);

        }

        private void ScrollToEnd()
        {
            // TODO: only scroll to end if user has not manually scrolled somewhere else, this code is already in Catel somewhere

            LogRecordsRichTextBox.ScrollToEnd();
        }

        private void ClearScreen()
        {
            LogRecordsRichTextBox.Document.Blocks.Clear();
        }

        public void Clear()
        {
            var vm = ViewModel as AdvancedLogViewerViewModel;
            if (vm != null)
            {
                vm.ClearEntries();
            }

            ClearScreen();
        }
        #endregion
    }
}