using Blizzard.WoWClassic.ApiClient.Exceptions;
using Blizzard.WoWClassic.ApiClient.Helpers;
using Blizzard.WoWClassic.ApiContract.Medias;
using System.Threading.Tasks;

namespace Blizzard.WoWClassic.ApiClient
{
    public partial class WoWClassicApiClient
    {
        /// <summary>
        /// Connected Realms Index (Use default value)
        /// </summary>
        /// <returns>Returns an index of connected realms.</returns>
        public Task<MediaDownload> DownloadMediaAsync(string uri, string name) => DownloadMediaAsync(uri, name, defaultRegion);

        /// <summary>
        /// Connected Realms Index
        /// </summary>
        /// <param name="region">The region of the data to retrieve.</param>
        /// <param name="namespace">The namespace to use to locate this document.</param>
        /// <param name="locale">The locale to reflect in localized data.</param>
        /// <returns>Returns an index of connected realms.</returns>
        public async Task<MediaDownload> DownloadMediaAsync(string uri, string name, string region = RegionHelper.Us)
        {
            // https://render-classic-us.worldofwarcraft.com/icons/56/inv_sword_39.jpg
            using (var httpClient = await GetAuthenticateClientAsync(region))
            {
                var httpResponse = await httpClient.GetAsync($"{uri}");
                if (httpResponse.IsSuccessStatusCode)
                {
                    await using var ms = await httpResponse.Content.ReadAsStreamAsync();
                    return new MediaDownload()
                    {
                        Data = ReadFully(ms),
                        Filename = name
                    };
                }

                throw new ApiException(await httpResponse.Content.ReadAsStringAsync());
            }
        }
    }
}
