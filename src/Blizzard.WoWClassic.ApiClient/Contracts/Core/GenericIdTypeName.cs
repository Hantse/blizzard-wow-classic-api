using System.Text.Json.Serialization;

namespace Blizzard.WoWClassic.ApiContract.Core
{
    public class GenericIdTypeName<T>
    {
        [JsonPropertyName("key")]
        public LinkItem Key { get; set; }

        [JsonPropertyName("name")]
        public T Name { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }
    }
}
