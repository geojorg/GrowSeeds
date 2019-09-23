namespace GrowSeeds.Models
{
    using System;
    using System.Collections;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class StrainsData
    {
        [JsonProperty("WeedStrains")]
        public WeedStrain[] WeedStrains { get; set; }
    }

    public partial class WeedStrain
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("rating")]
        public long Rating { get; set; }

        [JsonProperty("type")]
        public TypeEnum Type { get; set; }

        [JsonProperty("effects")]
        public string Effects { get; set; }

        [JsonProperty("flavor")]
        public string Flavor { get; set; }

        [JsonProperty("thc")]
        public long Thc { get; set; }

        [JsonProperty("cbd")]
        public long Cbd { get; set; }
    }

    public enum TypeEnum { Hybrid, Indica, Sativa };

    public partial class StrainsData
    {
        public static StrainsData FromJson(string json) => JsonConvert.DeserializeObject<StrainsData>(json, GrowSeeds.Models.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this StrainsData self) => JsonConvert.SerializeObject(self, GrowSeeds.Models.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                TypeEnumConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class TypeEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(TypeEnum) || t == typeof(TypeEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "Hybrid":
                    return TypeEnum.Hybrid;
                case "Indica":
                    return TypeEnum.Indica;
                case "Sativa":
                    return TypeEnum.Sativa;
            }
            throw new Exception("Cannot unmarshal type TypeEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (TypeEnum)untypedValue;
            switch (value)
            {
                case TypeEnum.Hybrid:
                    serializer.Serialize(writer, "Hybrid");
                    return;
                case TypeEnum.Indica:
                    serializer.Serialize(writer, "Indica");
                    return;
                case TypeEnum.Sativa:
                    serializer.Serialize(writer, "Sativa");
                    return;
            }
            throw new Exception("Cannot marshal type TypeEnum");
        }

        public static readonly TypeEnumConverter Singleton = new TypeEnumConverter();
    }
}