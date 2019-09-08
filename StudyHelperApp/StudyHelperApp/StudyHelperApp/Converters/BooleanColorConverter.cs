using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace StudyHelperApp.Converters
{
    public class BooleanColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
             bool result = System.Convert.ToBoolean(value);
            string hexColor = string.Empty;
            if (result)
                hexColor = "#a8d17f";
            else
                hexColor = "#fc9999";
            return hexColor;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
           
            throw new NotImplementedException();
        }
    }
}
