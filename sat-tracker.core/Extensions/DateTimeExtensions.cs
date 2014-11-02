using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sat_tracker.core.Extensions
{
    public static class DateTimeExtensions
    {
        private static readonly DateTime EpochZero = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static Double ToEpochTime(this DateTime time)
        {
            if (time < EpochZero)
            {
                throw new ArgumentOutOfRangeException("time", "Date before January 1, 1970");
            }

            var diff = (time - EpochZero);

            return diff.TotalSeconds;
        }
    }
}
