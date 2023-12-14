namespace Orc.LogViewer.Converters
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Windows;
    using System.Windows.Media;
    using Catel.MVVM.Converters;

    public class CategoryPathConverter : ValueConverterBase<string>
    {
        private static readonly ImmutableDictionary<string, Geometry?> PathCache;

        static CategoryPathConverter()
        {
            var application = Application.Current;

            var dictionary = new Dictionary<string, Geometry?>(StringComparer.OrdinalIgnoreCase);

            dictionary["Debug"] = application.TryFindResource("LogDebugGeometry") as Geometry;
            dictionary["Info"] = application.TryFindResource("LogInfoGeometry") as Geometry;
            dictionary["Warning"] = application.TryFindResource("LogWarningGeometry") as Geometry;
            dictionary["Error"] = application.TryFindResource("LogErrorGeometry") as Geometry;
            dictionary["Clock"] = application.TryFindResource("LogClockGeometry") as Geometry;

            PathCache = dictionary.ToImmutableDictionary(StringComparer.OrdinalIgnoreCase);
        }

        protected override object? Convert(string? value, Type targetType, object? parameter)
        {
            if (value is not string stringValue)
            {
                return null;
            }

            if (PathCache.TryGetValue(stringValue, out var geometry))
            {
                return geometry;
            }

            return null;
        }
    }
}
