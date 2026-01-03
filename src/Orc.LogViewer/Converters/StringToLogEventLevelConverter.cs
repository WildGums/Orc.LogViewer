namespace Orc.LogViewer
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Linq;
    using Microsoft.Extensions.Logging;

    public class StringToLogEventLevelConverter : TypeConverter
    {
        public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object? value)
        {
            LogLevel result = 0;

            if (value is not string stringValue)
            {
                return result;
            }

            var values = stringValue.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var enumValue in values.Select(x => x.Trim()))
            {
                switch (enumValue.ToLower())
                {
                    case "error":
                        result |= LogLevel.Error | LogLevel.Critical;
                        break;

                    case "warning":
                        result |= LogLevel.Warning;
                        break;

                    case "info":
                        result |= LogLevel.Information;
                        break;

                    case "debug":
                        result |= LogLevel.Debug;
                        break;

                    default:
                        throw new ArgumentOutOfRangeException("value", "Cannot parse the LogEvent value.");
                }
            }

            return result;
        }

        public override bool CanConvertFrom(ITypeDescriptorContext? context, Type? sourceType)
        {
            return sourceType == typeof(string);
        }
    }
}
