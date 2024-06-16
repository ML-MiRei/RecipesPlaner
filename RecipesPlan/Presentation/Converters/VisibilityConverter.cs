using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipesPlan.Presentation.Converters
{
    public class VisibilityConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if(value == null) return false;
            if (value.GetType() == typeof(string) && value + "" == "") return false;
            if(value.GetType() == typeof(double) && (double)value == 0) return false;
            if(value.GetType() == typeof(List<string>) && ((List<string>)value).Count == 0) return false;
            return true;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
