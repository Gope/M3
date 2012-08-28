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
            // Push the knowledge about connecting and instantiating view and viewmodel to a 3rd party/component.
            IPresentationManager manager = new PresentationManager();
            manager.Register<DialogView, DialogViewModel>();
            manager.Register<MainView, MainViewModel>();

            var mainViewModel = new MainViewModel(manager);
            manager.ShowViewFor(mainViewModel);
        }
    }
}
