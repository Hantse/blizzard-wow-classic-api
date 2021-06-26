using Blizzard.WoWClassic.ApiContract.Core;
using System.Text.Json.Serialization;

namespace Blizzard.WoWClassic.ApiClient.Contracts
{
    public class AuctionHouse : CoreResponse
    {
        [JsonPropertyName("auctions")]
        public GenericIdTypeName<string>[] Auctions { get; set; }
    }
}
