// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ToggleButtonExtensions.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.LogViewer
{
    using System.Windows.Controls.Primitives;

    public static class ToggleButtonExtensions
    {
        public static void Toggle(this ToggleButton toggleButton)
        {
            if (toggleButton.IsChecked == true)
            {
                toggleButton.IsChecked = false;
                return;
            }

            toggleButton.IsChecked = true;
        }
    }
}