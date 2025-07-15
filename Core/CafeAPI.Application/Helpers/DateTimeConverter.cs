using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CafeAPI.Application.Helpers
{
    public class DateTimeConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                return DateTime.ParseExact(reader.GetString(), "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
            }
            return reader.GetDateTime();
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString("yyyy-MM-dd HH:mm"));
        }
    }
}
