using System.Collections.Generic;
using System.Threading.Tasks;
using GenshinImpactProfileQuery.Entity;
using GenshinImpactProfileQuery.Utils;

namespace GenshinImpactProfileQuery.Core
{
    public class QueryCore
    {
        public static async Task<ProfileStatsEntity> QueryStats(string uid)
        {
            var json = (await HttpTools.GetAsync(uid)).Content;
            var origin = JsonTools.SerializeProfileEntity(json);

            return origin.data.stats.ToObject<ProfileStatsEntity>();
        }

        public static async Task<IEnumerable<ProfileAvatarEntity>> QueryAvatars(string uid)
        {
            var json = (await HttpTools.GetAsync(uid)).Content;
            var origin = JsonTools.SerializeProfileEntity(json);

            return origin.data.avatars.ToObject<List<ProfileAvatarEntity>>();
        }
    }
}