#define TEST_INPUTGESTURES

namespace Orc.LogViewer
{
    using System.Windows.Input;
    using InputGesture = Catel.Windows.Input.InputGesture;

    public static class LogViewerCommands
    {
        public static class Logging
        {
            public const string ToggleError = "Logging.ToggleError";

#if DEBUG && TEST_INPUTGESTURES
            public static readonly InputGesture ToggleErrorInputGesture = new InputGesture(Key.E, ModifierKeys.Control);
#else
            public static readonly InputGesture ToggleErrorInputGesture = null;
#endif

            public const string ToggleWarning = "Logging.ToggleWarning";

#if DEBUG && TEST_INPUTGESTURES
            public static readonly InputGesture ToggleWarningInputGesture = new InputGesture(Key.W, ModifierKeys.Control);
#else
            public static readonly InputGesture ToggleWarningInputGesture = null;
#endif

            public const string ToggleDebug = "Logging.ToggleDebug";

#if DEBUG && TEST_INPUTGESTURES
            public static readonly InputGesture ToggleDebugInputGesture = new InputGesture(Key.D, ModifierKeys.Control);
#else
            public static readonly InputGesture ToggleDebugInputGesture = null;
#endif

            public const string ToggleInfo = "Logging.ToggleInfo";

#if DEBUG && TEST_INPUTGESTURES
            public static readonly InputGesture ToggleInfoInputGesture = new InputGesture(Key.I, ModifierKeys.Control);
#else
            public static readonly InputGesture ToggleInfoInputGesture = null;
#endif

            public const string ToggleTimestamp = "Logging.ToggleTimestamp";

#if DEBUG && TEST_INPUTGESTURES
            public static readonly InputGesture ToggleTimestampInputGesture = new InputGesture(Key.T, ModifierKeys.Control);
#else
            public static readonly InputGesture ToggleTimestampInputGesture = null;
#endif

            public const string Clear = "Logging.Clear";
#if DEBUG && TEST_INPUTGESTURES
            public static readonly InputGesture ClearInputGesture = new InputGesture(Key.X, ModifierKeys.Control);
#else
            public static readonly InputGesture ClearInputGesture = null;
#endif

            public const string CopyToClipboard = "Logging.CopyToClipboard";
#if DEBUG && TEST_INPUTGESTURES
            public static readonly InputGesture CopyToClipboardInputGesture = new InputGesture(Key.C, ModifierKeys.Control);
#else
            public static readonly InputGesture CopyToClipboardInputGesture = null;
#endif

            public const string OpenInEditor = "Logging.OpenInEditor";
#if DEBUG && TEST_INPUTGESTURES
            public static readonly InputGesture OpenInEditorInputGesture = new InputGesture(Key.O, ModifierKeys.Control);
#else
            public static readonly InputGesture OpenInEditorInputGesture = null;
#endif

            public const string Filter = "Logging.Filter";
#if DEBUG && TEST_INPUTGESTURES
            public static readonly InputGesture FilterInputGesture = new InputGesture(Key.F, ModifierKeys.Control);
#else
            public static readonly InputGesture FilterInputGesture = null;
#endif
        }
    }

    public static class LogViewerSettings
    {
        public const string LogFilterGroup = "LogViewer.LastKnownLogFilterGroup";
        public static readonly string LogFilterGroupDefaultValue = string.Empty;
    }
}
