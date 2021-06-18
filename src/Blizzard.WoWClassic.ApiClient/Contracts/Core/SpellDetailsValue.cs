using System.Text.Json.Serialization;

namespace Blizzard.WoWClassic.ApiContract.Core
{
    public class SpellDetailsValue<T>
    {
        [JsonPropertyName("name")]
        public T Name { get; set; }

        [JsonPropertyName("key")]
        public LinkItem Key { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }
    }
}
