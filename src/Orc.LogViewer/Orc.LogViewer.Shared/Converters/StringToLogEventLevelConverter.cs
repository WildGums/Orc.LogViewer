namespace Orc.LogViewer.Converters
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
                        Log.ErrorAndThrowException<XamlException>("Cannot parse the LogEvent value.");
                        break;
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
