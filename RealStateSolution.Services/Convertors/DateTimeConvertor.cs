using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace RealStateSolution.Services.Convertors
{
    public class DateTimeConvertor : JsonConverter<DateTime>
    {
        
        public override DateTime Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            return reader.GetString().ConvertFromMicrosoftFormat();
        }

        public override void Write(
            Utf8JsonWriter writer,
            DateTime dateTime,
            JsonSerializerOptions options)
        {
            writer.WriteStringValue(dateTime.ToString());
        }
    }

    public class NullDateTimeConvertor : JsonConverter<DateTime?>
    {
        public override DateTime? Read(
          ref Utf8JsonReader reader,
          Type typeToConvert,
          JsonSerializerOptions options)
        {
            if (string.IsNullOrEmpty(reader.GetString()))
                return null;

            return reader.GetString().ConvertFromMicrosoftFormat();
        }

        public override void Write(
            Utf8JsonWriter writer,
            DateTime? dateTime,
            JsonSerializerOptions options)
        {
            if (!dateTime.HasValue)
                writer.WriteStringValue(string.Empty);

            writer.WriteStringValue(dateTime.ToString());
        }
    }

    public static class ConvertDate
    {
        static readonly DateTimeOffset s_epoch = new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);
        static readonly Regex s_regex = new Regex("^/Date\\(([^+-]+)([+-])(\\d{2})(\\d{2})\\)/$", RegexOptions.CultureInvariant);
        static readonly Regex s_regex_standard = new Regex("^$", RegexOptions.CultureInvariant);

        public static DateTime ConvertFromMicrosoftFormat(this string dateTime)
        {
            Match match = s_regex.Match(dateTime);



            if (
                    !match.Success
                    || !long.TryParse(match.Groups[1].Value, System.Globalization.NumberStyles.Integer, CultureInfo.InvariantCulture, out long unixTime)
                    || !int.TryParse(match.Groups[3].Value, System.Globalization.NumberStyles.Integer, CultureInfo.InvariantCulture, out int hours)
                    || !int.TryParse(match.Groups[4].Value, System.Globalization.NumberStyles.Integer, CultureInfo.InvariantCulture, out int minutes))
            {
                throw new Exception("Unexpected value format, unable to parse DateTimeOffset.");
            }

            int sign = match.Groups[2].Value[0] == '+' ? 1 : -1;
            TimeSpan utcOffset = new TimeSpan(hours * sign, minutes * sign, 0);

            return s_epoch.AddMilliseconds(unixTime).ToOffset(utcOffset).DateTime;
        }
    }
}
