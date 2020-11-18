namespace Orc.LogViewer.Converters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Media;
    using Catel.MVVM.Converters;

    public class CategoryBorderBrushConverter : ValueConverterBase<string>
    {
        public static readonly Dictionary<string, SolidColorBrush> BrushCache = new Dictionary<string, SolidColorBrush>(StringComparer.OrdinalIgnoreCase);

        static CategoryBorderBrushConverter()
        {
            BrushCache["Debug"] = new SolidColorBrush(Colors.DarkGray);
            BrushCache["Info"] = new SolidColorBrush(Colors.RoyalBlue);
            BrushCache["Warning"] = new SolidColorBrush(Colors.DarkOrange);
            BrushCache["Error"] = new SolidColorBrush(Colors.Red);
            BrushCache["Clock"] = new SolidColorBrush(Colors.Gray);
        }

        protected override object Convert(string value, Type targetType, object parameter)
        {
            if (BrushCache.TryGetValue(value, out var brush))
            {
                return brush;
            }

            return Brushes.Black;
        }
    }
}
