using System;
using System.Windows.Input;
using IDevign.M3.Candy;

namespace IDevign.M3.App
{
    public class DialogViewModel : ViewModelBase
    {
        private string _SomeNiceValue;

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

        public string SomeNiceValue
        {
            get { return _SomeNiceValue; }
            set { _SomeNiceValue = value;
            JNoti}
        }

        #region Commands 

        public ICommand NotifyAllSiblingsCommand
        {
            get { return new DelegateCommand(obj => { /* EA Stuff here */ }); }
        }

        #endregion

    }
}