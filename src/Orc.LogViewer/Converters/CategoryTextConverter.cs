namespace Orc.LogViewer.Converters
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using Catel;
    using Catel.MVVM.Converters;

    public class CategoryTextConverter : ValueConverterBase<string>
    {
        private static readonly ImmutableDictionary<string, string?> PathCache;

        static CategoryTextConverter()
        {
            var dictionary = new Dictionary<string, string?>(StringComparer.OrdinalIgnoreCase);

            dictionary["Debug"] = LanguageHelper.GetString("LogViewer_AdvancedLogViewerControl_TextBlock_Text_Debug");
            dictionary["Info"] = LanguageHelper.GetString("LogViewer_AdvancedLogViewerControl_TextBlock_Text_Info");
            dictionary["Warning"] = LanguageHelper.GetString("LogViewer_AdvancedLogViewerControl_TextBlock_Text_Warning");
            dictionary["Error"] = LanguageHelper.GetString("LogViewer_AdvancedLogViewerControl_TextBlock_Text_Error");
            dictionary["Clock"] = null;

            PathCache = dictionary.ToImmutableDictionary(StringComparer.OrdinalIgnoreCase);
        }

        protected override object? Convert(string? value, Type targetType, object? parameter)
        {
            if (value is not string stringValue)
            {
                return null;
            }

            if (PathCache.TryGetValue(stringValue, out var cachedvalue))
            {
                return cachedvalue;
            }

            return null;
        }
    }
}
