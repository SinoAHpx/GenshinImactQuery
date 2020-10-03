using System;

namespace GenshinImpactProfileQuery.Utils
{
    public static class Extensions
    {
        public static bool IsEmptyOrNull(this string source)
        {
            return string.IsNullOrEmpty(source);
        }

        public static bool IsNumber(this string source)
        {
            try
            {
                Convert.ToInt32(source);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static string ToElement(this string source)
        {
            switch (source)
            {
                case "Anemo":
                    return "风";

                case "Pyro":
                    return "火";

                case "Electro":
                    return "雷";

                case "Cryo":
                    return "冰";

                case "Geo":
                    return "岩";

                case "Hydro":
                    return "水";

                default:
                    return source;
            }
        }
    }
}