using System.Windows.Input;

using IDevign.M3.Candy.EventAggregator;
using IDevign.M3.Candy.Misc;
using IDevign.M3.Candy.Presentation;

namespace IDevign.M3.App
{
    public class MainViewModel : ViewModelBase
    {
        #region Member 

        private string _WindowTitle;
        private string _DependendOnControlValue;

        #endregion

        #region Constructors 

        public MainViewModel()
        {
            Init();
        }

        public MainViewModel(IPresentationManager presentationManager, IEventAggregator eventAggregator)
            : base(presentationManager, eventAggregator)
        {
            EventAggregator = eventAggregator;
            PresentationManager = presentationManager;

            Init();
        }

        private void Init()
        {
            this.WindowTitle = "My custom title...";
            this.DependendOnControlValue = "Nothing so far...";
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
                        // create viewmodel for dialog and hook it up.
                        var vm = new DialogViewModel(PresentationManager, EventAggregator);
                        vm.Closed += (sender, args) => DependendOnControlValue = "Dialog was closed!";

                        // register the viewmodel for all messages that it can handle -> see IHandle<TMessage>
                        EventAggregator.Subscribe(vm);

                        // internally creates the view, puts the viewmodel in its DataContext, attaches a few basic events and opens it.
                        this.PresentationManager.ShowViewFor(vm);
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