using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace covid_tracker.Data.Dto
{
    public class MsEpochConverter : DateTimeConverterBase
    {
        private static readonly DateTime _epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteRawValue(((DateTime)value - _epoch).TotalMilliseconds.ToString());
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null) { return null; }
            return _epoch.AddMilliseconds(long.Parse(reader.Value.ToString()));
        }
    }


    public class DtoLocationHistoryFormat
    {
        [JsonProperty("locations")]
        public List<DtoLocation> Locations { get; set; }
    }

    public class DtoLocation
    {
        [JsonProperty("timestampMS")]
        [JsonConverter(typeof(MsEpochConverter))]
        public DateTime Timestamp { get; set; }

        [JsonProperty("latitudeE7")]
        public double LatitudeE7 { get; set; }

        [JsonProperty("longitudeE7")]
        public double LongitudeE7 { get; set; }
        [JsonProperty("accuracy")]
        public int Accuracy { get; set; }
        [JsonProperty("altitude")]
        public int Altitude { get; set; }
        [JsonProperty("verticalAccuracy")]
        public int VerticalAccuracy { get; set; }

        [JsonProperty("activity")]
        public List<DtoActivity> Activities { get; set; }
    }

    public class DtoActivity
    {
        [JsonProperty("timestampMS")]
        public string TimestampMS { get; set; }

        [JsonProperty("activity")]
        public List<DtoActivityItem> ActivityItems { get; set; }

    }

    public class DtoActivityItem
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("confidence")]
        public int Confidence { get; set; }
    }
}
