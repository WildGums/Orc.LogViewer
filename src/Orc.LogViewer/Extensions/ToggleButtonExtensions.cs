namespace Orc.LogViewer
{
    using System;
    using System.Windows.Controls.Primitives;

    public static class ToggleButtonExtensions
    {
        public static void Toggle(this ToggleButton toggleButton)
        {
            ArgumentNullException.ThrowIfNull(toggleButton);

            toggleButton.SetCurrentValue(ToggleButton.IsCheckedProperty, !toggleButton.IsChecked);
        }
    }
}
