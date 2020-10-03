using GenshinImpactProfileQuery.Entity;
using Newtonsoft.Json;

namespace GenshinImpactProfileQuery.Utils
{
    public class JsonTools
    {
        public static JsonEntity SerializeProfileEntity(string json)
        {
            return JsonConvert.DeserializeObject<JsonEntity>(json);
        }
    }
}