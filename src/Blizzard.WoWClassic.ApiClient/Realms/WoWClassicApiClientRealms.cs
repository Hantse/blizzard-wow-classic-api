using Blizzard.WoWClassic.ApiClient.Exceptions;
using Blizzard.WoWClassic.ApiClient.Helpers;
using Blizzard.WoWClassic.ApiContract.Realms;
using System.Text.Json;
using System.Threading.Tasks;

namespace Blizzard.WoWClassic.ApiClient
{
    public partial class WoWClassicApiClient
    {
        /// <summary>
        /// Connected Realms Index (Use default value)
        /// </summary>
        /// <returns>Returns an index of connected realms.</returns>
        public Task<ConnectedRealmsResponse> GetConnectedRealmsAsync() => GetConnectedRealmsAsync(defaultRegion, defaultNamespace, defaultLocale);

        /// <summary>
        /// Connected Realms Index
        /// </summary>
        /// <param name="region">The region of the data to retrieve.</param>
        /// <param name="namespace">The namespace to use to locate this document.</param>
        /// <param name="locale">The locale to reflect in localized data.</param>
        /// <returns>Returns an index of connected realms.</returns>
        public async Task<ConnectedRealmsResponse> GetConnectedRealmsAsync(string region = RegionHelper.Us, string @namespace = "dynamic-classic-", string locale = "en_US")
        {
            // https://us.api.blizzard.com/data/wow/connected-realm/index?namespace=dynamic-classic-us&locale=en_US
            using (var httpClient = await GetAuthenticateClientAsync(region))
            {
                var httpResponse = await httpClient.GetAsync($"https://{region}.api.blizzard.com/data/wow/connected-realm/index?namespace={@namespace}{region}&locale={locale}");
                if (httpResponse.IsSuccessStatusCode)
                {
                    return JsonSerializer.Deserialize<ConnectedRealmsResponse>(await httpResponse.Content.ReadAsStringAsync());
                }

                throw new ApiException(await httpResponse.Content.ReadAsStringAsync());
            }
        }

        /// <summary>
        /// Connected Realm (Use default value)
        /// </summary>
        /// <param name="realmId">The ID of the connected realm.</param>
        /// <returns>Returns a connected realm by ID.</returns>
        public Task<ConnectedRealmResponse> GetConnectedRealmAsync(int realmId) => GetConnectedRealmAsync(realmId, defaultRegion, defaultNamespace, defaultLocale);

        /// <summary>
        /// Connected Realm
        /// </summary>
        /// <param name="region">The region of the data to retrieve.</param>
        /// <param name="realmId">The ID of the connected realm.</param>
        /// <param name="namespace">The namespace to use to locate this document.</param>
        /// <param name="locale">The locale to reflect in localized data.</param>
        /// <returns>Returns a connected realm by ID.</returns>
        public async Task<ConnectedRealmResponse> GetConnectedRealmAsync(int realmId, string region = RegionHelper.Us, string @namespace = "dynamic-classic-us", string locale = "en_US")
        {
            // https://us.api.blizzard.com/data/wow/connected-realm/4388?namespace=dynamic-classic-us&locale=en_US
            using (var httpClient = await GetAuthenticateClientAsync(region))
            {
                var httpResponse = await httpClient.GetAsync($"https://{region}.api.blizzard.com/data/wow/connected-realm/{realmId}?namespace={@namespace}&locale={locale}");
                if (httpResponse.IsSuccessStatusCode)
                {
                    return JsonSerializer.Deserialize<ConnectedRealmResponse>(await httpResponse.Content.ReadAsStringAsync());
                }

                throw new ApiException(await httpResponse.Content.ReadAsStringAsync());
            }
        }
    }
}
