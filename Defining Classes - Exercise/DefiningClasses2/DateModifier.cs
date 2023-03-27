using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses2
{
    public class DateModifier
    {
        public static int GetDiff(string firstDate, string secondDate) 
        {
            DateTime first = DateTime.Parse(firstDate);
            DateTime second = DateTime.Parse(secondDate);

            int result = Math.Abs((int)(first - second).TotalDays);

            return result;
        }


    }
}
