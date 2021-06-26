using Blizzard.WoWClassic.ApiClient.Contracts;
using Blizzard.WoWClassic.ApiClient.Exceptions;
using Blizzard.WoWClassic.ApiClient.Helpers;
using System.Text.Json;
using System.Threading.Tasks;

namespace Blizzard.WoWClassic.ApiClient
{
    public partial class WoWClassicApiClient
    {
        /// <summary>
        /// Get realm auction house informations (Use default value)
        /// </summary>
        /// <returns>Returns an informations about auctions house on related realm.</returns>
        public Task<AuctionHouse> GetRealmAuctionHousesAsync(int realmId, string locale) => GetRealmAuctionHousesAsync(realmId, defaultRegion, defaultNamespace, locale);

        /// <summary>
        /// Get realm auction house informations
        /// </summary>
        /// <param name="realmId">The realm id to retrive auction houses.</param>
        /// <param name="region">The region of the data to retrieve.</param>
        /// <param name="namespace">The namespace to use to locate this document.</param>
        /// <param name="locale">The locale to reflect in localized data.</param>
        /// <returns>Returns an informations about auctions house on related realm.</returns>
        public async Task<AuctionHouse> GetRealmAuctionHousesAsync(int realmId, string region = RegionHelper.Us, string @namespace = NamespaceHelper.Static, string locale = LocaleHelper.EnglishUs)
        {
            //https://us.api.blizzard.com/data/wow/connected-realm/4372/auctions/index?namespace=dynamic-classic-us&locale=en_US&access_token=USmRU4mUWd6dZOHoYmNRwKszaTW7ZCpvp0
            using (var httpClient = await GetAuthenticateClientAsync(region))
            {
                var httpResponse = await httpClient.GetAsync($"https://{region}.api.blizzard.com/data/wow/connected-realm/{realmId}/auctions/index?namespace={@namespace}{region}&locale={locale}");
                if (httpResponse.IsSuccessStatusCode)
                {
                    return JsonSerializer.Deserialize<AuctionHouse>(await httpResponse.Content.ReadAsStringAsync());
                }

                throw new ApiException(await httpResponse.Content.ReadAsStringAsync());
            }
        }

        /// <summary>
        /// Get realm auction house auctions (Use default value)
        /// </summary>
        /// <returns>Returns an informations about auctions house on related realm.</returns>
        public Task<AuctionHouseAuction> GetRealmAuctionsAsync(int realmId, int auctionHouseId,  string locale = LocaleHelper.EnglishUs) => GetRealmAuctionsAsync(realmId, auctionHouseId, defaultRegion, defaultNamespace, locale);

        /// <summary>
        /// Get realm auction house auctions 
        /// </summary>
        /// <param name="realmId">The realm id to retrive auction houses.</param>
        /// <param name="auctionHouseId">The selected auction house.</param>
        /// <param name="region">The region of the data to retrieve.</param>
        /// <param name="namespace">The namespace to use to locate this document.</param>
        /// <param name="locale">The locale to reflect in localized data.</param>
        /// <returns>Returns an informations about auctions house on related realm.</returns>
        public async Task<AuctionHouseAuction> GetRealmAuctionsAsync(int realmId, int auctionHouseId, string region = RegionHelper.Us, string @namespace = NamespaceHelper.Static, string locale = LocaleHelper.EnglishUs)
        {
            // https://us.api.blizzard.com/data/wow/connected-realm/4372/auctions/2?namespace=dynamic-classic-us&locale=en_US&access_token=USmRU4mUWd6dZOHoYmNRwKszaTW7ZCpvp0
            using (var httpClient = await GetAuthenticateClientAsync(region))
            {
                var httpResponse = await httpClient.GetAsync($"https://{region}.api.blizzard.com/data/wow/connected-realm/{realmId}/auctions/{auctionHouseId }?namespace={@namespace}{region}&locale={locale}");
                if (httpResponse.IsSuccessStatusCode)
                {
                    return JsonSerializer.Deserialize<AuctionHouseAuction>(await httpResponse.Content.ReadAsStringAsync());
                }

                throw new ApiException(await httpResponse.Content.ReadAsStringAsync());
            }
        }
    }
}
