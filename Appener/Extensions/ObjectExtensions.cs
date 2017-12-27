using Newtonsoft.Json;

namespace Appener.Extensions {

    internal static class ObjectExtensions {
        public static string ToJson(this object that) {
            return JsonConvert.SerializeObject(that);
        }
    }

}