using System;
using System.Globalization;
using Microsoft.VisualBasic;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        public string convertTime(string aTime)
        {
            var berlimClockArray = new string[5];
            var aTimeArray = aTime.Split(':');
            var fourthRowPattern = "YYRYYRYYRYY";
            var hours = Convert.ToInt32(aTimeArray[0]);
            var minutes = Convert.ToInt32(aTimeArray[1]);
            var seconds = Convert.ToInt32(aTimeArray[2]);

            berlimClockArray[0] = seconds % 2 == 0 ? "Y" : "O";
            berlimClockArray[1] = new String('R', hours / 5).PadRight(4, 'O');
            berlimClockArray[2] = new String('R', hours % 5).PadRight(4, 'O');
            berlimClockArray[3] = fourthRowPattern.Substring(0, minutes / 5).PadRight(fourthRowPattern.Length, 'O');
            berlimClockArray[4] = new String('Y', minutes % 5).PadRight(4, 'O');

            return String.Join(Environment.NewLine, berlimClockArray);
        }
    }
}
