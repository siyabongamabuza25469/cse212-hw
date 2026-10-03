using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Week03.Code
{
    public class FeatureCollection
    {
        [JsonPropertyName("type")]
        public string Type { get; set; } = string.Empty;

        [JsonPropertyName("metadata")]
        public Metadata Metadata { get; set; } = new();

        [JsonPropertyName("features")]
        public List<Feature> Features { get; set; } = new();

        [JsonPropertyName("bbox")]
        public List<double> BoundingBox { get; set; } = new();
    }

    public class Metadata
    {
        [JsonPropertyName("generated")]
        public long Generated { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; } = string.Empty;

        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;

        [JsonPropertyName("api")]
        public string Api { get; set; } = string.Empty;

        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("status")]
        public int Status { get; set; }
    }

    public class Feature
    {
        [JsonPropertyName("type")]
        public string Type { get; set; } = string.Empty;

        [JsonPropertyName("properties")]
        public Properties Properties { get; set; } = new();

        [JsonPropertyName("geometry")]
        public Geometry Geometry { get; set; } = new();

        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;
    }

    public class Properties
    {
        [JsonPropertyName("mag")]
        public double? Magnitude { get; set; }

        [JsonPropertyName("place")]
        public string Place { get; set; } = string.Empty;

        [JsonPropertyName("time")]
        public long Time { get; set; }

        [JsonPropertyName("updated")]
        public long Updated { get; set; }

        [JsonPropertyName("tz")]
        public int? TimeZone { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; } = string.Empty;

        [JsonPropertyName("detail")]
        public string Detail { get; set; } = string.Empty;

        [JsonPropertyName("felt")]
        public int? Felt { get; set; }

        [JsonPropertyName("cdi")]
        public double? Cdi { get; set; }

        [JsonPropertyName("mmi")]
        public double? Mmi { get; set; }

        [JsonPropertyName("alert")]
        public string Alert { get; set; } = string.Empty;

        [JsonPropertyName("status")]
        public string Status { get; set; } = string.Empty;

        [JsonPropertyName("tsunami")]
        public int Tsunami { get; set; }

        [JsonPropertyName("sig")]
        public int Significance { get; set; }

        [JsonPropertyName("net")]
        public string Network { get; set; } = string.Empty;

        [JsonPropertyName("code")]
        public string Code { get; set; } = string.Empty;

        [JsonPropertyName("ids")]
        public string Ids { get; set; } = string.Empty;

        [JsonPropertyName("sources")]
        public string Sources { get; set; } = string.Empty;

        [JsonPropertyName("types")]
        public string Types { get; set; } = string.Empty;

        [JsonPropertyName("nst")]
        public int? StationCount { get; set; }

        [JsonPropertyName("dmin")]
        public double? MinimumDistance { get; set; }

        [JsonPropertyName("rms")]
        public double? Rms { get; set; }

        [JsonPropertyName("gap")]
        public double? Gap { get; set; }

        [JsonPropertyName("magType")]
        public string MagnitudeType { get; set; } = string.Empty;

        [JsonPropertyName("type")]
        public string EventType { get; set; } = string.Empty;

        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;
    }

    public class Geometry
    {
        [JsonPropertyName("type")]
        public string Type { get; set; } = string.Empty;

        [JsonPropertyName("coordinates")]
        public List<double> Coordinates { get; set; } = new();
    }
}