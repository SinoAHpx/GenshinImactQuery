using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;

namespace GenshinImpactProfileQuery.Utils
{
    public static class HttpTools
    {
        public static async Task<IRestResponse> GetAsync(string uid)
        {
            //https://api-takumi.mihoyo.com/game_record/genshin/api/index?server=cn_gf01&role_id=112075042

            var client = new RestClient(
                $"https://api-takumi.mihoyo.com/game_record/genshin/api/index?server=cn_gf01&role_id={uid}");

            client.AddDefaultHeaders(new Dictionary<string, string>
            {
                {
                    "Accept",
                    "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9"
                },
                {"Origin", "https://webstatic.mihoyo.com"},
                {"Accept-Encoding", "gzip, deflate"},
                {"Accept-Language", "zh-CN,zh;q=0.9,zh-HK;q=0.8"},
                {
                    "User-Agent",
                    "Mozilla/5.0 (Windows NT 10.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/85.0.4183.102 Safari/537.36"
                },
                {"DS", GetDS()},
                {"Rferer", "https://webstatic.mihoyo.com/app/community-game-records/index.html?v=6"},
                {"x-rpc-app_version", "2.1.0"},
                {"x-rpc-client_type", "4"},
                {"X-Requested-With", "com.mihoyo.hyperion"}
            });

            return await client.ExecuteAsync(new RestRequest(Method.GET));
        }

        public static string GetDS()
        {
            var ver = "2.1.0".GetMd5();
            var time = new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds();
            var rs = GetRandomString(6);
            var re = $"salt={ver}&t={time}&r={rs}".GetMd5();

            return $"{time},{rs},{re}";
        }

        public static string GetRandomString(int length)
        {
            var random = new Random();
            var chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}