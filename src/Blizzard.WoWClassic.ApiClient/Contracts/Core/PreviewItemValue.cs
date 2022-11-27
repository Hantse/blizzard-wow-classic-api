using System.Text.Json.Serialization;

namespace Blizzard.WoWClassic.ApiContract.Core
{
    public class PreviewItemValue<T>
    {
        [JsonPropertyName("binding")]
        public GenericTypeName<T> Binding { get; set; }

        [JsonPropertyName("unique_equipped")]
        public T UniqueEquipped { get; set; }

        [JsonPropertyName("quality")]
        public GenericTypeName<T> Quality { get; set; }

        [JsonPropertyName("inventory_type")]
        public GenericTypeName<T> InventoryType { get; set; }

        [JsonPropertyName("requirements")]
        public GenericRequirements<T> Requirements { get; set; }

        [JsonPropertyName("weapon")]
        public WeaponValue<T> Weapon { get; set; }

        [JsonPropertyName("durability")]
        public ValueDisplayTyped<int, T> Durability { get; set; }

        [JsonPropertyName("spells")]
        public SpellValue<T>[] Spells { get; set; }
    }
}
