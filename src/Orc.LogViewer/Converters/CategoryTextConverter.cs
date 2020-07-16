namespace Orc.LogViewer.Converters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Media;
    using Catel;
    using Catel.MVVM.Converters;

    public class CategoryTextConverter : ValueConverterBase<string>
    {
        private static readonly Dictionary<string, string> PathCache = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        static CategoryTextConverter()
        {
            var application = Application.Current;

            PathCache["Debug"] = LanguageHelper.GetString("LogViewer_AdvancedLogViewerControl_TextBlock_Text_Debug");
            PathCache["Info"] = LanguageHelper.GetString("LogViewer_AdvancedLogViewerControl_TextBlock_Text_Info");
            PathCache["Warning"] = LanguageHelper.GetString("LogViewer_AdvancedLogViewerControl_TextBlock_Text_Warning");
            PathCache["Error"] = LanguageHelper.GetString("LogViewer_AdvancedLogViewerControl_TextBlock_Text_Error");
            PathCache["Clock"] = null;
        }

        protected override object Convert(string value, Type targetType, object parameter)
        {
            if (PathCache.TryGetValue(value, out var cachedvalue))
            {
                return cachedvalue;
            }

            return null;
        }
    }
}
