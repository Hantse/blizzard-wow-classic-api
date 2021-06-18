using System.Text.Json.Serialization;

namespace Blizzard.WoWClassic.ApiContract.Core
{
    public class WeaponValue<T>
    {
        [JsonPropertyName("attack_speed")]
        public ValueDisplayTyped<float, T> AttackSpeed { get; set; }

        [JsonPropertyName("dps")]
        public ValueDisplayTyped<float, T> Dps { get; set; }

        [JsonPropertyName("damage")]
        public GenericDamage<T> Damage { get; set; }

        [JsonPropertyName("additional_damage")]
        public GenericDamage<T>[] AdditionalDamage { get; set; }
    }
}
