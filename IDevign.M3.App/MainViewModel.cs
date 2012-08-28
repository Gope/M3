using System.Windows.Input;
using IDevign.M3.Candy;
using System.Windows.Threading;

namespace IDevign.M3.App
{
    public class MainViewModel : ViewModelBase
    {
        #region Member 

        private readonly IPresentationManager _PresentationManager;
        private string _WindowTitle;
        private string _DependendOnControlValue;

        #endregion

        #region Constructors 

        public MainViewModel()
        {
            WindowTitle = "My custom title...";
            DependendOnControlValue = "Nothing so far...";
        }

        public MainViewModel(IPresentationManager presentationManager) : this()
        {
            _PresentationManager = presentationManager;
        }

        #endregion

        #region Properties for Binding 

        public string WindowTitle
        {
            get { return _WindowTitle; }
            set
            {
                _WindowTitle = value;
                OnPropertyChanged(() => WindowTitle);
            }
        }

        public string DependendOnControlValue
        {
            get
            {
                return _DependendOnControlValue;
            }
            set
            {
                _DependendOnControlValue = value;
                OnPropertyChanged(() => DependendOnControlValue);
            }
        }

        #endregion

        #region Commands 

        public ICommand OpenDialogCommand
        {
            get
            {
                return new DelegateCommand(obj =>
                    {
                        var vm = new DialogViewModel();
                        vm.Closed += (sender, args) => DependendOnControlValue = "Dialog was closed!";
                        _PresentationManager.ShowViewFor(vm);
                    });
            }
        }

        public ICommand ReactToSomethingCommand
        {
            get
            {
                return new DelegateCommand(obj => { DependendOnControlValue = "You just hovered over this control!"; });
            }
        }

        #endregion
    }
}