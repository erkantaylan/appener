using System.Collections.Generic;
using Newtonsoft.Json;

namespace Appener.Models {

    internal class Database {
        public Database() {
            Apps = new List<MyApp>();
        }

        [JsonProperty("apps")]
        public List<MyApp> Apps { get; set; }
    }

}