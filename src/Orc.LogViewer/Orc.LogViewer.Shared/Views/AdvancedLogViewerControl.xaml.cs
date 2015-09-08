// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AdvancedLogViewerControl.xaml.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.LogViewer
{
    using System;
    using System.ComponentModel;
    using System.IO;
    using System.Security;
    using System.Windows;
    using System.Windows.Media;
    using Catel.IoC;
    using Catel.Logging;
    using Catel.MVVM;
    using Catel.MVVM.Views;
    using Catel.Services;
    using Controls;
    using Controls.Logging;

    /// <summary>
    /// Interaction logic for AdvancedLogViewerControl.xaml.
    /// </summary>
    public partial class AdvancedLogViewerControl
    {
        #region Fields
        private readonly ICommandManager _commandManager;
        private readonly IProcessService _processService;
        #endregion

        #region Constructors
        static AdvancedLogViewerControl()
        {
            typeof (AdvancedLogViewerControl).AutoDetectViewPropertiesToSubscribe();
        }

        public AdvancedLogViewerControl()
        {
            InitializeComponent();

            var serviceLocator = ServiceLocator.Default;

            _commandManager = serviceLocator.ResolveType<ICommandManager>();
            _processService = serviceLocator.ResolveType<IProcessService>();

            CreateTooltips();
        }
        #endregion

        #region Properties
        public Brush AccentColorBrush
        {
            get { return (Brush) GetValue(AccentColorBrushProperty); }
            set { SetValue(AccentColorBrushProperty, value); }
        }

        public static readonly DependencyProperty AccentColorBrushProperty = DependencyProperty.Register("AccentColorBrush", typeof (Brush),
            typeof (AdvancedLogViewerControl), new FrameworkPropertyMetadata(Brushes.LightGray, (sender, e) => ((AdvancedLogViewerControl) sender).OnAccentColorBrushChanged()));

        [ViewToViewModel(MappingType = ViewToViewModelMappingType.TwoWayViewWins)]
        public Type LogListenerType
        {
            get { return (Type) GetValue(LogListenerTypeProperty); }
            set { SetValue(LogListenerTypeProperty, value); }
        }

        public static readonly DependencyProperty LogListenerTypeProperty = DependencyProperty.Register("LogListenerType", typeof (Type),
            typeof (AdvancedLogViewerControl), new FrameworkPropertyMetadata(typeof (LogViewerLogListener), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        [ViewToViewModel(MappingType = ViewToViewModelMappingType.TwoWayViewWins)]
        public bool IgnoreCatelLogging
        {
            get { return (bool) GetValue(IgnoreCatelLoggingProperty); }
            set { SetValue(IgnoreCatelLoggingProperty, value); }
        }

        public static readonly DependencyProperty IgnoreCatelLoggingProperty = DependencyProperty.Register("IgnoreCatelLogging", typeof (bool),
            typeof (AdvancedLogViewerControl), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        [ViewToViewModel(MappingType = ViewToViewModelMappingType.TwoWayViewWins)]
        public bool ShowTypeNames
        {
            get { return (bool) GetValue(ShowTypeNamesProperty); }
            set { SetValue(ShowTypeNamesProperty, value); }
        }

        public static readonly DependencyProperty ShowTypeNamesProperty = DependencyProperty.Register("ShowTypeNames", typeof (bool),
            typeof (AdvancedLogViewerControl), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        [ViewToViewModel(MappingType = ViewToViewModelMappingType.TwoWayViewWins)]
        public bool ShowFilterBox
        {
            get { return (bool) GetValue(ShowFilterBoxProperty); }
            set { SetValue(ShowFilterBoxProperty, value); }
        }

        public static readonly DependencyProperty ShowFilterBoxProperty = DependencyProperty.Register("ShowFilterBox", typeof (bool),
            typeof (AdvancedLogViewerControl), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        [TypeConverter(typeof (StringToLogEventLevelConverter))]
        [ViewToViewModel(MappingType = ViewToViewModelMappingType.TwoWayViewWins)]
        public LogEvent Level
        {
            get { return (LogEvent) GetValue(LevelProperty); }
            set { SetValue(LevelProperty, value); }
        }

        public static readonly DependencyProperty LevelProperty = DependencyProperty.Register("Level", typeof (LogEvent),
            typeof (AdvancedLogViewerControl), new FrameworkPropertyMetadata(LogEvent.Error | LogEvent.Warning | LogEvent.Info, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public LogViewerControl UnderlyingLogViewerControl
        {
            get { return LogViewerControl; }
        }
        #endregion

        #region Methods
        protected override void OnLoaded(EventArgs e)
        {
            // Commands that require a view component cannot live inside a CommandContainer
            // because they must access a view (which is probably not registered inside the ServiceLocator).
            // In such a case, you can manually add actions to the ICommandManager. Don't forget to
            // remove them again in the Unloaded.

            _commandManager.RegisterAction(LogViewerCommands.Logging.Clear, Clear);
            _commandManager.RegisterAction(LogViewerCommands.Logging.CopyToClipboard, CopyToClipboard);
            _commandManager.RegisterAction(LogViewerCommands.Logging.OpenInEditor, OpenInEditor);
            _commandManager.RegisterAction(LogViewerCommands.Logging.ToggleError, ToggleError);
            _commandManager.RegisterAction(LogViewerCommands.Logging.ToggleWarning, ToggleWarning);
            _commandManager.RegisterAction(LogViewerCommands.Logging.ToggleDebug, ToggleDebug);
            _commandManager.RegisterAction(LogViewerCommands.Logging.ToggleInfo, ToggleInfo);
            _commandManager.RegisterAction(LogViewerCommands.Logging.ToggleTimestamp, ToggleTimestamp);
        }

        protected override void OnUnloaded(EventArgs e)
        {
            _commandManager.UnregisterAction(LogViewerCommands.Logging.Clear, Clear);
            _commandManager.UnregisterAction(LogViewerCommands.Logging.CopyToClipboard, CopyToClipboard);
            _commandManager.UnregisterAction(LogViewerCommands.Logging.OpenInEditor, OpenInEditor);
            _commandManager.UnregisterAction(LogViewerCommands.Logging.ToggleError, ToggleError);
            _commandManager.UnregisterAction(LogViewerCommands.Logging.ToggleWarning, ToggleWarning);
            _commandManager.UnregisterAction(LogViewerCommands.Logging.ToggleDebug, ToggleDebug);
            _commandManager.UnregisterAction(LogViewerCommands.Logging.ToggleInfo, ToggleInfo);
            _commandManager.UnregisterAction(LogViewerCommands.Logging.ToggleTimestamp, ToggleTimestamp);
        }

        private void ToggleTimestamp()
        {
            EnableTimestampToggleButton.Toggle();
        }

        private void ToggleError()
        {
            ShowErrorToggleButton.Toggle();
        }

        private void ToggleWarning()
        {
            ShowWarningToggleButton.Toggle();
        }

        private void ToggleDebug()
        {
            ShowDebugToggleButton.Toggle();
        }

        private void ToggleInfo()
        {
            ShowInfoToggleButton.Toggle();
        }

        public void Clear()
        {
            LogViewerControl.Clear();
        }

        private void CopyToClipboard()
        {
            LogViewerControl.CopyToClipboard();
        }

        private void OpenInEditor()
        {
            var path = string.Empty;
            try
            {
                path = Path.GetTempPath();
            }
            catch (SecurityException)
            {
                return;
            }
            var filePath = CreateLogFile(path);
            _processService.StartProcess(filePath);
        }

        private string CreateLogFile(string path)
        {
            var filePath = Path.Combine(path, "log.txt");
            File.WriteAllText(filePath, GetLog());
            return filePath;
        }

        private string GetLog()
        {
            LogViewerControl.CopyToClipboard();

            var dataObject = Clipboard.GetDataObject();
            if (dataObject == null)
            {
                return string.Empty;
            }

            return dataObject.GetData(DataFormats.Text).ToString();
        }

        private void CreateTooltips()
        {
            ShowErrorToggleButton.SetTooltip(LogViewerCommands.Logging.ToggleErrorInputGesture);
            ShowWarningToggleButton.SetTooltip(LogViewerCommands.Logging.ToggleWarningInputGesture);
            ShowInfoToggleButton.SetTooltip(LogViewerCommands.Logging.ToggleInfoInputGesture);
            ShowDebugToggleButton.SetTooltip(LogViewerCommands.Logging.ToggleDebugInputGesture);

            EnableTimestampToggleButton.SetTooltip(LogViewerCommands.Logging.ToggleTimestampInputGesture, "Show timestamps");
            FilterBox.SetTooltip(LogViewerCommands.Logging.FilterInputGesture);

            ClearButton.SetTooltip(LogViewerCommands.Logging.ClearInputGesture);
            CopyButton.SetTooltip(LogViewerCommands.Logging.CopyToClipboardInputGesture);
            OpenButton.SetTooltip(LogViewerCommands.Logging.OpenInEditorInputGesture);
        }

        private void OnAccentColorBrushChanged()
        {
            var solidColorBrush = AccentColorBrush as SolidColorBrush;
            if (solidColorBrush != null)
            {
                var accentColor = ((SolidColorBrush) AccentColorBrush).Color;
                accentColor.CreateAccentColorResourceDictionary("Controls");
            }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            AccentColorBrush = TryFindResource("AccentColorBrush") as SolidColorBrush;
        }
        #endregion
    }
}