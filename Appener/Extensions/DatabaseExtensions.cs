using System;
using System.IO;
using Appener.Models;

namespace Appener.Extensions {

    internal static class DatabaseExtensions {
        public static void Save(this Database that, string path) {
            File.WriteAllText(path, that.ToJson());
        }


        [Obsolete("This method is shit")]
        public static Database Load(this Database that, string path) {
            return File.Exists(path) ? File.ReadAllText(path).ToObject<Database>() : new Database();
        }
    }

}