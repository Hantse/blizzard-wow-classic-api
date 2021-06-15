using Blizzard.WoWClassic.ApiClient.Exceptions;
using Blizzard.WoWClassic.ApiClient.Helpers;
using System.Text.Json;
using System.Threading.Tasks;

namespace Blizzard.WoWClassic.ApiClient
{
    public partial class WoWClassicApiClient
    {
        /// <summary>
        /// Get spell informations (Use default value)
        /// </summary>
        /// <returns>Returns an informations about spell.</returns>
        public Task<object> GetSpellDetailsAsync(int spellId, string locale) => GetSpellDetailsAsync(spellId, defaultRegion, defaultNamespace, locale);

        /// <summary>
        /// Get spell informations
        /// </summary>
        /// <param name="region">The region of the data to retrieve.</param>
        /// <param name="namespace">The namespace to use to locate this document.</param>
        /// <param name="locale">The locale to reflect in localized data.</param>
        /// <returns>Returns an informations about spell.</returns>
        public async Task<object> GetSpellDetailsAsync(int spellId, string region = RegionHelper.Us, string @namespace = NamespaceHelper.Static, string locale = LocaleHelper.EnglishUs)
        {
            // https://us.api.blizzard.com/data/wow/spell/21992?namespace=static-2.5.1_38644-classic-us
            using (var httpClient = await GetAuthenticateClientAsync(region))
            {
                var httpResponse = await httpClient.GetAsync($"https://{region}.api.blizzard.com/data/wow/spell/{spellId}?namespace={@namespace}{region}&locale={locale}");
                if (httpResponse.IsSuccessStatusCode)
                {
                    return JsonSerializer.Deserialize<object>(await httpResponse.Content.ReadAsStringAsync());
                }

                throw new ApiException(await httpResponse.Content.ReadAsStringAsync());
            }
        }
    }
}
