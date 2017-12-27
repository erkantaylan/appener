using System.Windows;
using MahApps.Metro.Controls.Dialogs;
using Microsoft.Practices.Unity;
using Prism.Unity;

namespace Appener {

    internal class Bootstrapper : UnityBootstrapper {
        protected override DependencyObject CreateShell() {
            return Container.Resolve<ShellView>();
        }

        protected override void InitializeShell() {
            Application.Current.MainWindow?.Show();
        }

        protected override void ConfigureContainer() {
            base.ConfigureContainer();
            var instance = DialogCoordinator.Instance;
            //, new InjectionConstructor(instance)
            Container.RegisterType<IDialogCoordinator, DialogCoordinator>(new ContainerControlledLifetimeManager());
        }
    }

}