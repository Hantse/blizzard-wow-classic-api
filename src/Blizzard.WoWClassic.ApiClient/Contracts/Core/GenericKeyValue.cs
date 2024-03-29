﻿using System.Text.Json.Serialization;

namespace Blizzard.WoWClassic.ApiContract.Core
{
    public class GenericKeyValue
    {
        [JsonPropertyName("key")]
        public string Key { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }
    }
}
