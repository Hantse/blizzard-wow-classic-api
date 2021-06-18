using System.Text.Json.Serialization;

namespace Blizzard.WoWClassic.ApiContract.Core
{
    public class ValueDisplayTyped<T, U>
    {
        [JsonPropertyName("value")]
        public T Value { get; set; }

        [JsonPropertyName("display_string")]
        public U DisplayString { get; set; }
    }
}
