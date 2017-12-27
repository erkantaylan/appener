using System.Windows;

namespace Appener {

    public partial class App {
        #region Overrides of Application

        protected override void OnStartup(StartupEventArgs e) {
            base.OnStartup(e);
            new Bootstrapper().Run();
        }

        #endregion
    }

}