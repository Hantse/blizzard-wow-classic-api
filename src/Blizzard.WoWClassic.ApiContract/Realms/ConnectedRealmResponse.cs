using Blizzard.WoWClassic.ApiContract.Core;
using System.Text.Json.Serialization;

namespace Blizzard.WoWClassic.ApiContract.Realms
{
    public class ConnectedRealmResponse : CoreResponse
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("has_queue")]
        public bool HasQueue { get; set; }

        [JsonPropertyName("status")]
        public GenericKeyValue Status { get; set; }

        [JsonPropertyName("population")]
        public GenericKeyValue Population { get; set; }

        [JsonPropertyName("realms")]
        public RealmDetails[] RealmDetails { get; set; }
    }
}
