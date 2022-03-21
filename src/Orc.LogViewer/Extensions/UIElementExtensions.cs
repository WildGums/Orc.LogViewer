// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UIElementExtensions.cs" company="WildGums">
//   Copyright (c) 2008 - 2015 WildGums. All rights reserved.
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
            string content = null;

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
