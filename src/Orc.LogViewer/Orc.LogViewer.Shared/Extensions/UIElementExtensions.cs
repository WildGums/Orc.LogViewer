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

            if (inputGesture != null)
            {
                content = inputGesture.ToString();
            }

            if (text != string.Empty)
            {
                if (content.Equals(string.Empty))
                {
                    content = text;
                }

                else
                {
                    content = text + Environment.NewLine + content;
                }
            }

            if (content.Equals(string.Empty))
            {
                return;
            }

            var tooltip = new ToolTip() { Content = content };

            ToolTipService.SetToolTip(control, tooltip);
        }
    }
}