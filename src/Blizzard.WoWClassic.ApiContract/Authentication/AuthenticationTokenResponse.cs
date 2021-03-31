using System;
using System.Text.Json.Serialization;

namespace Blizzard.WoWClassic.ApiContract.Authentication
{
    public class AuthenticationTokenResponse
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        [JsonPropertyName("token_type")]
        public string TokenType { get; set; }

        [JsonPropertyName("expires_in")]
        public int ExpiresIn { get; set; }

        public DateTime ExpireAt { get; set; }
    }
}
