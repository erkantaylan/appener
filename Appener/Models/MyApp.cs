using Newtonsoft.Json;
using Prism.Mvvm;

namespace Appener.Models {

    internal class MyApp : BindableBase {
        private string alias;
        private string fullPath;

        public MyApp() { }

        public MyApp(string alias, string fullPath) {
            this.alias = alias;
            this.fullPath = fullPath;
        }

        [JsonProperty("full_path")]
        public string FullPath {
            get => fullPath;
            set => SetProperty(ref fullPath, value);
        }

        [JsonProperty("alias")]
        public string Alias {
            get => alias;
            set => SetProperty(ref alias, value);
        }
    }

}