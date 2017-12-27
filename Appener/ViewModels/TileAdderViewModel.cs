using System.IO;
using Appener.Events;
using Appener.Extensions;
using Appener.Models;
using MahApps.Metro.Controls.Dialogs;
using Microsoft.Win32;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;

namespace Appener.ViewModels {

    internal class TileAdderViewModel : BindableBase {
        private readonly Database database;
        private readonly IDialogCoordinator dialogCoordinator;
        private readonly IEventAggregator ea;
        private string alias;
        private string fullPath;

        public TileAdderViewModel(IDialogCoordinator dialogCoordinator, IEventAggregator ea) {
            this.dialogCoordinator = dialogCoordinator;
            this.ea = ea;
            database = new Database();
            database = database.Load(Constants.DATABASE_PATH);
            SaveCommand = new DelegateCommand(Save, CanSave)
                .ObservesProperty(() => FullPath)
                .ObservesProperty(() => Alias);
            BrowseCommand = new DelegateCommand(Browse);
        }

        public string FullPath {
            get => fullPath;
            set => SetProperty(ref fullPath, value);
        }

        public string Alias {
            get => alias;
            set => SetProperty(ref alias, value);
        }

        public DelegateCommand SaveCommand { get; }
        public DelegateCommand BrowseCommand { get; }

        private void Browse() {
            OpenFileDialog ofd = new OpenFileDialog();
            bool? result = ofd.ShowDialog();
            if (result == true) {
                FullPath = ofd.FileName;
                Alias = Path.GetFileNameWithoutExtension(ofd.FileName);
            }
        }

        private async void Save() {
            MyApp app = new MyApp(alias, fullPath);
            await dialogCoordinator.ShowMessageAsync(this, "Saving", app.Display());
            database.Apps.Add(app);
            database.Save(Constants.DATABASE_PATH);
            ea.GetEvent<NewAppEvent>().Publish(app);
        }

        private bool CanSave() {
            if (string.IsNullOrWhiteSpace(Alias)) {
                return false;
            }

            try {
                File.GetAttributes(FullPath);
            }
            catch {
                return false;
            }

            return true;
        }
    }

}