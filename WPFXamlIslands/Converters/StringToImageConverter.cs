using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace WPFXamlIslands.Converters
{
    public class StringToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string imagePath = $"{AppDomain.CurrentDomain.BaseDirectory}Photos\\{value}.jpg";
            BitmapImage bitmapImage = !string.IsNullOrWhiteSpace(value?.ToString()) &&
                                      File.Exists(imagePath) ?
                new BitmapImage(new Uri(imagePath)) :
                null;
            return bitmapImage;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
