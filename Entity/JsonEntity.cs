using Newtonsoft.Json.Linq;

namespace GenshinImpactProfileQuery.Entity
{
    public class JsonEntity
    {
        public string retcode { get; set; }

        public string message { get; set; }

        public ProfileData data { get; set; }
    }

    public class ProfileData
    {
        public string role { get; set; }

        public JArray avatars { get; set; }

        public JObject stats { get; set; }
    }
}