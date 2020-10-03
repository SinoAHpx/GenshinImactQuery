using Newtonsoft.Json;

namespace GenshinImpactProfileQuery.Entity
{
    public class ProfileStatsEntity
    {
        [JsonProperty("active_day_number")] public string ActiveDays { get; set; }

        [JsonProperty("achievement_number")] public string AchievementCount { get; set; }

        [JsonProperty("win_rate")] public string WinRate { get; set; }

        [JsonProperty("anemoculus_number")] public string AnemoculusCount { get; set; }

        [JsonProperty("geoculus_number")] public string GeoculusCount { get; set; }

        [JsonProperty("avatar_number")] public string AvatarCount { get; set; }

        [JsonProperty("way_point_number")] public string WayPointCount { get; set; }

        [JsonProperty("domain_number")] public string DomainCount { get; set; }

        [JsonProperty("spiral_abyss")] public string SpiralAbyss { get; set; }

        [JsonProperty("precious_chest_number")]
        public string PreciousChests { get; set; }

        [JsonProperty("luxurious_chest_number")]
        public string LuxuriousChests { get; set; }

        [JsonProperty("exquisite_chest_number")]
        public string ExquisiteChests { get; set; }

        [JsonProperty("common_chest_number")] public string CommonChests { get; set; }
    }
}