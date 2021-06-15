using System.Text.Json.Serialization;

namespace Blizzard.WoWClassic.ApiContract.Core
{
    public class GenericRequirements<T>
    {
        [JsonPropertyName("level")]
        public T Level { get; set; }
    }
}
