// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LogEventLevelToBoolConverter.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.LogViewer.Converters
{
    using System;
    using Catel.Logging;
    using Catel.MVVM.Converters;

    public class LogEventLevelToBoolConverter : ValueConverterBase
    {
        protected override object Convert(object value, Type targetType, object parameter)
        {
            var logEvent = (LogEvent) value;
            var control = (LogEvent) parameter;
            switch (control)
            {
                case LogEvent.Error:
                    return (logEvent & LogEvent.Error) == LogEvent.Error;
                case LogEvent.Warning:
                    return (logEvent & LogEvent.Warning) == LogEvent.Warning;
                case LogEvent.Debug:
                    return (logEvent & LogEvent.Debug) == LogEvent.Debug;
                case LogEvent.Info:
                    return (logEvent & LogEvent.Info) == LogEvent.Info;
            }
            throw new InvalidOperationException();
        }
    }
}