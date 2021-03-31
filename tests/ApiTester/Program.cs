using Blizzard.WoWClassic.ApiClient;
using Blizzard.WoWClassic.ApiClient.Helpers;
using System;
using System.Threading.Tasks;

namespace ApiTester
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            

            var clientWow = new WoWClassicApiClient("clientSecret", "clientId");
            clientWow.SetDefaultValues(RegionHelper.Europe, NamespaceHelper.Dynamic, LocaleHelper.French);
            var realms = await clientWow.GetConnectedRealmsAsync();

            foreach (var id in realms.GetAsIdList)
            {
                try
                {
                    var realmDetails = await clientWow.GetConnectedRealmAsync(id);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
