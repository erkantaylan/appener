using Newtonsoft.Json;

namespace Appener.Extensions {

    internal static class StringExtensions {
        public static T ToObject<T>(this string that) {
            return JsonConvert.DeserializeObject<T>(that);
        }
    }

}