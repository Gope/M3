using System.Windows.Input;
using IDevign.M3.Candy;

namespace IDevign.M3.App
{
    public class DialogViewModel : ViewModelBase
    {
        private readonly IPresentationManager _PresentationManager;

        public DialogViewModel()
        {
        }

        public DialogViewModel(IPresentationManager presentationManager)
        {
            _PresentationManager = presentationManager;
        }

        
    }
}