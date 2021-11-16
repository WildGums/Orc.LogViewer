[assembly: System.Resources.NeutralResourcesLanguage("en-US")]
[assembly: System.Runtime.Versioning.TargetFramework(".NETCoreApp,Version=v6.0", FrameworkDisplayName="")]
[assembly: System.Windows.Markup.XmlnsDefinition("http://schemas.wildgums.com/orc/logviewer", "Orc.LogViewer")]
[assembly: System.Windows.Markup.XmlnsDefinition("http://schemas.wildgums.com/orc/logviewer", "Orc.LogViewer.Controls")]
[assembly: System.Windows.Markup.XmlnsDefinition("http://schemas.wildgums.com/orc/logviewer", "Orc.LogViewer.Converters")]
[assembly: System.Windows.Markup.XmlnsPrefix("http://schemas.wildgums.com/orc/logviewer", "orclogviewer")]
[assembly: System.Windows.ThemeInfo(System.Windows.ResourceDictionaryLocation.None, System.Windows.ResourceDictionaryLocation.SourceAssembly)]
public static class ModuleInitializer
{
    public static void Initialize() { }
}
namespace Orc.LogViewer
{
    public class AdvancedLogViewerControl : Catel.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector
    {
        public static readonly System.Windows.DependencyProperty AccentColorBrushProperty;
        public static readonly System.Windows.DependencyProperty EnableThreadIdProperty;
        public static readonly System.Windows.DependencyProperty IgnoreCatelLoggingProperty;
        public static readonly System.Windows.DependencyProperty LevelProperty;
        public static readonly System.Windows.DependencyProperty LogListenerTypeProperty;
        public static readonly System.Windows.DependencyProperty ShowFilterBoxProperty;
        public static readonly System.Windows.DependencyProperty ShowFilterGroupsProperty;
        public AdvancedLogViewerControl() { }
        public System.Windows.Media.Brush AccentColorBrush { get; set; }
        [Catel.MVVM.Views.ViewToViewModel("", MappingType=Catel.MVVM.Views.ViewToViewModelMappingType.TwoWayViewWins)]
        public bool EnableThreadId { get; set; }
        [Catel.MVVM.Views.ViewToViewModel("", MappingType=Catel.MVVM.Views.ViewToViewModelMappingType.TwoWayViewWins)]
        public bool IgnoreCatelLogging { get; set; }
        [Catel.MVVM.Views.ViewToViewModel("", MappingType=Catel.MVVM.Views.ViewToViewModelMappingType.TwoWayViewWins)]
        [System.ComponentModel.TypeConverter(typeof(Orc.LogViewer.StringToLogEventLevelConverter))]
        public Catel.Logging.LogEvent Level { get; set; }
        [Catel.MVVM.Views.ViewToViewModel("", MappingType=Catel.MVVM.Views.ViewToViewModelMappingType.TwoWayViewWins)]
        public System.Type LogListenerType { get; set; }
        [Catel.MVVM.Views.ViewToViewModel("", MappingType=Catel.MVVM.Views.ViewToViewModelMappingType.TwoWayViewWins)]
        public bool ShowFilterBox { get; set; }
        [Catel.MVVM.Views.ViewToViewModel("", MappingType=Catel.MVVM.Views.ViewToViewModelMappingType.TwoWayViewWins)]
        public bool ShowFilterGroups { get; set; }
        public Orc.Controls.LogViewerControl UnderlyingLogViewerControl { get; }
        public void Clear() { }
        public void InitializeComponent() { }
        public override void OnApplyTemplate() { }
        protected override void OnLoaded(System.EventArgs e) { }
        protected override void OnUnloaded(System.EventArgs e) { }
    }
    public static class LogViewerCommands
    {
        public static class Logging
        {
            public const string Clear = "Logging.Clear";
            public const string CopyToClipboard = "Logging.CopyToClipboard";
            public const string Filter = "Logging.Filter";
            public const string OpenInEditor = "Logging.OpenInEditor";
            public const string ToggleDebug = "Logging.ToggleDebug";
            public const string ToggleError = "Logging.ToggleError";
            public const string ToggleInfo = "Logging.ToggleInfo";
            public const string ToggleTimestamp = "Logging.ToggleTimestamp";
            public const string ToggleWarning = "Logging.ToggleWarning";
            public static readonly Catel.Windows.Input.InputGesture ClearInputGesture;
            public static readonly Catel.Windows.Input.InputGesture CopyToClipboardInputGesture;
            public static readonly Catel.Windows.Input.InputGesture FilterInputGesture;
            public static readonly Catel.Windows.Input.InputGesture OpenInEditorInputGesture;
            public static readonly Catel.Windows.Input.InputGesture ToggleDebugInputGesture;
            public static readonly Catel.Windows.Input.InputGesture ToggleErrorInputGesture;
            public static readonly Catel.Windows.Input.InputGesture ToggleInfoInputGesture;
            public static readonly Catel.Windows.Input.InputGesture ToggleTimestampInputGesture;
            public static readonly Catel.Windows.Input.InputGesture ToggleWarningInputGesture;
        }
    }
    public static class LogViewerSettings
    {
        public const string LogFilterGroup = "LogViewer.LastKnownLogFilterGroup";
        public static readonly string LogFilterGroupDefaultValue;
    }
    public static class RichTextBoxExtensions
    {
        public static string GetInlineText(this System.Windows.Controls.RichTextBox richTextBox) { }
    }
    public class StringToLogEventLevelConverter : System.ComponentModel.TypeConverter
    {
        public StringToLogEventLevelConverter() { }
        public override bool CanConvertFrom(System.ComponentModel.ITypeDescriptorContext context, System.Type sourceType) { }
        public override object ConvertFrom(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value) { }
    }
    public static class ToggleButtonExtensions
    {
        public static void Toggle(this System.Windows.Controls.Primitives.ToggleButton toggleButton) { }
    }
    public static class UIElementExtensions
    {
        public static void SetTooltip(this System.Windows.UIElement control, Catel.Windows.Input.InputGesture inputGesture) { }
        public static void SetTooltip(this System.Windows.UIElement control, Catel.Windows.Input.InputGesture inputGesture, string text) { }
    }
}
namespace Orc.LogViewer.Controls
{
    public class CategoryPresenter : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector
    {
        public static readonly System.Windows.DependencyProperty CategoryProperty;
        public CategoryPresenter() { }
        public string Category { get; set; }
        public void InitializeComponent() { }
    }
    public class CategoryToggleButton : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector
    {
        public static readonly System.Windows.DependencyProperty CategoryProperty;
        public static readonly System.Windows.DependencyProperty EntryCountProperty;
        public static readonly System.Windows.DependencyProperty IsCheckedProperty;
        public CategoryToggleButton() { }
        public string Category { get; set; }
        public int EntryCount { get; set; }
        public bool IsChecked { get; set; }
        public void InitializeComponent() { }
        public void Toggle() { }
    }
}
namespace Orc.LogViewer.Converters
{
    public class CategoryBorderBrushConverter : Catel.MVVM.Converters.ValueConverterBase<string>
    {
        public static readonly System.Collections.Generic.Dictionary<string, System.Windows.Media.SolidColorBrush> BrushCache;
        public CategoryBorderBrushConverter() { }
        protected override object Convert(string value, System.Type targetType, object parameter) { }
    }
    public class CategoryPathConverter : Catel.MVVM.Converters.ValueConverterBase<string>
    {
        public CategoryPathConverter() { }
        protected override object Convert(string value, System.Type targetType, object parameter) { }
    }
    public class CategoryTextConverter : Catel.MVVM.Converters.ValueConverterBase<string>
    {
        public CategoryTextConverter() { }
        protected override object Convert(string value, System.Type targetType, object parameter) { }
    }
}
namespace Orc.LogViewer.ViewModels
{
    public class AdvancedLogViewerViewModel : Catel.MVVM.ViewModelBase
    {
        public static readonly Catel.Data.PropertyData EnableThreadIdProperty;
        public static readonly Catel.Data.PropertyData IgnoreCatelLoggingProperty;
        public static readonly Catel.Data.PropertyData LogFilterGroupsProperty;
        public static readonly Catel.Data.PropertyData LogListenerTypeProperty;
        public static readonly Catel.Data.PropertyData SelectedLogFilterGroupProperty;
        public static readonly Catel.Data.PropertyData ShowFilterBoxProperty;
        public static readonly Catel.Data.PropertyData ShowFilterGroupsProperty;
        public AdvancedLogViewerViewModel(Catel.Services.IUIVisualizerService uiVisualizerService, Orc.Controls.IApplicationLogFilterGroupService applicationLogFilterGroupService, Catel.Configuration.IConfigurationService configurationService) { }
        public bool DebugChecked { get; set; }
        public Catel.MVVM.TaskCommand EditFilterGroups { get; }
        public bool EnableThreadId { get; set; }
        public bool ErrorChecked { get; set; }
        public bool IgnoreCatelLogging { get; set; }
        public bool InfoChecked { get; set; }
        public Catel.Logging.LogEvent Level { get; set; }
        public System.Collections.Generic.List<Orc.Controls.LogFilterGroup> LogFilterGroups { get; }
        public System.Type LogListenerType { get; set; }
        public Orc.Controls.LogFilterGroup SelectedLogFilterGroup { get; set; }
        public bool ShowFilterBox { get; set; }
        public bool ShowFilterGroups { get; set; }
        public bool WarningChecked { get; set; }
        protected override System.Threading.Tasks.Task InitializeAsync() { }
        protected override void OnPropertyChanged(Catel.Data.AdvancedPropertyChangedEventArgs e) { }
    }
    public class LogFilterGroupEditorViewModel : Catel.MVVM.ViewModelBase
    {
        public LogFilterGroupEditorViewModel() { }
    }
}
namespace Orc.LogViewer.Views
{
    public class LogFilterGroupEditorWindow : Catel.Windows.DataWindow, System.Windows.Markup.IComponentConnector
    {
        public LogFilterGroupEditorWindow() { }
        public void InitializeComponent() { }
    }
}