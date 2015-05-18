// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Constants.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

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
            public static readonly InputGesture ClearInputGesture = null;
#endif

            public const string Clear = "Logging.Clear";
#if DEBUG && TEST_INPUTGESTURES
            public static readonly InputGesture ClearInputGesture = new InputGesture(Key.X, ModifierKeys.Control | ModifierKeys.Shift);
#else
            public static readonly InputGesture ClearInputGesture = null;
#endif

            public const string CopyToClipboard = "Logging.CopyToClipboard";
#if DEBUG && TEST_INPUTGESTURES
            public static readonly InputGesture CopyToClipboardInputGesture = new InputGesture(Key.C, ModifierKeys.Control | ModifierKeys.Shift);
#else
            public static readonly InputGesture CopyToClipboardInputGesture = null;
#endif

            public const string OpenInEditor = "Logging.OpenInEditor";
#if DEBUG && TEST_INPUTGESTURES
            public static readonly InputGesture OpenInEditorInputGesture = new InputGesture(Key.O, ModifierKeys.Control | ModifierKeys.Shift);
#else
            public static readonly InputGesture OpenInEditorInputGesture = null;
#endif
        }
    }
}