// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StringToLogEventLevelConverter.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.LogViewer
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Linq;
    using System.Xaml;
    using Catel.Logging;

    public class StringToLogEventLevelConverter : TypeConverter
    {
        private readonly ILog Log = LogManager.GetCurrentClassLogger();
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            var values = ((string)value).Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            LogEvent result = 0;
            foreach (var enumValue in values.Select(x => x.Trim()))
            {
                switch (enumValue.ToLower())
                {
                    case "error":
                        result |= LogEvent.Error;
                        break;

                    case "warning":
                        result |= LogEvent.Warning;
                        break;

                    case "info":
                        result |= LogEvent.Info;
                        break;

                    case "debug":
                        result |= LogEvent.Debug;
                        break;

                    default:
                        throw Log.ErrorAndCreateException<XamlException>("Cannot parse the LogEvent value.");
                }
            }
            return result;
        }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string);
        }
    }

}
