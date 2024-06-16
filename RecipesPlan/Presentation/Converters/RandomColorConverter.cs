using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipesPlan.Presentation.Converters
{
    public class RandomColorConverter : IValueConverter
    {
        private static Dictionary<int, Brush> _myColors = new Dictionary<int, Brush>()
        {
            {0, Brush.Cyan },
            {1, Brush.Magenta },
            {2, Brush.GreenYellow },
            {3, Brush.Blue },
            {4, Brush.Violet },

        };
        
        private static Random _random = new Random();

        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return _myColors[_random.Next(5)];
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
