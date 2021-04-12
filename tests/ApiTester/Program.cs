using Azure.Storage.Blobs;
using Blizzard.WoWClassic.ApiClient;
using Blizzard.WoWClassic.ApiClient.Exceptions;
using Blizzard.WoWClassic.ApiClient.Helpers;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApiTester
{
    class Program
    {
        static string connectionString = "DefaultEndpointsProtocol=https;AccountName=appepicstorage;AccountKey=Cyr196oHhMjTTnCgCV1A/LXADKlxzwI+v5+NTxp2wzq9bkgFUDK5wB0337gC7CrRfz712vHJD9UVnwe3tXbQaA==;EndpointSuffix=core.windows.net";

        static async Task Main(string[] args)
        {
            var clientWow = new WoWClassicApiClient("", "");
            clientWow.SetDefaultValues(RegionHelper.Europe, NamespaceHelper.Dynamic, LocaleHelper.French);

            for (var i = 5000; i < 100000; i++)
            {
                try
                {
                    await ExtractBlizzardDatabase(clientWow, i);
                    await Task.Delay(250);
                }
                catch (Exception e) { 
                
                }
            }
        }

        static async Task ExtractBlizzardDatabase(WoWClassicApiClient clientWow, int itemId)
        {
            try
            {
                var itemDetails = await clientWow.GetItemDetailsAsync(itemId, RegionHelper.Us, NamespaceHelper.Static);

                if (itemDetails != null)
                {
                    await UploadToAzureItem($"{itemId}.json", Encoding.UTF8.GetBytes(JsonSerializer.Serialize(itemDetails)));
                }

                var itemMedia = await clientWow.GetItemMediaAsync(itemId, RegionHelper.Us, NamespaceHelper.Static);

                if (itemMedia != null && itemMedia.Assets.Any())
                {
                    var downloadResult = await clientWow.DownloadMediaAsync(itemMedia.Assets[0].Value, $"{itemId}.png");
                    await UploadToAzure($"item_{itemId}.png", downloadResult.Data);
                }
            }
            catch (ApiException)
            {
                Console.WriteLine($"Item id not found {itemId}.");
            }
        }

        static async Task UploadToAzureItem(string fileName, byte[] data)
        {
            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient("items");
            BlobClient blobClient = containerClient.GetBlobClient(fileName);
            MemoryStream stream = new MemoryStream(data);
            await blobClient.UploadAsync(stream, true);
            stream.Close();
        }

        static async Task UploadToAzure(string fileName, byte[] data)
        {
            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient("medias");
            BlobClient blobClient = containerClient.GetBlobClient(fileName);
            MemoryStream stream = new MemoryStream(data);
            await blobClient.UploadAsync(stream, true);
            stream.Close();
        }
    }
}
