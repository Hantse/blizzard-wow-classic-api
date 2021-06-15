using System.Text.Json.Serialization;

namespace Blizzard.WoWClassic.ApiContract.Core
{
    public class GenericDamage<T>
    {
        [JsonPropertyName("min_value")]
        public float MinValue { get; set; }

        [JsonPropertyName("max_value")]
        public float MaxValue { get; set; }

        [JsonPropertyName("display_string")]
        public T DisplayString { get; set; }

        [JsonPropertyName("damage_class")]
        public GenericTypeName<T> DamageClass { get; set; }
    }
}
