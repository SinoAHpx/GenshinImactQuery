using Newtonsoft.Json;

namespace GenshinImpactProfileQuery.Entity
{
    public class ProfileAvatarEntity
    {
        [JsonProperty("id")] public string Id { get; set; }

        [JsonProperty("image")] public string Image { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("element")] public string Element { get; set; }

        [JsonProperty("fetter")] public string Fetter { get; set; }

        [JsonProperty("level")] public string Level { get; set; }

        [JsonProperty("rarity")] public string Rarity { get; set; }
    }
}