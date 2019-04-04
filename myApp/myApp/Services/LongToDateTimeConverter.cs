using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace myApp.Services
{
    //https://social.msdn.microsoft.com/Forums/vstudio/en-US/557cb426-e06b-448c-a668-77b0b2a82c38/long-format-datetime-format-?forum=csharpgeneral
    //https://www.google.com/search?rlz=1C1CHBF_enIE829IE829&ei=UOylXJ3HA9ik1fAPl6K0iAY&q=LongToDateTImerConverter+c%23&oq=LongToDateTImerConverter+c%23&gs_l=psy-ab.3...927.1357..1563...0.0..0.110.301.1j2......0....1..gws-wiz.......0i71j33i21j33i160.MRqihIplDIU
    public class LongToDateTimeConverter : IValueConverter
    {
        DateTime time = new DateTime(1970, 1, 1, 0, 0, 0, 0);

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            long dateTime = (long)value;
            return $"{time.AddSeconds(dateTime).ToString()} UTC";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
