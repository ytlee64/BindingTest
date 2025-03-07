using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Data;

namespace BindingTest
{
    public class IndexToValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ObservableCollection<string> list && parameter is string indexString)
            {
                int index = int.Parse(indexString);
                return list[index];
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class IntToHexConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int integerValue)
            {
                return "0x"+integerValue.ToString("X");
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string hexString && int.TryParse(hexString, NumberStyles.HexNumber, culture, out int integerValue))
            {
                return integerValue;
            }
            return value;
        }
    }
    public class DoubleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double doubleValue && parameter is string formatString)
            {
                return doubleValue.ToString(formatString);
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public partial class MainWindowVM : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<string> _items;

        [ObservableProperty]
        private int _integerValue;

        [ObservableProperty]
        private double _doubleValue;

        [ObservableProperty]
        private string _stringValue;

        public MainWindowVM()
        {
            _items = new ObservableCollection<string>
                {
                    "item1",
                    "item2",
                    "item3"
                };
            _stringValue = "myStringValue";
            _integerValue = 42; 
            _doubleValue = 1 / 3.0;
        }
    }


}
