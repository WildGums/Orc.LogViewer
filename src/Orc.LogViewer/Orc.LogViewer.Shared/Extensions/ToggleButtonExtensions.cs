// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ToggleButtonExtensions.cs" company="WildGums">
//   Copyright (c) 2008 - 2015 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.LogViewer
{
    using System.Windows.Controls.Primitives;

    public static class ToggleButtonExtensions
    {
        public static void Toggle(this ToggleButton toggleButton)
        {
            toggleButton.SetCurrentValue(ToggleButton.IsCheckedProperty, !toggleButton.IsChecked);
        }
    }
}