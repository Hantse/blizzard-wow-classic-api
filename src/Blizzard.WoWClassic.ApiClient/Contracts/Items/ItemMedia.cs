using Blizzard.WoWClassic.ApiContract.Core;
using System.Text.Json.Serialization;

namespace Blizzard.WoWClassic.ApiContract.Items
{
    public class ItemMedia : CoreResponse
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("key")]
        public LinkItem Key { get; set; }

        [JsonPropertyName("assets")]
        public GenericKeyValue[] Assets { get; set; }
    }
}
