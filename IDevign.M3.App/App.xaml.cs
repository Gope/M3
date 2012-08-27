using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using IDevign.M3.Candy;

namespace IDevign.M3.App
{
    using System.Threading;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            PresentationManager manager = new PresentationManager();
            manager.Connect<DialogView, DialogViewModel>();
            manager.Connect<MainView, MainViewModel>();

            var mainViewModel = new MainViewModel(manager) { Dispatcher = Application.Current.Dispatcher };
            manager.ShowViewFor(mainViewModel);
        }
    }
}
