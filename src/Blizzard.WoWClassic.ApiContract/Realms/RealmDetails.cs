using Blizzard.WoWClassic.ApiContract.Core;
using System.Text.Json.Serialization;

namespace Blizzard.WoWClassic.ApiContract.Realms
{
    public class RealmDetails
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("region")]
        public RealmRegion Region { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("connected_realm")]
        public LinkItem ConnectedRealm { get; set; }

        [JsonPropertyName("category")]
        public string Category { get; set; }

        [JsonPropertyName("locale")]
        public string Locale { get; set; }

        [JsonPropertyName("timezone")]
        public string Timezone { get; set; }

        [JsonPropertyName("type")]
        public GenericTypeName Type { get; set; }

        [JsonPropertyName("is_tournament")]
        public bool IsTournament { get; set; }

        [JsonPropertyName("slug")]
        public string Slug { get; set; }
    }
}
