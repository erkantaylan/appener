using Appener.Models;

namespace Appener.Extensions {

    internal static class MyAppExtensions {
        public static string Display(this MyApp that) {
            return $"FullPath: {that.FullPath}\nAlias: {that.Alias}";
        }
    }

}