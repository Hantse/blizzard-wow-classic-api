using System.Text.Json.Serialization;

namespace Blizzard.WoWClassic.ApiContract.Core
{
    public class ValueDisplayString
    {
        [JsonPropertyName("value")]
        public string Value { get; set; }

        [JsonPropertyName("display_string")]
        public string DisplayString { get; set; }
    }
}
