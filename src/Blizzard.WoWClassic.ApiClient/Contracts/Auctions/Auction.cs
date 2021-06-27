using System.Text.Json.Serialization;

namespace Blizzard.WoWClassic.ApiClient.Contracts
{
    public class Auction
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("item")]
        public AuctionItem Item { get; set; }

        [JsonPropertyName("bid")]
        public int Bid { get; set; }

        [JsonPropertyName("buyout")]
        public int Buyout { get; set; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        [JsonPropertyName("time_left")]
        public string TimeLeft { get; set; }
    }

    public class AuctionItem
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("rand")]
        public int Rand { get; set; }

        [JsonPropertyName("seed")]
        public int Seed { get; set; }
    }
}
