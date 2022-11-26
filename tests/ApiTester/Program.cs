using Blizzard.WoWClassic.ApiClient;
using Blizzard.WoWClassic.ApiClient.Helpers;
using System.Threading.Tasks;
using System.Linq;
using System.Diagnostics;

namespace ApiTester
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var clientWow = new WoWClassicApiClient("***", "***");
            clientWow.SetDefaultValues(RegionHelper.Us, NamespaceHelper.Static, LocaleHelper.French);

            var itemDetails = await clientWow.GetItemDetailsAsync(839);

            var realms = await clientWow.GetConnectedRealmsAsync(RegionHelper.Us, NamespaceHelper.Dynamic, LocaleHelper.EnglishUs);

            var realmId = realms.GetAsIdList.FirstOrDefault();

            var realmAuctionHouses = await clientWow.GetRealmAuctionHousesAsync(realmId, RegionHelper.Us, NamespaceHelper.Dynamic, LocaleHelper.EnglishUs);

            var sc = new Stopwatch();
            sc.Start();
            var auctions = await clientWow.GetRealmAuctionsAsync(realmId, 2, RegionHelper.Us, NamespaceHelper.Dynamic, LocaleHelper.EnglishUs);
            sc.Stop();

            System.Console.WriteLine($"Time for {auctions.Auctions.Count()} - {sc.ElapsedMilliseconds} ms.");
        }
    }
}
