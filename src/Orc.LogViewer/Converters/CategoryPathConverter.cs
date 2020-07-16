namespace Orc.LogViewer.Converters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Media;
    using Catel.MVVM.Converters;

    public class CategoryPathConverter : ValueConverterBase<string>
    {
        private static readonly Dictionary<string, Geometry> PathCache = new Dictionary<string, Geometry>(StringComparer.OrdinalIgnoreCase);

        static CategoryPathConverter()
        {
            var application = Application.Current;

            PathCache["Debug"] = application.TryFindResource("LogDebugGeometry") as Geometry;
            PathCache["Info"] = application.TryFindResource("LogInfoGeometry") as Geometry;
            PathCache["Warning"] = application.TryFindResource("LogWarningGeometry") as Geometry;
            PathCache["Error"] = application.TryFindResource("LogErrorGeometry") as Geometry;
            PathCache["Clock"] = application.TryFindResource("LogClockGeometry") as Geometry;
        }

        protected override object Convert(string value, Type targetType, object parameter)
        {
            if (PathCache.TryGetValue(value, out var geometry))
            {
                return geometry;
            }

            return null;
        }
    }
}
