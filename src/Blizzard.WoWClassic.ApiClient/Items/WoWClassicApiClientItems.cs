using Blizzard.WoWClassic.ApiClient.Exceptions;
using Blizzard.WoWClassic.ApiClient.Helpers;
using Blizzard.WoWClassic.ApiContract.Items;
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
        public Task<ItemLocaleDetails> GetItemDetailsAsync(int itemId, string locale) => GetItemDetailsAsync(itemId, defaultRegion, defaultNamespace, locale);

        /// <summary>
        /// Connected Realms Index
        /// </summary>
        /// <param name="region">The region of the data to retrieve.</param>
        /// <param name="namespace">The namespace to use to locate this document.</param>
        /// <param name="locale">The locale to reflect in localized data.</param>
        /// <returns>Returns an index of connected realms.</returns>
        public async Task<ItemLocaleDetails> GetItemDetailsAsync(int itemId, string region = RegionHelper.Us, string @namespace = NamespaceHelper.Static, string locale = LocaleHelper.EnglishUs)
        {
            // https://us.api.blizzard.com/data/wow/item/19019?namespace=dynamic-classic-us&locale=en_US
            using (var httpClient = await GetAuthenticateClientAsync(region))
            {
                var httpResponse = await httpClient.GetAsync($"https://{region}.api.blizzard.com/data/wow/item/{itemId}?namespace={@namespace}{region}&locale={locale}");
                if (httpResponse.IsSuccessStatusCode)
                {
                    return JsonSerializer.Deserialize<ItemLocaleDetails>(await httpResponse.Content.ReadAsStringAsync());
                }

                throw new ApiException(await httpResponse.Content.ReadAsStringAsync());
            }
        }

        /// <summary>
        /// Connected Realms Index (Use default value)
        /// </summary>
        /// <returns>Returns an index of connected realms.</returns>
        public Task<ItemDetails> GetItemDetailsAsync(int itemId) => GetItemDetailsAsync(itemId, defaultRegion, defaultNamespace);


        /// <summary>
        /// Connected Realms Index
        /// </summary>
        /// <param name="region">The region of the data to retrieve.</param>
        /// <param name="namespace">The namespace to use to locate this document.</param>
        /// <returns>Returns an index of connected realms.</returns>
        public async Task<ItemDetails> GetItemDetailsAsync(int itemId, string region = RegionHelper.Us, string @namespace = NamespaceHelper.Static)
        {
            // https://us.api.blizzard.com/data/wow/item/19019?namespace=dynamic-classic-us
            using (var httpClient = await GetAuthenticateClientAsync(region))
            {
                var httpResponse = await httpClient.GetAsync($"https://{region}.api.blizzard.com/data/wow/item/{itemId}?namespace={@namespace}");
                if (httpResponse.IsSuccessStatusCode)
                {
                    return JsonSerializer.Deserialize<ItemDetails>(await httpResponse.Content.ReadAsStringAsync());
                }

                throw new ApiException(await httpResponse.Content.ReadAsStringAsync());
            }
        }

        /// <summary>
        /// Connected Realms Index (Use default value)
        /// </summary>
        /// <returns>Returns an index of connected realms.</returns>
        public Task<ItemMedia> GetItemMediaAsync(int itemId) => GetItemMediaAsync(itemId, defaultRegion, defaultNamespace, defaultLocale);

        /// <summary>
        /// Connected Realms Index
        /// </summary>
        /// <param name="region">The region of the data to retrieve.</param>
        /// <param name="namespace">The namespace to use to locate this document.</param>
        /// <param name="locale">The locale to reflect in localized data.</param>
        /// <returns>Returns an index of connected realms.</returns>
        public async Task<ItemMedia> GetItemMediaAsync(int itemId, string region = RegionHelper.Us, string @namespace = NamespaceHelper.Static, string locale = LocaleHelper.EnglishUs)
        {
            // https://us.api.blizzard.com/data/wow/item/19019?namespace=dynamic-classic-us&locale=en_US
            using (var httpClient = await GetAuthenticateClientAsync(region))
            {
                var httpResponse = await httpClient.GetAsync($"https://{region}.api.blizzard.com/data/wow/media/item/{itemId}?namespace={@namespace}{region}&locale={locale}");
                if (httpResponse.IsSuccessStatusCode)
                {
                    return JsonSerializer.Deserialize<ItemMedia>(await httpResponse.Content.ReadAsStringAsync());
                }

                throw new ApiException(await httpResponse.Content.ReadAsStringAsync());
            }
        }
    }
}
