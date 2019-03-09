using System;

namespace IEXStock.Helpers
{
    public static class Time
    {
        // Converts Epoch Time to Local DateTime(UTC).
        public static DateTime FromUnixTime(this long unixTime)
		{
			var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
			return epoch.AddMilliseconds(unixTime).ToLocalTime();
		}

        // Converts DateTime(UTC) to Epoch Time.
		public static long ToUnixTime(this DateTime date)
		{
			var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
			return Convert.ToInt64((date - epoch).TotalSeconds);
		}

		// Converts a String in DateTime Format to DateTime
		// Enter string date and the format. Eg. ("2019-10-10", "yyyy-MM-dd")
		public static DateTime StringToDateTime(string dateSting, string format)
		{
			return DateTime.ParseExact(dateSting, format, System.Globalization.CultureInfo.InvariantCulture);
		}
    }
}