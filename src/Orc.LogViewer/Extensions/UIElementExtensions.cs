namespace Orc.LogViewer
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using Catel.Windows.Input;

    public static class UIElementExtensions
    {
        public static void SetTooltip(this UIElement control, InputGesture? inputGesture)
        {
            ArgumentNullException.ThrowIfNull(control);

            SetTooltip(control, inputGesture, string.Empty);
        }

        public static void SetTooltip(this UIElement control, InputGesture? inputGesture, string text)
        {
            ArgumentNullException.ThrowIfNull(control);

            // Note: make nullable, string.Empty will still show up as a tooltip
            string? content = null;

            if (inputGesture is not null)
            {
                content = inputGesture.ToString();
            }

            if (!string.IsNullOrWhiteSpace(text))
            {
                if (string.IsNullOrEmpty(content))
                {
                    content = text;
                }
                else
                {
                    content = text + Environment.NewLine + content;
                }
            }

            ToolTipService.SetToolTip(control, content);
        }
    }
}
