using System.Windows;

namespace IDevign.M3.Candy.Presentation
{
    /// <summary>
    /// Contract for registering Views and their ViewModels and present them. In real world applications you would use an 
    /// DI Container like StructureMap, Castle Windsor, etc.
    /// </summary>
    public interface IPresentationManager
    {
        /// <summary>
        /// Registers a view and and its viewmodel for later use
        /// </summary>
        /// <typeparam name="TFrameworkElement">The type of the view.</typeparam>
        /// <typeparam name="TViewModel">The type of the view model belonging to this view.</typeparam>
        void Register<TFrameworkElement, TViewModel>() where TFrameworkElement : FrameworkElement, new() where TViewModel : ViewModelBase, new();

        /// <summary>
        /// Creates a new instance of TViewModel, looks up an already registered view for it, sticks them together (DataContext + Events) 
        /// and then opens the view.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view model to show a view for.</typeparam>
        void ShowViewFor<TViewModel>() where TViewModel : ViewModelBase, new();

        /// <summary>
        /// Uses the given instance of TViewModel, looks up an already registered view for it, sticks them together (DataContext + Events) 
        /// and then opens the view.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view model to show a view for.</typeparam>
        void ShowViewFor<TViewModel>(TViewModel viewModel) where TViewModel : ViewModelBase, new();
    }
}