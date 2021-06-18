using Blizzard.WoWClassic.ApiContract.Core;
using System.Linq;
using System.Text.Json.Serialization;

namespace Blizzard.WoWClassic.ApiContract.Realms
{
    public class ConnectedRealmsResponse : CoreResponse
    {
        [JsonPropertyName("connected_realms")]
        public LinkItem[] ConnectedRealms { get; set; }
        
        public int[] GetAsIdList => ConnectedRealms.Select(s => int.Parse(s.Href.Split("/").Last().Split("?").First())).ToArray();
    }
}
