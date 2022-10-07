namespace Orc.LogViewer.Converters
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Windows.Media;
    using Catel.MVVM.Converters;

    public class CategoryBorderBrushConverter : ValueConverterBase<string>
    {
        public static readonly ImmutableDictionary<string, SolidColorBrush?> BrushCache;

        static CategoryBorderBrushConverter()
        {
            var dictionary = new Dictionary<string, SolidColorBrush?>(StringComparer.OrdinalIgnoreCase);

            dictionary["Debug"] = new SolidColorBrush(Colors.DarkGray);
            dictionary["Info"] = new SolidColorBrush(Colors.RoyalBlue);
            dictionary["Warning"] = new SolidColorBrush(Colors.DarkOrange);
            dictionary["Error"] = new SolidColorBrush(Colors.Red);
            dictionary["Clock"] = new SolidColorBrush(Colors.Gray);

            BrushCache = dictionary.ToImmutableDictionary(StringComparer.OrdinalIgnoreCase);
        }

        protected override object? Convert(string? value, Type targetType, object? parameter)
        {
            if (value is not string stringValue)
            {
                return null;
            }

            if (BrushCache.TryGetValue(stringValue, out var brush))
            {
                return brush;
            }

            return Brushes.Black;
        }
    }
}
