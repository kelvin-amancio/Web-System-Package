using System.Globalization;
using System.Text;

namespace WebSystem.Core
{
    public static class WebSystemExtensions
    {
        public static string? FormatDocument(this string? document, int typeDocument)
        {
            if (string.IsNullOrEmpty(document))
                return null;

            if (typeDocument == 1)
                return Convert.ToInt64(document).ToString("00\\.000\\.000\\/0000\\-00");

            if (typeDocument == 2)
                return Convert.ToUInt64(document).ToString(@"000\.000\.000\-00");

            return document;
        }

        public static string? FormatPlateAndCep(this string value, bool hasCep)
        {
            if (string.IsNullOrEmpty(value))
                return value;

            var val = long.Parse(value);

            if (hasCep)
                return val.ToString(@"00000-000");

            return val.ToString(@"000-0000");
        }

        public static string? FormatPhone(this string? value)
        {
            if (string.IsNullOrEmpty(value))
                return null;

            if (value.Length == 11)
            {
                var number = long.Parse(value);
                return number.ToString(@"(00)00000-0000");
            }

            return value;
        }

        public static string? FormartString(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return value;

            if (value.Length > 16)
                return value.Substring(0, 16) + "...";

            return value.Substring(0, value.Length);
        }

        public static string? ToUpperOrDefault(this string? value)
        {
            if (string.IsNullOrEmpty(value))
                return null;

            return value.Trim().ToUpper();
        }

        public static string? ToLowerOrDefault(this string? value)
        {
            if (string.IsNullOrEmpty(value))
                return null;

            return value.Trim().ToLower();
        }

        public static string TrimOrDefault(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return string.Empty;

            return value.Trim();
        }

        public static string? TrimNullOrDefault(this string? value)
        {
            if (string.IsNullOrEmpty(value))
                return string.Empty;

            return value.Trim();
        }


        public static DateTime ToBrazilUTC(this DateTime dateTime)
        {
            TimeZoneInfo zone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");

            return dateTime.AddHours(zone.BaseUtcOffset.Hours);
        }

        public static string? FormattingDate(this DateTime dateTime, int? typeFormat)
        {
            TimeZoneInfo zone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
            var dateUtc = dateTime.AddHours(zone.BaseUtcOffset.Hours);

            if (typeFormat == 1)
                return dateUtc.ToString("dd/MM/yyyy HH:mm:ss");

            if (typeFormat == 2)
                return dateUtc.ToString("dd/MM/yyyy");

            return dateUtc.ToString();
        }

        public static DateTime? ToConvertDatetimeNull(this string? value)
        {
            if (string.IsNullOrEmpty(value))
                return null;

            try
            {
                return Convert.ToDateTime(value);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Date conversion error: {value} - {ex.Message}");
                return null;
            }
        }
        public static Tuple<DateTime?, DateTime?> ToTransformDates(this string? dateRange)
        {
            DateTime? dhStart = null;
            DateTime? dhEnd = null;

            var splitDate = dateRange?.Split('-');
            if (splitDate == null)
                return new Tuple<DateTime?, DateTime?>(dhStart, dhEnd);

            if (splitDate.Length == 0)
                return new Tuple<DateTime?, DateTime?>(dhStart, dhEnd);

            if (splitDate.Length == 2)
            {
                DateTime.TryParseExact(splitDate[0]?.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal, out DateTime dhStartResult);
                DateTime.TryParseExact(splitDate[1]?.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal, out DateTime dhEndResult);
                dhStart = dhStartResult;
                dhEnd = dhEndResult;

                return new Tuple<DateTime?, DateTime?>(dhStart, dhEnd);
            }

            return new Tuple<DateTime?, DateTime?>(dhStart, dhEnd);
        }


        public static DateTime? TransformDate(this string? date)
        {
            if (!string.IsNullOrEmpty(date))
            {
                DateTime.TryParseExact(date, "yyyy-MM-ddTHH:mm:ss.FFFzzz", CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal, out DateTime dateValue);
                return dateValue;
            }

            return null;
        }
    }
}
