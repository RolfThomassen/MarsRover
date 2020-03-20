using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace MarsRover.Modules
{
    public static class StringConverters
    {

        public static Int32 ToInt32(this String number)
        {
            int res = 0;
            try
            {
                res = Int32.Parse(number, NumberStyles.Integer, CultureInfo.CurrentCulture.NumberFormat);
            }
            catch (Exception) { throw; }
            return res;
        }
    }
}
