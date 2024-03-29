﻿using Blizzard.WoWClassic.ApiContract.Core;
using System.Text.Json.Serialization;

namespace Blizzard.WoWClassic.ApiClient.Contracts
{
    public class AuctionHouseAuction : CoreResponse
    {
        [JsonPropertyName("auctions")]
        public Auction[] Auctions { get; set; }
    }
}
