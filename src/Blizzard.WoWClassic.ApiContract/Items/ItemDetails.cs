using Blizzard.WoWClassic.ApiContract.Core;
using System.Text.Json.Serialization;

namespace Blizzard.WoWClassic.ApiContract.Items
{
    public class ItemDetails : CoreResponse
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("quality")]
        public GenericTypeName Quality { get; set; }

        [JsonPropertyName("level")]
        public int Level { get; set; }

        [JsonPropertyName("required_level")]
        public int RequiredLevel { get; set; }

        [JsonPropertyName("media")]
        public ItemMedia Media { get; set; }

        [JsonPropertyName("item_class")]
        public GenericIdTypeName ItemClass { get; set; }

        [JsonPropertyName("item_subclass")]
        public GenericIdTypeName ItemSubclass { get; set; }

        [JsonPropertyName("inventory_type")]
        public GenericTypeName InventoryType { get; set; }

        [JsonPropertyName("purchase_price")]
        public int PurchasePrice { get; set; }

        [JsonPropertyName("sell_price")]
        public int SellPrice { get; set; }

        [JsonPropertyName("max_count")]
        public int MaxCount { get; set; }

        [JsonPropertyName("is_equippable")]
        public bool IsEquippable { get; set; }

        [JsonPropertyName("is_stackable")]
        public bool IsStackable { get; set; }
    }
}
