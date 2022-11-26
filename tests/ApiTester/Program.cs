using Blizzard.WoWClassic.ApiClient;
using Blizzard.WoWClassic.ApiClient.Helpers;
using System.Threading.Tasks;
using System.Linq;

namespace ApiTester
{
    class Program
    {
        static string connectionString = "DefaultEndpointsProtocol=https;AccountName=appepicstorage;AccountKey=Cyr196oHhMjTTnCgCV1A/LXADKlxzwI+v5+NTxp2wzq9bkgFUDK5wB0337gC7CrRfz712vHJD9UVnwe3tXbQaA==;EndpointSuffix=core.windows.net";

        static string[] statsList = new string[] { "Stamina", "Strenght", "Agility", "DamageMin1", "DamageMax1", "Durability", "Speed" };

        static async Task Main(string[] args)
        {
            var clientWow = new WoWClassicApiClient("bxSvhNNHJwI0kgNvKy6Z91oMEOpwgjmv", "2b136112d3064b11b19c5ea275846996");
            clientWow.SetDefaultValues(RegionHelper.Us, NamespaceHelper.Static, LocaleHelper.French);

            var itemDetails = await clientWow.GetItemDetailsAsync(839);

            var realms = await clientWow.GetConnectedRealmsAsync(RegionHelper.Us, $"{NamespaceHelper.Dynamic}{RegionHelper.Us}", LocaleHelper.EnglishUs);

            var realmId = realms.GetAsIdList.FirstOrDefault();

            var realmAuctionHouses = await clientWow.GetRealmAuctionHousesAsync(realmId, RegionHelper.Us, NamespaceHelper.Dynamic, LocaleHelper.EnglishUs);
            
            var auctions = await clientWow.GetRealmAuctionsAsync(realmId, 2, RegionHelper.Us, NamespaceHelper.Dynamic, LocaleHelper.EnglishUs);


            //for (var i = 1; i < 50000; i++)
            //{
            //    try
            //    {
            //        await ExtractBlizzardDatabase(clientWow, i);
            //        await Task.Delay(250);
            //    }
            //    catch (Exception e)
            //    {
            //        Console.WriteLine($"Error ... {e.Message}");
            //    }
            //}
        }

        //static async Task ExtractBlizzardDatabase(WoWClassicApiClient clientWow, int itemId)
        //{
        //    try
        //    {
        //        var itemDetails = await clientWow.GetItemDetailsAsync(itemId, RegionHelper.Us, NamespaceHelper.Static);
        //        var child = JsonSerializer.Deserialize<ItemAdvancedMapped>(JsonSerializer.Serialize(itemDetails));
        //        var itemXml = await GetXmlAsync(itemId);
        //        child.Stats = ExtractEquiped(itemXml);

        //        if (itemDetails != null)
        //        {
        //            await UploadToAzureItem($"{itemId}.json", Encoding.UTF8.GetBytes(JsonSerializer.Serialize(child)));
        //        }

        //        var itemMedia = await clientWow.GetItemMediaAsync(itemId, RegionHelper.Us, NamespaceHelper.Static);

        //        if (itemMedia != null && itemMedia.Assets.Any())
        //        {
        //            var downloadResult = await clientWow.DownloadMediaAsync(itemMedia.Assets[0].Value, $"{itemId}.png");
        //            await UploadToAzure($"item_{itemId}.png", downloadResult.Data);
        //        }
        //    }
        //    catch (ApiException)
        //    {
        //        Console.WriteLine($"Item id not found {itemId}.");
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine($"Error ... {e.Message}");
        //    }
        //}

        //static string MapStat(string key)
        //{
        //    switch (key)
        //    {
        //        case "sta":
        //            return "Stamina";
        //        case "str":
        //            return "Strenght";
        //        case "agi":
        //            return "Agility";
        //        case "dmgmin1":
        //            return "DamageMin1";
        //        case "dmgmax1":
        //            return "DamageMax1";
        //        case "dura":
        //            return "Durability";
        //        case "mlespeed":
        //            return "Speed";
        //        default:
        //            return key;
        //    }
        //}

        //static Dictionary<string, string> ExtractEquiped(string itemXml)
        //{
        //    var dictionaryEquip = new Dictionary<string, string>();
        //    XDocument doc = XDocument.Parse(itemXml);
        //    var query = from c in doc.Root.Descendants("item").Descendants("jsonEquip")
        //                select c;

        //    var node = query.FirstOrDefault();

        //    if (node != null)
        //    {
        //        var cleanValue = node.Value.Replace("\"", "");
        //        dictionaryEquip = cleanValue.Split(',').
        //            ToDictionary(k => MapStat(k.Split(':')[0]), v => v.Split(':')[1])
        //            .Where(s => statsList.Contains(s.Key))
        //            .ToDictionary(s => s.Key, s => s.Value);
        //    }

        //    return dictionaryEquip;
        //}

        //static async Task<string> GetXmlAsync(int itemId)
        //{
        //    using (var httpClient = new HttpClient())
        //    {
        //        return await httpClient.GetStringAsync($"https://classic.wowhead.com/item={itemId}&xml");
        //    }
        //}

        //static async Task UploadToAzureItem(string fileName, byte[] data)
        //{
        //    BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
        //    BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient("items");
        //    BlobClient blobClient = containerClient.GetBlobClient(fileName);
        //    MemoryStream stream = new MemoryStream(data);
        //    await blobClient.UploadAsync(stream, true);
        //    stream.Close();
        //}

        //static async Task UploadToAzure(string fileName, byte[] data)
        //{
        //    BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
        //    BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient("medias");
        //    BlobClient blobClient = containerClient.GetBlobClient(fileName);
        //    MemoryStream stream = new MemoryStream(data);
        //    await blobClient.UploadAsync(stream, true);
        //    stream.Close();
        //}
    }
}
