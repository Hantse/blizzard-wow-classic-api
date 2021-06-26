using Blizzard.WoWClassic.ApiClient.Contracts;
using Blizzard.WoWClassic.ApiClient.Helpers;
using Blizzard.WoWClassic.ApiContract.Items;
using Blizzard.WoWClassic.ApiContract.Medias;
using Blizzard.WoWClassic.ApiContract.Realms;
using System.Threading.Tasks;

namespace Blizzard.WoWClassic.ApiClient
{
    public interface IWoWClassicApiClient
    {
        #region Auction House
        Task<AuctionHouse> GetRealmAuctionHousesAsync(int realmId, string locale);
        Task<AuctionHouse> GetRealmAuctionHousesAsync(int realmId, string region = RegionHelper.Us, string @namespace = NamespaceHelper.Static, string locale = LocaleHelper.EnglishUs);
        Task<AuctionHouseAuction> GetRealmAuctionsAsync(int realmId, int auctionHouseId, string locale = LocaleHelper.EnglishUs);
        Task<AuctionHouseAuction> GetRealmAuctionsAsync(int realmId, int auctionHouseId, string region = RegionHelper.Us, string @namespace = NamespaceHelper.Static, string locale = LocaleHelper.EnglishUs);
        #endregion

        #region Realm
        Task<ConnectedRealmsResponse> GetConnectedRealmsAsync();
        Task<ConnectedRealmsResponse> GetConnectedRealmsAsync(string region = RegionHelper.Us, string @namespace = "dynamic-classic-us", string locale = "en_US");
        Task<ConnectedRealmResponse> GetConnectedRealmAsync(int realmId);
        Task<ConnectedRealmResponse> GetConnectedRealmAsync(int realmId, string region = RegionHelper.Us, string @namespace = "dynamic-classic-us", string locale = "en_US");
        #endregion

        #region Item
        Task<ItemLocaleDetails> GetItemDetailsAsync(int itemId, string locale);
        Task<ItemLocaleDetails> GetItemDetailsAsync(int itemId, string region = RegionHelper.Us, string @namespace = "dynamic-classic-us", string locale = "en_US");
        Task<ItemDetails> GetItemDetailsAsync(int itemId);
        Task<ItemDetails> GetItemDetailsAsync(int itemId, string region = RegionHelper.Us, string @namespace = "dynamic-classic-us");
        Task<ItemMedia> GetItemMediaAsync(int itemId);
        Task<ItemMedia> GetItemMediaAsync(int itemId, string region = RegionHelper.Us, string @namespace = NamespaceHelper.Static, string locale = LocaleHelper.EnglishUs);
        #endregion

        #region Media
        Task<MediaDownload> DownloadMediaAsync(string uri, string name);
        Task<MediaDownload> DownloadMediaAsync(string uri, string name, string region = RegionHelper.Us);
        #endregion

        #region Spell
        Task<object> GetSpellDetailsAsync(int spellId, string locale);
        Task<object> GetSpellDetailsAsync(int spellId, string region = RegionHelper.Us, string @namespace = NamespaceHelper.Static, string locale = LocaleHelper.EnglishUs);
        #endregion
    }
}
