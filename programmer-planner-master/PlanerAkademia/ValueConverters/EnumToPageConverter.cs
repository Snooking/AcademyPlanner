using System;
using System.Diagnostics;
using System.Globalization;

namespace PlanerAkademia
{
    public class EnumToPageConverter : BaseValueConverter<EnumToPageConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((AppPages)value)
            {
                case AppPages.SignIn:
                    return new SignIn();

                case AppPages.SignUp:
                    return new SignUp();

                case AppPages.AddEvents:
                    return new AddEvent();

                case AppPages.ShowEvents:
                    return new ShowEvents();

                default:
                    Debugger.Break();
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
