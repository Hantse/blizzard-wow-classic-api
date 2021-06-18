using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Blizzard.WoWClassic.ApiContract.Core
{
    public class GenericSellPrice
    {
        [JsonPropertyName("value")]
        public int Value { get; set; }
    }
}
