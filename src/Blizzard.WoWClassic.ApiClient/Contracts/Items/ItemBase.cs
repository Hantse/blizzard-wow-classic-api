using Blizzard.WoWClassic.ApiContract.Core;
using System.Text.Json.Serialization;

namespace Blizzard.WoWClassic.ApiContract.Items
{
    public class ItemBase<T> : CoreResponse
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public T Name { get; set; }

        [JsonPropertyName("binding")]
        public GenericTypeName<T> Binding { get; set; }

        [JsonPropertyName("item_class")]
        public GenericIdTypeName<T> ItemClass { get; set; }

        [JsonPropertyName("item_subclass")]
        public GenericIdTypeName<T> ItemSubclass { get; set; }

        [JsonPropertyName("weapon")]
        public WeaponValue<T> Weapon { get; set; }

        [JsonPropertyName("level")]
        public int Level { get; set; }

        [JsonPropertyName("required_level")]
        public int RequiredLevel { get; set; }

        [JsonPropertyName("media")]
        public ItemMedia Media { get; set; }

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

        [JsonPropertyName("preview_item")]
        public PreviewItemValue<T> PreviewItem { get; set; }
    }
}
