using System.Collections.ObjectModel;
using System.Diagnostics;
using Appener.Events;
using Appener.Extensions;
using Appener.Models;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;

namespace Appener.ViewModels {

    internal class MyTilesViewModel : BindableBase {
        private ObservableCollection<MyApp> apps;
        private readonly Database db = new Database();

        public MyTilesViewModel(IEventAggregator ea) {
            db = db.Load(Constants.DATABASE_PATH);
            Apps = new ObservableCollection<MyApp>(db.Apps);
            RunAppCommand = new DelegateCommand<MyApp>(RunApp);
            RemoveAppCommand = new DelegateCommand<MyApp>(RemoveApp);
            ea.GetEvent<NewAppEvent>().Subscribe(AddNewApp);
        }

        public ObservableCollection<MyApp> Apps {
            get => apps;
            set => SetProperty(ref apps, value);
        }

        public DelegateCommand<MyApp> RunAppCommand { get; }
        public DelegateCommand<MyApp> RemoveAppCommand { get; }

        private void RemoveApp(MyApp o) {
            Apps.Remove(o);
            db.Apps.Remove(o);
            db.Save(Constants.DATABASE_PATH);
        }

        private void AddNewApp(MyApp o) {
            Apps.Add(o);
        }

        private static void RunApp(MyApp o) {
            Process.Start(o.FullPath);
        }
    }

}