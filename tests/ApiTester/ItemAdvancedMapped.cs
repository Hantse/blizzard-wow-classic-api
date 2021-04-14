using Blizzard.WoWClassic.ApiContract.Items;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ApiTester
{
    public class ItemAdvancedMapped : ItemDetails
    {
        [JsonPropertyName("stats")]
        public Dictionary<string, string> Stats { get; set; }
    }
}
