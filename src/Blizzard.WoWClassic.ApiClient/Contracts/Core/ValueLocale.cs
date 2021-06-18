using System.Text.Json.Serialization;

namespace Blizzard.WoWClassic.ApiContract.Core
{
    public class ValueLocale
    {
        [JsonPropertyName("en_US")]
        public string EnUs { get; set; }

        [JsonPropertyName("en_GB")]
        public string EnGb { get; set; }

        [JsonPropertyName("fr_FR")]
        public string FrFR { get; set; }
    }
}
