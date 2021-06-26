using Blizzard.WoWClassic.ApiClient.Exceptions;
using Blizzard.WoWClassic.ApiClient.Helpers;
using Blizzard.WoWClassic.ApiContract.Authentication;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Blizzard.WoWClassic.ApiClient
{
    public partial class WoWClassicApiClient : IWoWClassicApiClient
    {
        private static string clientSecret;
        private static string clientId;

        private static string defaultRegion = RegionHelper.Us;
        private static string defaultNamespace = $"{NamespaceHelper.Static}-{RegionHelper.Us}";
        private static string defaultLocale = LocaleHelper.EnglishUs;

        private static AuthenticationTokenResponse authenticationTokenResponse = new AuthenticationTokenResponse();

        public WoWClassicApiClient(string clientSecret, string clientId)
        {
            WoWClassicApiClient.clientSecret = clientSecret;
            WoWClassicApiClient.clientId = clientId;
        }

        public void SetDefaultValues(string region, string @namespace, string locale)
        {
            WoWClassicApiClient.defaultRegion = region;
            WoWClassicApiClient.defaultNamespace =  $"{@namespace}";
            WoWClassicApiClient.defaultLocale = locale;
        }

        private async Task<HttpClient> GetAuthenticateClientAsync(string region)
        {
            if (string.IsNullOrEmpty(authenticationTokenResponse.AccessToken) || DateTime.UtcNow > authenticationTokenResponse.ExpireAt)
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", $"Basic {Base64Encode($"{clientId}:{clientSecret}")}");
                    var formContent = new List<KeyValuePair<string, string>>();
                    formContent.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));

                    var url = $"https://{region}.battle.net/oauth/token";
                    var httpRequest = new HttpRequestMessage(HttpMethod.Post, url) { Content = new FormUrlEncodedContent(formContent) };
                    var httpResponse = await httpClient.SendAsync(httpRequest);

                    if (httpResponse.IsSuccessStatusCode)
                    {
                        authenticationTokenResponse = JsonSerializer.Deserialize<AuthenticationTokenResponse>(await httpResponse.Content.ReadAsStringAsync());
                        authenticationTokenResponse.ExpireAt = DateTime.UtcNow.AddSeconds(authenticationTokenResponse.ExpiresIn - 100);
                    }
                    else
                    {
                        throw new ApiException("Authentication failed", new Exception(await httpResponse.Content.ReadAsStringAsync()));
                    }
                }
            }

            var httpClientAuth = new HttpClient();
            httpClientAuth.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", $"Bearer {authenticationTokenResponse.AccessToken}");

            return httpClientAuth;
        }

        public string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static byte[] ReadFully(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
    }
}
