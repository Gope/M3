using System;
using System.Windows.Input;
using IDevign.M3.Candy;
using IDevign.M3.Candy.EventAggregator;
using IDevign.M3.Candy.Misc;
using IDevign.M3.Candy.Presentation;

namespace IDevign.M3.App
{
    public class DialogViewModel : ViewModelBase, IHandle<SomethingHappenedInTheDialogMessage>
    {
        #region Member 

        private string _SomeNiceValue;

        #endregion

        #region Constructor 

        public DialogViewModel()
        {
        }

        public DialogViewModel(IPresentationManager presentationManager, IEventAggregator eventAggregator) : base(presentationManager, eventAggregator){}

        #endregion

        #region Lifecycle events 

        public event EventHandler Closed = delegate { };

        protected virtual void OnClosed()
        {
            Closed(this, EventArgs.Empty);
        }

        public override void OnClose()
        {
            base.OnClose();
            OnClosed();
        }

        #endregion

        #region Properties 

        public string SomeNiceValue
        {
            get
            {
                return _SomeNiceValue;
            }
            set
            {
                _SomeNiceValue = value;
                OnPropertyChanged(() => SomeNiceValue);
            }
        }

        #endregion

        #region Commands 

        public ICommand NotifyAllSiblingsCommand
        {
            get { return new DelegateCommand(obj => this.EventAggregator.Publish(new SomethingHappenedInTheDialogMessage("123Info"))); }
        }

        #endregion

        #region Message Handling 

        public void Handle(SomethingHappenedInTheDialogMessage message)
        {
            SomeNiceValue = "Received new Value: " + message.Info;
        }

        #endregion
    }
}