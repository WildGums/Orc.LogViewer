// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UIElementExtensions.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.LogViewer
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using Catel.Windows.Input;

    public static class UIElementExtensions
    {
        public static void SetTooltip(this UIElement control, InputGesture inputGesture)
        {
            SetTooltip(control, inputGesture, string.Empty);
        }

        public static void SetTooltip(this UIElement control, InputGesture inputGesture, string text)
        {
            var content = string.Empty;
            if (text != string.Empty)
            {
                content = text + Environment.NewLine;
            }
            var tooltip = new ToolTip() { Content = content + inputGesture };
            ToolTipService.SetToolTip(control, tooltip);
        }
    }
}