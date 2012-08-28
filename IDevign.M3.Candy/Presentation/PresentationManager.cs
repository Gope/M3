using System;
using System.Collections.Generic;
using System.Windows;

namespace IDevign.M3.Candy.Presentation
{
    /// <summary>
    /// Registers Views and their ViewModels and presents them. In real world applications you would use an 
    /// DI Container like StructureMap, Castle Windsor, etc.
    /// </summary>
    public class PresentationManager : IPresentationManager
    {
        private Dictionary<Type, Type> viewLookUp = new Dictionary<Type, Type>();

        /// <summary>
        /// Registers a view and and its viewmodel for later use
        /// </summary>
        /// <typeparam name="TFrameworkElement">The type of the view.</typeparam>
        /// <typeparam name="TViewModel">The type of the view model belonging to this view.</typeparam>
        public void Register<TFrameworkElement, TViewModel>() where TFrameworkElement : FrameworkElement, new() where TViewModel : ViewModelBase, new()
        {
            this.viewLookUp.Add(typeof(TViewModel), typeof(TFrameworkElement));
        }

        /// <summary>
        /// Creates a new instance of TViewModel, looks up an already registered view for it, sticks them together (DataContext + Events)
        /// and then opens the view.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view model to show a view for.</typeparam>
        public void ShowViewFor<TViewModel>() where TViewModel : ViewModelBase, new()
        {
            this.ShowViewFor(new TViewModel());
        }

        /// <summary>
        /// Uses the given instance of TViewModel, looks up an already registered view for it, sticks them together (DataContext + Events)
        /// and then opens the view.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view model to show a view for.</typeparam>
        /// <param name="viewModel">The viewmodel instance to use.</param>
        public void ShowViewFor<TViewModel>(TViewModel viewModel) where TViewModel : ViewModelBase, new()
        {
            Type type;
            if (!this.viewLookUp.TryGetValue(typeof (TViewModel), out type))
            {
                throw new InvalidOperationException("No view registered for ViewModel of type " + typeof(TViewModel).Name);
            }

            var view = (Window)Activator.CreateInstance(type);
            view.Loaded += (sender, args) => viewModel.OnLoad();
            view.Unloaded += (sender, args) => viewModel.OnClose();
            view.DataContext = viewModel;

            view.Show();
        }
    }
}
