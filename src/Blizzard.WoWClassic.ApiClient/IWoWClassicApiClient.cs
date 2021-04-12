using Blizzard.WoWClassic.ApiClient.Helpers;
using Blizzard.WoWClassic.ApiContract.Items;
using Blizzard.WoWClassic.ApiContract.Medias;
using Blizzard.WoWClassic.ApiContract.Realms;
using System.Threading.Tasks;

namespace Blizzard.WoWClassic.ApiClient
{
    public interface IWoWClassicApiClient
    {
        Task<ConnectedRealmsResponse> GetConnectedRealmsAsync();
        Task<ConnectedRealmsResponse> GetConnectedRealmsAsync(string region = RegionHelper.Us, string @namespace = "dynamic-classic-us", string locale = "en_US");
        Task<ConnectedRealmResponse> GetConnectedRealmAsync(int realmId);
        Task<ConnectedRealmResponse> GetConnectedRealmAsync(int realmId, string region = RegionHelper.Us, string @namespace = "dynamic-classic-us", string locale = "en_US");
        Task<ItemDetails> GetItemDetailsAsync(int itemId);
        Task<ItemDetails> GetItemDetailsAsync(int itemId, string region = RegionHelper.Us, string @namespace = "dynamic-classic-us", string locale = "en_US");
        Task<ItemMedia> GetItemMediaAsync(int itemId);
        Task<ItemMedia> GetItemMediaAsync(int itemId, string region = RegionHelper.Us, string @namespace = NamespaceHelper.Static, string locale = LocaleHelper.EnglishUs);
        Task<MediaDownload> DownloadMediaAsync(string uri, string name);
        Task<MediaDownload> DownloadMediaAsync(string uri, string name, string region = RegionHelper.Us);
    }
}
