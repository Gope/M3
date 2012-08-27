using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace IDevign.M3.Candy
{
    public interface IPresentationManager
    {
        void Connect<TFrameworkElement, TViewModel>() where TFrameworkElement : FrameworkElement, new() where TViewModel : ViewModelBase, new();
        void ShowViewFor<TViewModel>() where TViewModel : ViewModelBase, new();
        void ShowViewFor<TViewModel>(TViewModel viewModel) where TViewModel : ViewModelBase, new();
    }

    public class PresentationManager : IPresentationManager
    {
        private Dictionary<Type, Type> viewLookUp = new Dictionary<Type, Type>(); 

        public void Connect<TFrameworkElement, TViewModel>() where TFrameworkElement : FrameworkElement, new() where TViewModel : ViewModelBase, new()
        {
            viewLookUp.Add(typeof(TViewModel), typeof(TFrameworkElement));
        }

        public void ShowViewFor<TViewModel>() where TViewModel : ViewModelBase, new()
        {
            ShowViewFor<TViewModel>(new TViewModel());
        }

        public void ShowViewFor<TViewModel>(TViewModel viewModel) where TViewModel : ViewModelBase, new()
        {
            Type type;
            if (viewLookUp.TryGetValue(typeof (TViewModel), out type))
            {

            }
            else
            {
                throw new InvalidOperationException("No view registered for ViewModel of type " + typeof (TViewModel).Name);
            }

            var view = (Window)Activator.CreateInstance(type);
            view.Loaded += (sender, args) => viewModel.OnLoad();
            view.Unloaded += (sender, args) => viewModel.OnClose();
            view.DataContext = viewModel;

            view.Show();
        }
    }
}
