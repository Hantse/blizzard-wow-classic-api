using Blizzard.WoWClassic.ApiClient.Helpers;
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
    }
}
