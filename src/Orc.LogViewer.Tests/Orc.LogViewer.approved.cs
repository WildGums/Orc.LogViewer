[assembly: System.Resources.NeutralResourcesLanguageAttribute("en-US")]
[assembly: System.Runtime.Versioning.TargetFrameworkAttribute(".NETFramework,Version=v4.6", FrameworkDisplayName=".NET Framework 4.6")]
[assembly: System.Windows.Markup.XmlnsDefinitionAttribute("http://schemas.wildgums.com/orc/logviewer", "Orc.LogViewer")]
[assembly: System.Windows.Markup.XmlnsPrefixAttribute("http://schemas.wildgums.com/orc/logviewer", "orclogviewer")]
[assembly: System.Windows.ThemeInfoAttribute(System.Windows.ResourceDictionaryLocation.None, System.Windows.ResourceDictionaryLocation.SourceAssembly)]
public class static ModuleInitializer
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
        [Catel.MVVM.Views.ViewToViewModelAttribute("", MappingType=Catel.MVVM.Views.ViewToViewModelMappingType.TwoWayViewWins)]
        public bool EnableThreadId { get; set; }
        [Catel.MVVM.Views.ViewToViewModelAttribute("", MappingType=Catel.MVVM.Views.ViewToViewModelMappingType.TwoWayViewWins)]
        public bool IgnoreCatelLogging { get; set; }
        [Catel.MVVM.Views.ViewToViewModelAttribute("", MappingType=Catel.MVVM.Views.ViewToViewModelMappingType.TwoWayViewWins)]
        [System.ComponentModel.TypeConverterAttribute(typeof(Orc.LogViewer.StringToLogEventLevelConverter))]
        public Catel.Logging.LogEvent Level { get; set; }
        [Catel.MVVM.Views.ViewToViewModelAttribute("", MappingType=Catel.MVVM.Views.ViewToViewModelMappingType.TwoWayViewWins)]
        public System.Type LogListenerType { get; set; }
        [Catel.MVVM.Views.ViewToViewModelAttribute("", MappingType=Catel.MVVM.Views.ViewToViewModelMappingType.TwoWayViewWins)]
        public bool ShowFilterBox { get; set; }
        [Catel.MVVM.Views.ViewToViewModelAttribute("", MappingType=Catel.MVVM.Views.ViewToViewModelMappingType.TwoWayViewWins)]
        public bool ShowFilterGroups { get; set; }
        public Orc.Controls.LogViewerControl UnderlyingLogViewerControl { get; }
        public void Clear() { }
        public void InitializeComponent() { }
        public override void OnApplyTemplate() { }
        protected override void OnLoaded(System.EventArgs e) { }
        protected override void OnUnloaded(System.EventArgs e) { }
    }
    public class static LogViewerCommands
    {
        public class static Logging
        {
            public const string Clear = "Logging.Clear";
            public static readonly Catel.Windows.Input.InputGesture ClearInputGesture;
            public const string CopyToClipboard = "Logging.CopyToClipboard";
            public static readonly Catel.Windows.Input.InputGesture CopyToClipboardInputGesture;
            public const string Filter = "Logging.Filter";
            public static readonly Catel.Windows.Input.InputGesture FilterInputGesture;
            public const string OpenInEditor = "Logging.OpenInEditor";
            public static readonly Catel.Windows.Input.InputGesture OpenInEditorInputGesture;
            public const string ToggleDebug = "Logging.ToggleDebug";
            public static readonly Catel.Windows.Input.InputGesture ToggleDebugInputGesture;
            public const string ToggleError = "Logging.ToggleError";
            public static readonly Catel.Windows.Input.InputGesture ToggleErrorInputGesture;
            public const string ToggleInfo = "Logging.ToggleInfo";
            public static readonly Catel.Windows.Input.InputGesture ToggleInfoInputGesture;
            public const string ToggleTimestamp = "Logging.ToggleTimestamp";
            public static readonly Catel.Windows.Input.InputGesture ToggleTimestampInputGesture;
            public const string ToggleWarning = "Logging.ToggleWarning";
            public static readonly Catel.Windows.Input.InputGesture ToggleWarningInputGesture;
        }
    }
    public class static RichTextBoxExtensions
    {
        public static string GetInlineText(this System.Windows.Controls.RichTextBox richTextBox) { }
    }
    public class StringToLogEventLevelConverter : System.ComponentModel.TypeConverter
    {
        public StringToLogEventLevelConverter() { }
        public override bool CanConvertFrom(System.ComponentModel.ITypeDescriptorContext context, System.Type sourceType) { }
        public override object ConvertFrom(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value) { }
    }
    public class static ToggleButtonExtensions
    {
        public static void Toggle(this System.Windows.Controls.Primitives.ToggleButton toggleButton) { }
    }
    public class static UIElementExtensions
    {
        public static void SetTooltip(this System.Windows.UIElement control, Catel.Windows.Input.InputGesture inputGesture) { }
        public static void SetTooltip(this System.Windows.UIElement control, Catel.Windows.Input.InputGesture inputGesture, string text) { }
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
        public AdvancedLogViewerViewModel(Catel.Services.IUIVisualizerService uiVisualizerService, Orc.Controls.IApplicationLogFilterGroupService applicationLogFilterGroupService) { }
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