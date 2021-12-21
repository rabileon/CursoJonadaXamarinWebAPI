using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace JornadaXamarin.MobileApp.Converters
{
    public class PathToImageSourceConverter : IValueConverter
    {
        public PathToImageSourceConverter()
        {

        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string path)
            {
                return ImageSource.FromFile(path);
            }
            else
            {
                return ImageSource.FromFile("camera");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
