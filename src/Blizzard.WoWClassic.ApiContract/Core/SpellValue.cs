using System.Text.Json.Serialization;

namespace Blizzard.WoWClassic.ApiContract.Core
{
    public class SpellValue<T>
    {
        [JsonPropertyName("spell")]
        public SpellDetailsValue<T> Spell { get; set; }

        [JsonPropertyName("description")]
        public T Description { get; set; }
    }
}
